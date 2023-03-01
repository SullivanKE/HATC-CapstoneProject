using HATC_CapstoneProject.Models;
using System.Runtime.CompilerServices;

namespace HATC_CapstoneProject.Data
{
    public interface ISessionRepo
    {
        public IQueryable<Session> SessionsAsync { get; }
        public Task<Session> GetSessionAsync(string id);
        public Task<int> SavePostAsync(Session session);
        public Task<List<Session>> GetAllSessionsAsync();
    }
}
