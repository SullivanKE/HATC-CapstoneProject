using HATC_CapstoneProject.Models;
using System.Runtime.CompilerServices;

namespace HATC_CapstoneProject.Data
{
    public interface IHavenRepo
    {
        public IQueryable<Object> ItemsAsync { get; }
        public Task<Object> GetItemAsync(string id);
        public Task<int> SaveItemAsync(Object item);
        public Task<List<Object>> GetAllItemsAsync();
    }
}
