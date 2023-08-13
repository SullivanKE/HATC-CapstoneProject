using Microsoft.EntityFrameworkCore.Metadata;

using System.Text.RegularExpressions;

namespace HATC_CapstoneProject.Services;

/// <summary>
/// The Import object will parse a csv from a file and save the table to an SQL database.
/// </summary>
/// <typeparam name="T">T is a type inheriting from <see cref="DbContext"/>.</typeparam>
public class Import<T> where T : DbContext
{
    #region Properties & Fields
    private readonly T _context;
    private readonly string[] _permittedExtensions = { ".csv" };

    // default configuration for CsvHelper
    public CsvConfiguration CsvConfig { get; set; } = new CsvConfiguration(CultureInfo.CurrentCulture)
    {
        HasHeaderRecord = true,
        IgnoreBlankLines = true,
        MissingFieldFound = null,
        BadDataFound = null,
        ExceptionMessagesContainRawData = true,
        TrimOptions = TrimOptions.Trim,
        Escape = '\\',
        ShouldSkipRecord = null,
    };

    public Regex FieldsFilter { get; set; } = new(@"[\!\#\$\%\&`'\(\)\*\+\,\-\.\/\:\;\<\=\>\?\@\[\]\^_\`\{\|\}\~]");

    #endregion

    /// <summary>
    /// Create an Import object to help with parsing csv files
    /// </summary>
    /// <param name="context">the implimentation of the DbContext indicated by <typeparamref name="T"/> </param>
    public Import(T context) => _context = context;

    /// <summary>
    /// Create an <see cref="Import{T}"/> object by giving a custom DbContext class as <typeparamref name="T"/>
    /// </summary>
    /// <param name="context">a custom dbContext class connected to the database to import a spreadsheet to.</param>
    /// <param name="configuration">a custom <see cref="CsvConfiguration"/></param>
    public Import(T context, Func<CsvConfiguration> configuration)
    {
        _context = context;
        CsvConfig = configuration();
    }

    /// <summary>
    ///  Create an <see cref="Import{T}"/> object by supplying a new regex string pattern to remove from all fields and a custom DbContext class as <typeparamref name="T"/>
    /// </summary>
    /// <param name="context">a custom dbContext class connected to the database to import a spreadsheet to.</param>
    /// <param name="fieldFilterPattern">a regex pattern to match against fields and remove</param>
    /// <param name="configuration">a custom <see cref="CsvConfiguration"/></param>
    public Import(T context, string fieldFilterPattern, Func<CsvConfiguration> configuration)
    {
        _context = context;
        FieldsFilter = new(fieldFilterPattern);
        CsvConfig = configuration();

    }

    /// <summary>
    /// given a reader and a table name, assemble sql CREATE and INSERT statements to build a new table. returns an array of 2 sql statements
    /// <br />index [1] == CREATE TABLE
    /// <br />index [2] == INSERT INTO
    /// </summary>
    /// <param name="tableName">the name of the new table</param>
    /// <param name="csvReader">the <see cref="CsvHelper.CsvReader"/> with the stream containing the csv file. The Csv Reader should not have Read or ReadHeader called before passing to this method.</param>
    /// <returns></returns>
    private string[] BuildSqlString(string tableName, CsvReader csvReader)
    {
        _ = csvReader.Read();
        _ = csvReader.ReadHeader();
        string insertInto = $"INSERT INTO {tableName} (";
        string createTable = BeginCreateSQL(tableName);
        for (int i = 0; i < csvReader.HeaderRecord!.Length; i++)
        {
            string headerRecord = FieldsFilter.Replace(csvReader.HeaderRecord[i], string.Empty);

            createTable += $" {headerRecord} ";

            bool didParse = int.TryParse(createTable, out _);
            if (didParse)
            {
                createTable += "int, ";
            }
            else
            {
                createTable += "VARCHAR(256), ";
            }

            insertInto += $"{headerRecord}, ";
        }

        insertInto = insertInto[..^2];
        insertInto += ")\n VALUES ";

        while (csvReader.Read())
        {
            insertInto += "\n(";

            IDictionary<string, object> record = (IDictionary<string, object>)csvReader.GetRecord<dynamic>()!;
            for (int i = 0; i < csvReader.HeaderRecord.Length; i++)
            {
                // the names found in the header row are used as keys in record dictionary.
                object r = record[csvReader.HeaderRecord[i]];
                r = FieldsFilter.Replace($"{r}", string.Empty);
                insertInto += $"'{r}', ";

            }
            insertInto = insertInto[..^2];
            insertInto += "),";
        }
        createTable = createTable[..^2] + ");";
        insertInto = insertInto[..^1] + ";";
        return new string[] { createTable, insertInto };
    }

    /// <summary>
    /// Import a csv file and save it as an SQL table in the database connectected to <typeparamref name="T"/> : <see cref="DbContext"/>
    /// throws an exception when an unallowed file type is given. All fields on this dynamic type will be string/VARCHAR(256)
    /// </summary>
    /// <param name="file">a file submitted by a form input html element</param>
    /// <param name="tableName">the name of the SQL table to make.</param>
    /// <exception cref="InvalidOperationException"></exception>
    /// <returns>the number of rows affected</returns>
    public Task<int> DynamicImportCSV(IFormFile file, string tableName)
    {
        if (!ValidateCsv(file))
        {
            return Task.FromResult(0);
        }
        tableName = FieldsFilter.Replace(tableName, string.Empty);

        using StreamReader sr = new(file.OpenReadStream());
        using CsvReader csvReader = new(sr, CsvConfig);

        string[] sqlString = BuildSqlString(tableName, csvReader);
        _ = _context.Database.ExecuteSqlRaw(sqlString[0]);
        int rows = _context.Database.ExecuteSqlRaw(sqlString[^1]);
        return Task.FromResult(rows);
    }

    public Task<int> MappedImportCsv(object entity, IFormFile file)
    {
        Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry entry = _context.Entry(entity);
        if (!ValidateCsv(file))
        {
            return Task.FromResult(0);
        }
        CsvConfiguration config = new(CultureInfo.InvariantCulture)
        {
            PrepareHeaderForMatch = args => FieldsFilter.Replace(args.Header, string.Empty)
        };
        using StreamReader sr = new(file.OpenReadStream());
        using CsvReader csvReader = new(sr, config);

        IEnumerable<Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<IEntityType>> records = (IEnumerable<Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<IEntityType>>)csvReader.EnumerateRecords(entry);
        foreach (IModel record in records)
        {
            Console.WriteLine(record.AnnotationsToDebugString());
        }
        return Task.FromResult(1);
    }

    private bool ValidateCsv(IFormFile file)
    {
        string ext = Path.GetExtension(file.FileName).ToLowerInvariant();

        // varify file is csv.
        return !string.IsNullOrEmpty(ext) && _permittedExtensions.Contains(ext);

    }

    private string BeginCreateSQL(string tableName)
    {
        string createTable;

        // if using MySQL
        if (_context.Database.IsMySql())
        {
            _ = _context.Database.ExecuteSqlRaw($"DROP TABLE IF EXISTS {tableName};");
            createTable = $"CREATE TABLE {tableName} " +
                    $"(Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,";
        }
        // if using SQL Server. Will also handle localDb
        else
        {
            _ = _context.Database.ExecuteSqlRaw($"IF OBJECT_ID('{tableName}') IS NOT NULL DROP TABLE {tableName};");
            createTable = $"CREATE TABLE {tableName} " +
                $"(id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,";
        }
        return createTable;
    }
}

