

namespace HATC_CapstoneProject.Controllers
{
    public class AchievementsController : Controller
    {
        private HavenDbContext _context;
        private IHavenRepo repo;
        private UserManager<Player> userManager;

        public AchievementsController(IHavenRepo repo, UserManager<Player> userMngr, HavenDbContext context)
        {
            this.repo = repo;
            userManager = userMngr;
            _context = context;
        }

        // GET: Achievements
        public async Task<IActionResult> Index()
        {
            return View(await repo.GetAllAchievementsAsync());
        }

        // GET: Achievements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Achievements == null)
            {
                return NotFound();
            }

            var achievement = await _context.Achievements
                .FirstOrDefaultAsync(m => m.Id == id);
            if (achievement == null)
            {
                return NotFound();
            }

            return View(achievement);
        }

        // GET: Achievements/Create
        public async Task<IActionResult> Create()
        {
            List<Rank> ranks = await repo.GetAllRanksAsync();

            List<SelectListItem> allRanks = new();
            foreach (Rank rank in ranks)
            {
                allRanks.Add(new SelectListItem { Text = rank.Name, Value = rank.Id.ToString() });
            }
            ViewBag.allranks = allRanks;
            return View();
        }

        // POST: Achievements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Achievement achievement, string criteria, int goal, string allranks)
        {
            /*if (ModelState.IsValid)
            {*/
            AchievementProgress achprog = new();
            if (criteria != null)
            {
                achprog.Criteria = criteria;
                achprog.Progress = 0;
                achprog.Goal = goal;

                achievement.AchievementProgress = new List<AchievementProgress> { achprog };
            }
            if (allranks != null && allranks != string.Empty)
            {
                int index = int.Parse(allranks);
                achievement.Level = await repo.GetRankAsync(index);
            }

            await repo.SaveAchievementAsync(achievement);
            return RedirectToAction(nameof(Index));
            //}
            //return View(achievement);
        }

        // GET: Achievements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Achievements == null)
            {
                return NotFound();
            }

            var achievement = await _context.Achievements.FindAsync(id);
            if (achievement == null)
            {
                return NotFound();
            }
            return View(achievement);
        }

        // POST: Achievements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Status,Benefit,Criteria,Goal,Progress")] Achievement achievement)
        {
            if (id != achievement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(achievement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AchievementExists(achievement.Id))
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
            return View(achievement);
        }

        // GET: Achievements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Achievements == null)
            {
                return NotFound();
            }

            var achievement = await _context.Achievements
                .FirstOrDefaultAsync(m => m.Id == id);
            if (achievement == null)
            {
                return NotFound();
            }

            return View(achievement);
        }

        // POST: Achievements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Achievements == null)
            {
                return Problem("Entity set 'HavenDbContext.Achievements'  is null.");
            }
            var achievement = await _context.Achievements.FindAsync(id);
            if (achievement != null)
            {
                _context.Achievements.Remove(achievement);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AchievementExists(int id)
        {
            return _context.Achievements.Any(e => e.Id == id);
        }
    }
}
