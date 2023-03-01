using HATC_CapstoneProject.Models;
using System.Runtime.CompilerServices;

namespace HATC_CapstoneProject.Data
{
    public interface IShopRepo
    {
        public IQueryable<ShopItem> ShopAsync { get; }
        public Task<ShopItem> GetShopAsync(string id);
        public Task<int> SaveShopAsync(ShopItem session);
        public Task<List<ShopItem>> GetAllShopAsync();
    }
}
