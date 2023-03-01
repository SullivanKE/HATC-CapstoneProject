using HATC_CapstoneProject.Models;
using System.Runtime.CompilerServices;

namespace HATC_CapstoneProject.Data
{
    public interface IDowntimeRepo
    {
        public IQueryable<Downtime> DowntimeAsync { get; }
        public Task<Session> GetDowntimeAsync(string id);
        public Task<int> SaveDowntimeAsync(Downtime downtime);
        public Task<int> DeleteDowntimeAsync(Downtime downtime);
        public Task<List<Downtime>> GetAllDowntimeAsync();
    }
}
