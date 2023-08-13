using AspNetCoreHero.ToastNotification.Abstractions;

namespace HATC_CapstoneProject.Controllers;

public class ToolsController : Controller
{
    private readonly Import<HavenDbContext> _import;
    private readonly HavenDbContext _context;
    private readonly INotyfService _toast;

    public Dictionary<string, object> FillTableList()
    {
        var etypes =_context.Model.GetEntityTypes();
        foreach (var type in etypes)
        {
            object? entityRows = _context.GetType().GetMethod("Set")!.MakeGenericMethod(type.ClrType).Invoke(_context, null);

            Console.WriteLine(entityRows);
        }
        return new Dictionary<string, object>();
    }


    public ToolsController(Import<HavenDbContext> import, HavenDbContext context, INotyfService toast)
    {
        _import = import;
        _context = context;
        _toast = toast;
    }
    public IActionResult Index() => View();
    public IActionResult PollCreator() => View();

    [HttpGet]
    public IActionResult ImportCsv()
    {

        ImportVM ivm = new()
        {
            TableList = FillTableList()
        };
        return View(ivm);
    }

    [HttpPost]
    public IActionResult ImportCsv([Bind(nameof(ImportVM.TableName), nameof(ImportVM.CsvFile), nameof(ImportVM.TableList), nameof(ImportVM.SelectedTable))] ImportVM ivm)
    {
        if (ivm.TableList.Count == 0)
        {
            ivm.TableList = FillTableList();
        }

        ivm.SelectedTable = ivm.TableList[ivm.TableName];

        _ = _import.MappedImportCsv(ivm.SelectedTable, ivm.CsvFile!);
        return View(ivm);
    }
}
