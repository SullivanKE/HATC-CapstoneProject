using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HATC_CapstoneProject.Data;
using HATC_CapstoneProject.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Identity;

namespace HATC_CapstoneProject.Controllers
{
	public class ShopController : Controller
    {
		private readonly HavenDbContext _context;
		private IHavenRepo repo;
		private UserManager<Player> userManager;

		public ShopController(IHavenRepo repo, UserManager<Player> userMngr)
		{
			this.repo = repo;
			this.userManager = userMngr;
		}

		// GET: Shop
		public async Task<IActionResult> Index()
        {
              return View(await repo.GetAllShopItemsAsync());
        }

        // GET: Shop/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Shop == null)
            {
                return NotFound();
            }

            var shopItem = await repo.GetShopItemAsync((int)id);
            if (shopItem == null)
            {
                return NotFound();
            }

            return View(shopItem);
        }

        // GET: Shop/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shop/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PriceAdjustment,Source,BanReason,ManualWeight,Notes,isAttunement,isShoppable,isCraftable,Name,Value")] ShopItem shopItem)
        {
            if (ModelState.IsValid)
            {
                await repo.SaveShopItemAsync(shopItem);
                return RedirectToAction(nameof(Index));
            }
            return View(shopItem);
        }

        // GET: Shop/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Shop == null)
            {
                return NotFound();
            }

            var shopItem = await repo.GetShopItemAsync((int)id);
            if (shopItem == null)
            {
                return NotFound();
            }
            return View(shopItem);
        }

        // POST: Shop/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PriceAdjustment,Source,BanReason,ManualWeight,Notes,isAttunement,isShoppable,isCraftable,Id,Name,Value")] ShopItem shopItem)
        {
            if (id != shopItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shopItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShopItemExists(shopItem.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(shopItem);
        }

        // GET: Shop/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Shop == null)
            {
                return NotFound();
            }

            var shopItem = await _context.Shop
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shopItem == null)
            {
                return NotFound();
            }

            return View(shopItem);
        }

        // POST: Shop/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Shop == null)
            {
                return Problem("Entity set 'HavenDbContext.Shop'  is null.");
            }
            var shopItem = await _context.Shop.FindAsync(id);
            if (shopItem != null)
            {
                _context.Shop.Remove(shopItem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShopItemExists(int id)
        {
          return _context.Shop.Any(e => e.Id == id);
        }
    }
}
