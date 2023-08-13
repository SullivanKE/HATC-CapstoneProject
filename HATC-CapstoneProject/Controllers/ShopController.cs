namespace HATC_CapstoneProject.Controllers;

public class ShopController : Controller
{
    private readonly HavenDbContext _context;
    private readonly IHavenRepo repo;
    private readonly UserManager<Player> userManager;

    public ShopController(IHavenRepo repo, UserManager<Player> userMngr, HavenDbContext context)
    {
        this.repo = repo;
        userManager = userMngr;
        _context = context;
    }

    // GET: Shop
    public async Task<IActionResult> Index()
    {
        List<ShopItem> shopItems = await repo.GetAllShopItemsAsync();
        List<Rank> ranks = await repo.GetAllRanksAsync();
        ranks = ranks.Distinct().OrderBy(r => r.Name).ToList();
        ShopVM svm = new();
        foreach (Rank item in ranks)
        {
            if (!item.Ranking.HasFlag(Rarity.All))
            {
                svm.RarityColors.Add(item.Name, item.BgColor);

            }
        }
        svm.Items = shopItems;
        return View(svm);
    }

    // GET: Shop/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || _context.Shop == null)
        {
            return NotFound();
        }

        ShopItem shopItem = await repo.GetShopItemAsync((int)id);
        return shopItem == null ? NotFound() : View(shopItem);
    }

    public IActionResult Create() => View();


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("PriceAdjustment,Source,BanReason,ManualWeight,Notes,isAttunement,isShoppable,isCraftable,Name,Value")] ShopItem shopItem)
    {
        if (ModelState.IsValid)
        {
            _ = await repo.SaveShopItemAsync(shopItem);
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

        ShopItem shopItem = await repo.GetShopItemAsync((int)id);
        return shopItem == null ? NotFound() : View(shopItem);
    }

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
                _ = _context.Update(shopItem);
                _ = await _context.SaveChangesAsync();
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

        ShopItem? shopItem = await _context.Shop
            .FirstOrDefaultAsync(m => m.Id == id);
        return shopItem == null ? NotFound() : View(shopItem);
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
        ShopItem? shopItem = await _context.Shop.FindAsync(id);
        if (shopItem != null)
        {
            _ = _context.Shop.Remove(shopItem);
        }

        _ = await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    /// <summary>
    /// Search for ShopItems that match the criteria passed in to this method.
    /// </summary>
    /// <param name="svm">A <see cref="ShopVM"/> Used to tranfer data between view and controller</param>
    /// <returns>Redirects to Index of ShopController</returns>
    [HttpPost]
    public async Task<IActionResult> AdvancedSearch([Bind("SearchString, Items, SearchCriteria, CriteriaBoxes, RarityColors, SearchItemLow, SearchItemHigh, SearchCraftingLow, SearchCraftingHigh")] ShopVM svm)
    {

        // each element in CriteriaBoxes corresponds to a search filter switch / checkbox.
        foreach ((Criteria name, bool value) in svm.CriteriaBoxes)
        {
            // value is the checkbox bool and we want to ignore Criteria.None 
            if (value && name != Criteria.None)
            {
                svm.SearchCriteria |= name;
            }
        }

        List<Rank> ranks = await repo.GetAllRanksAsync();
        foreach (Rank item in ranks)
        {
            svm.RarityColors.Add(item.Name, item.BgColor);
        }
        svm.Items = await repo.AdvancedShopSearch(svm.SearchString, svm.SearchCriteria);
        svm.Items = svm.Items.OrderBy(x => x.Name).ToList();
        if ((svm.SearchItemLow > 0 || svm.SearchItemHigh <= 1000000) && svm.SearchItemHigh > svm.SearchItemLow)
        {
            svm.Items = svm.Items
                .Where(item => item.Value >= svm.SearchItemLow && item.Value <= svm.SearchItemHigh)
                .ToList();
        }

        if ((svm.SearchCraftingLow > 0 || svm.SearchCraftingHigh <= 1000000) && svm.SearchCraftingHigh > svm.SearchCraftingLow)
        {

            svm.Items = svm.Items
                .Where(item => item.Value >= svm.SearchCraftingLow && item.Value <= svm.SearchCraftingHigh)
                .ToList();
        }

        return View("Index", svm);
    }

    private bool ShopItemExists(int id) => _context.Shop.Any(e => e.Id == id);
}
