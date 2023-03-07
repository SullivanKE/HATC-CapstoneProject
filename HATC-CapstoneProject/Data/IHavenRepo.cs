using HATC_CapstoneProject.Models;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace HATC_CapstoneProject.Data
{
    public interface IHavenRepo
    {
        public IQueryable<Downtime> DowntimeAsync { get; }
        public Task<Downtime> GetDowntimeAsync(int id);
        public Task<int> SaveDowntimeAsync(Downtime item);
        public Task<List<Downtime>> GetAllDowntimeAsync();
    }
}
