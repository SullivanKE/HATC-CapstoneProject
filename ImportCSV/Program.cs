using CsvHelper;
using CsvHelper.Configuration;
using HATC_CapstoneProject.Models;
using System.Globalization;

namespace LFMAdmin.ImportShop;

public static class ImportShop
{

    public static void Main(string[] args)
    {
        var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
        {
            HasHeaderRecord = true,
            IgnoreBlankLines = true,
            MissingFieldFound = null,
            BadDataFound = null,
            Escape = '\\',

        };
        string basePath = "C:\\Users\\dfree\\Documents\\CSharpProject\\HATC-CapstoneProject\\ImportCSV\\SQL\\";
        //var sr = new StreamReader(Path.Combine(basePath, "importShop.sql"));
        using var csv = File.OpenText(Path.Combine(basePath, "importShop.csv"));
        using var csvReader = new CsvReader(csv, csvConfig);
        csvReader.Read();
        csvReader.ReadHeader();
        foreach (var line in csvReader.GetRecords(new
        {
            Name = string.Empty,
            Value = string.Empty,
            //_ = "",
            //__ = "",
            Source = string.Empty,
            IsAttunement = string.Empty,
            Rarity = string.Empty,
            IsCraftable = string.Empty,
            //___ = "",
            //____ = "",
            //_____ = "",
            //______ = "",
        }))
        {
            ShopItem shopItem = new()
            {
                Name = line.Name,
                Value = int.Parse(line.Value)
            };
            Console.WriteLine(shopItem.Name);
        }
        //var csvLines = csv.ReadToEnd();
        //var splitLines = sr.ReadToEnd().Split("VALUES", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        //Console.WriteLine(csvLines);
        //Console.Read();

    }
}