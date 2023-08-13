namespace HATC_CapstoneProject.ViewModels;

public class ImportVM
{
    public IFormFile? CsvFile { get; set; }
    public string TableName { get; set; } = string.Empty;
    public object SelectedTable { get; set; } = default!;
    public IDictionary<string, object> TableList { get; set; } = new Dictionary<string, object>();
}
