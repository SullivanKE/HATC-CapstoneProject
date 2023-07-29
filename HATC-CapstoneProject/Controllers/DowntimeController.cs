namespace HATC_CapstoneProject.Controllers
{
    public class DowntimeController : Controller
    {
        private readonly HavenDbContext _context;
        private IHavenRepo repo;
        private UserManager<Player> userManager;

        public DowntimeController(IHavenRepo repo, UserManager<Player> userMngr, HavenDbContext context)
        {
            this.repo = repo;
            userManager = userMngr;
            _context = context;
        }

        // GET: Downtime
        public async Task<IActionResult> Index()
        {
            return View(await repo.GetAllDowntimeAsync());
        }

        // GET: Downtime/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Downtime == null)
            {
                return NotFound();
            }

            var downtime = await _context.Downtime
                .FirstOrDefaultAsync(m => m.Id == id);
            if (downtime == null)
            {
                return NotFound();
            }

            return View(downtime);
        }

        // GET: Downtime/Create
        public async Task<IActionResult> Create()
        {
            DowntimeVM view = new()
            {
                Dt = new Downtime
                {
                    Resources = new List<StringListItem>
                {
                    new StringListItem
                    {
                        Item = ""
                    }
                },
                    Resolution = new List<StringListItem>
                {
                    new StringListItem
                    {
                        Item = ""
                    }
                },
                    Tables = new List<DowntimeTable>
                {
                    new DowntimeTable
                    {
                        Table = new List<DowntimeTableRow>
                        {
                            new DowntimeTableRow
                            {
                                Row = new List<TableListItem>
                                {
                                    new TableListItem
                                    {
                                        Item = ""
                                    }
                                }
                            }
                        }
                    }
                }
                }
            };

            List<Achievement> achievements = await repo.GetAllAchievementsAsync();
            foreach (Achievement achievement in achievements)
            {
                view.AllAchievements.Add(new SelectListItem { Text = achievement.Name, Value = achievement.Id.ToString() });
            }
            ViewBag.achievements = view.AllAchievements;

            return View(view);
        }

        // POST: Downtime/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DowntimeVM downtimeVM, string achievements, string resolution, string resource)
        {
            Downtime downtime = new();
            if (ModelState.IsValid)
            {
                downtime = downtimeVM.Dt;
                if (downtimeVM.CsvTables != null)
                {
                    for (int i = 0; i <= downtimeVM.CsvTables.Count; i++)
                    {
                        //string Table = downtimeVM.CsvTables[i];

                        /*if (Table != String.Empty)
                        {
                            List<DowntimeTableRow> row = StringMethods.CsvSeparator(Table);

                            downtime.Tables.ToList();
						}*/
                    }

                }
                if (resolution != null)
                {
                    downtime.Resolution = new List<StringListItem>
                    {
                        new StringListItem
                        {
                            Item = resolution
                        }
                    };
                }
                if (resource != null)
                {
                    downtime.Resources = new List<StringListItem>
                    {
                        new StringListItem
                        {
                            Item = resource
                        }
                    };

                }
                if (achievements != null && achievements != string.Empty)
                {
                    int index = int.Parse(achievements);
                    downtime.Achievements = new List<Achievement>
                    {
                        await repo.GetAchievementAsync(index)
                    };
                }

                await repo.SaveDowntimeAsync(downtime);
                return RedirectToAction(nameof(Index));
            }
            return View(downtime);
        }

        // GET: Downtime/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Downtime == null)
            {
                return NotFound();
            }

            var downtime = await _context.Downtime.FindAsync(id);
            if (downtime == null)
            {
                return NotFound();
            }
            return View(downtime);
        }

        // POST: Downtime/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Status")] Downtime downtime)
        {
            if (id != downtime.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(downtime);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DowntimeExists(downtime.Id))
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
            return View(downtime);
        }

        // GET: Downtime/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Downtime == null)
            {
                return NotFound();
            }

            var downtime = await _context.Downtime
                .FirstOrDefaultAsync(m => m.Id == id);
            if (downtime == null)
            {
                return NotFound();
            }

            return View(downtime);
        }

        // POST: Downtime/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Downtime == null)
            {
                return Problem("Entity set 'HavenDbContext.Downtime'  is null.");
            }
            var downtime = await _context.Downtime.FindAsync(id);
            if (downtime != null)
            {
                _context.Downtime.Remove(downtime);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DowntimeExists(int id)
        {
            return _context.Downtime.Any(e => e.Id == id);
        }
    }
}
