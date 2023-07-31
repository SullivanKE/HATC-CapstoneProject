

namespace HATC_CapstoneProject.Data.Seed;

public static class Import
{
    public static void ImportCSV(HavenDbContext context)
    {

        var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
        {
            HasHeaderRecord = true,
            IgnoreBlankLines = true,
            MissingFieldFound = null,
            BadDataFound = null,
            ExceptionMessagesContainRawData = true,
            DetectDelimiterValues = new string[] { "|" },
            TrimOptions = TrimOptions.Trim,
            Delimiter = "|",
            Escape = '\\',

        };
        string basePath = string.Empty;
        if (OperatingSystem.IsWindows())
        {
            basePath = "C:\\Users\\dfree\\Documents\\CSharpProject\\HATC-CapstoneProject\\HATC-CapstoneProject\\Data\\Seed\\";

        }
        else if (OperatingSystem.IsMacOS())
        {

            basePath = "~/Documents/prog/HATC-CapstoneProject/ImportCSV/SQL/";
        }
        //var sr = new StreamReader(Path.Combine(basePath, "importShop.sql"));
        using var csv = File.OpenText(Path.Combine(basePath, "importShop.csv"));
        using var csvReader = new CsvReader(csv, csvConfig);
        csvReader.Read();
        csvReader.ReadHeader();
        var fromCSV = csvReader.GetRecords<ShopItemTemplate>();
        foreach (var line in fromCSV)
        {
            var rank = context.Ranks.First(rank => rank.Name == line.Rarity);
            ShopItem si = new()
            {
                Name = line.Name,
                IsAttunement = line.IsAttunement,
                IsCraftable = line.IsCraftable,
                IsShoppable = line.IsShoppable,
                Rarity = rank,
                Source = line.Source,
                Value = line.GetValue
            };
            Console.WriteLine(line.ToString());
            context.Shop.Add(si);
            context.SaveChanges();
        }
        Console.ReadLine();
    }

}

[Delimiter("|")]
public class ShopItemTemplate
{
    [Name("Name")]
    public string Name { get; set; } = string.Empty;
    [Name("Source")]
    public string Source { get; set; } = string.Empty;

    [Name("Value")]
    public string SetValue
    {

        set => GetValue = int.Parse(value.Trim().Replace(",", ""));
    }

    public int GetValue { get; private set; }
    [Name("Rarity")]
    public string Rarity { get; set; } = string.Empty;
    [BooleanTrueValues("Yes")]
    [BooleanFalseValues("No")]
    public bool IsAttunement { get; set; }
    [BooleanTrueValues("Yes")]
    [BooleanFalseValues("No")]
    public bool IsShoppable { get; set; }
    [BooleanTrueValues("Yes")]
    [BooleanFalseValues("No")]
    public bool IsCraftable { get; set; }

    public override string ToString()
    {
        return $"{Name}, {Source}, {GetValue}, {Rarity}, {IsAttunement}, {IsShoppable}, {IsCraftable}";
    }
}