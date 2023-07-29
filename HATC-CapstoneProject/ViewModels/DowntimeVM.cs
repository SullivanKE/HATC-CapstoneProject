using HATC_CapstoneProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HATC_CapstoneProject.ViewModels
{
    public class DowntimeVM
    {
        public Downtime Dt { get; set; }
        public List<string>? CsvTables { get; set; }
        public List<SelectListItem> AllAchievements { get; set; } = new List<SelectListItem>();
    }
}
