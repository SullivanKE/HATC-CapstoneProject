using HATC_CapstoneProject.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace HATC_CapstoneProject.Data
{
	public class SeedData
	{
		public static void Seed1(HavenDbContext context, IServiceProvider provider)
		{
			if (!context.Sessions.Any())
			{
				// Generate users
				var userManager = provider.GetRequiredService<UserManager<Player>>();

				//TODO: Use user secrets to hide the password
				const string PASSWORD = "root";
				Player user1 = new Player
				{
					UserName = "root"
				};
				userManager.CreateAsync(user1, PASSWORD);

				//Generate character
				Character character = new Character
				{
					Player = user1,
					Exp = 0,
					Downtime = 0
				};
				context.Characters.Add(character);
				context.SaveChanges();

				// Generate Sessions
				Session session;
				session = new Session
				{
					GMCharacter = character,
					RealDate = DateTime.Now,
					InGameDate = "Jan 1, Year 1",
					DowntimeReward = 0
				};
				context.Sessions.Add(session);

				context.SaveChanges();

			}
		}
		public static void Seed2(HavenDbContext context, IServiceProvider provider)
		{
			if (!context.Downtime.Any())
			{


				// Generate downtime
				List<StringListItem> Resources = new List<StringListItem>();
				Resources.Add(new StringListItem
				{
					Item = "Herbalism kit, gold, and time."
				});
				List<StringListItem> Resolution = new List<StringListItem>();
				Resolution.Add(new StringListItem
				{
					Item = "No roll. Potion made depends on gold and time invested"
				});



				Downtime downtime;
				downtime = new Downtime
				{
					Name = "Brewing a Potion of Healing",
					Status = true,
					Resources = Resources,
					Resolution = Resolution,
					Achievements = new List<Achievement>()
				};

				DowntimeTable ResTable = new DowntimeTable
				{
					Name = "Potion Brewing Table",
					HasHead = true,
					DowntimeParent = downtime

				};
				List<DowntimeTableRow> ResRow = new List<DowntimeTableRow>
				{
					new DowntimeTableRow(),
					new DowntimeTableRow(),
					new DowntimeTableRow(),
					new DowntimeTableRow(),
					new DowntimeTableRow()
				};

				ResRow[0].Row = new List<StringListItem>
				{
					new StringListItem { Item = "Potion Type" },
					new StringListItem { Item = "Downtime" },
					new StringListItem { Item = "Gold Cost" }
				};
				ResRow[1].Row = new List<StringListItem>
				{
					new StringListItem { Item = "Potion of Healing" },
					new StringListItem { Item = "One Day" },
					new StringListItem { Item = "25 gp" }
				};
				ResRow[2].Row = new List<StringListItem>
				{
					new StringListItem { Item = "Potion of Greater Healing" },
					new StringListItem { Item = "One Workweek" },
					new StringListItem { Item = "100 gp" }
				};
				ResRow[3].Row = new List<StringListItem>
				{
					new StringListItem { Item = "Potion of Superior Healing" },
					new StringListItem { Item = "Three Workweeks" },
					new StringListItem { Item = "1,000 gp" }
				};
				ResRow[4].Row = new List<StringListItem>
				{
					new StringListItem { Item = "Potion of Supreme Healing" },
					new StringListItem { Item = "Four Workweeks" },
					new StringListItem { Item = "5,000 gp" }
				};

				ResTable.Table = ResRow;

				downtime.Tables = new List<DowntimeTable>
				{
					ResTable
				};

				List<StringListItem> Resources2 = new List<StringListItem>();
				Resources2.Add(new StringListItem
				{
					Item = "At least one workweek"
				});
				Resources2.Add(new StringListItem
				{
					Item = "100 GP, probably more"
				});
				Resources2.Add(new StringListItem
				{
					Item = "One workweek is needed per specific item being purchased."
				});
				Resources2.Add(new StringListItem
				{
					Item = "Availability is dependent on price and what exists in the shop. "
				});

				List<StringListItem> Resolution2 = new List<StringListItem>();
				Resolution2.Add(new StringListItem
				{
					Item = "Player makes a Charisma (Persuasion) check."
				});
				Resolution2.Add(new StringListItem
				{
					Item = "+1 bonus for each workweek."
				});
				Resolution2.Add(new StringListItem
				{
					Item = "+1 bonus for each 100 gp."
				});
				Resolution2.Add(new StringListItem
				{
					Item = "Max total bonus +6."
				});

				Downtime downtime2 = new Downtime
				{
					Name = "Buying a Magic Item",
					Status = true,
					Resources = Resources2,
					Resolution = Resolution2,
					Achievements = new List<Achievement>()
				};
				Rank bronze = new Rank
				{
					Name = "Bronze",
					Level = 0,
					Color = "#F8F8F8",
					BgColor = "#CD7F32"
				};
				Rank silver = new Rank
				{
					Name = "Silver",
					Level = 1,
					Color = "#101010",
					BgColor = "#BEC2CB"
				};
				Rank gold = new Rank
				{
					Name = "Gold",
					Level = 2,
					Color = "#F8F8F8",
					BgColor = "#D4AF37"
				};
				Rank platinum = new Rank
				{
					Name = "Platinum",
					Level = 3,
					Color = "#101010",
					BgColor = "#9DD9F3"
				};
				Rank diamond = new Rank
				{
					Name = "Diamond",
					Level = 4,
					Color = "#101010",
					BgColor = "#E6E6FA"
				};
				Rank restricted = new Rank
				{
					Name = "Restricted",
					Level = 5,
					Color = "#101010",
					BgColor = "#FF0800"
				};
				Rank banned = new Rank
				{
					Name = "Banned",
					Level = 6,
					Color = "#FF0800",
					BgColor = "#101010"
				};

				context.Ranks.Add(bronze);
				context.Ranks.Add(silver);
				context.Ranks.Add(gold);
				context.Ranks.Add(platinum);
				context.Ranks.Add(diamond);
				context.Ranks.Add(restricted);
				context.Ranks.Add(banned);

				Achievement achieve = new Achievement
				{
					Name = "Ye Olde Magic Shoppe I",
					IsHidden = false,
					Benefit = "Unlock magic shop and have 1d3-2 rank bronze magic items are available for purchase from Haven at the beginning of each session",
					AchievementProgress = new List<AchievementProgress>
					{
						new AchievementProgress
						{
                            Criteria = "Rescue NPC who will open shop",
                            Goal = 1,
							Progress = 1
						}
					},
					Level = bronze,
					IsUnlocked = true
				};
				downtime2.Achievements = downtime2.Achievements.Append(achieve);

				achieve = new Achievement
				{
					Name = "Ye Olde Magic Shoppe II",
					IsHidden = false,
					Benefit = "1d3-1 rank bronze magic items are available for purchase from the Haven at the beginning of each session (NOTE: This replaces Ye Olde Magick Shoppe I)",
                    AchievementProgress = new List<AchievementProgress>
                    {
                        new AchievementProgress
                        {
                            Criteria = "Invest 1,500 gold in the Arcanist",
                            Goal = 1500,
                            Progress = 1500
                        }
                    },
                    Level = silver,
					IsUnlocked = true
				};
				downtime2.Achievements = downtime2.Achievements.Append(achieve).ToList();

                achieve = new Achievement
                {
                    Name = "Ye Olde Magic Shoppe Ultimate",
                    IsHidden = false,
                    Benefit = "This is a test achievement that gives people free magic items of any rarity",       
                    AchievementProgress = new List<AchievementProgress>
                    {
                        new AchievementProgress
                        {
                            Criteria = "Invest 1000000 gold in the Arcanist",
                            Goal = 300000,
                            Progress = 10000
                        },
                        new AchievementProgress
                        {
                            Criteria = "Kill 5 gods",
                            Goal = 5,
                            Progress = 2
                        },
                        new AchievementProgress
                        {
                            Criteria = "Have a wedding",
                            Goal = 1,
                            Progress = 0
                        }
                    },
                    Level = bronze,
                    IsUnlocked = false
                };
                downtime2.Achievements = downtime2.Achievements.Append(achieve).ToList();

				achieve = new Achievement
				{
					Name = "Ye Olde Magic Shoppe Ultimate",
					IsHidden = false,
					Benefit = "This is a test achievement that gives people free magic items of any rarity",
					AchievementProgress = new List<AchievementProgress>
					{
						new AchievementProgress
						{
							Criteria = "Invest 1000000 gold in the Arcanist",
							Goal = 300000,
							Progress = 10000
						},
						new AchievementProgress
						{
							Criteria = "Kill 5 gods",
							Goal = 5,
							Progress = 2
						},
						new AchievementProgress
						{
							Criteria = "Have a wedding",
							Goal = 1,
							Progress = 0
						}
					},
					Level = gold,
					IsUnlocked = false
				};
				downtime2.Achievements = downtime2.Achievements.Append(achieve).ToList();

				achieve = new Achievement
				{
					Name = "Ye Olde Magic Shoppe Ultimate",
					IsHidden = false,
					Benefit = "This is a test achievement that gives people free magic items of any rarity",
					AchievementProgress = new List<AchievementProgress>
					{
						new AchievementProgress
						{
							Criteria = "Invest 1000000 gold in the Arcanist",
							Goal = 300000,
							Progress = 10000
						},
						new AchievementProgress
						{
							Criteria = "Kill 5 gods",
							Goal = 5,
							Progress = 2
						},
						new AchievementProgress
						{
							Criteria = "Have a wedding",
							Goal = 1,
							Progress = 0
						}
					},
					Level = platinum,
					IsUnlocked = false
				};
				downtime2.Achievements = downtime2.Achievements.Append(achieve).ToList();

				achieve = new Achievement
				{
					Name = "Ye Olde Magic Shoppe Ultimate",
					IsHidden = false,
					Benefit = "This is a test achievement that gives people free magic items of any rarity",
					AchievementProgress = new List<AchievementProgress>
					{
						new AchievementProgress
						{
							Criteria = "Invest 1000000 gold in the Arcanist",
							Goal = 300000,
							Progress = 300000
						},
						new AchievementProgress
						{
							Criteria = "Kill 5 gods",
							Goal = 5,
							Progress = 2
						},
						new AchievementProgress
						{
							Criteria = "Have a wedding",
							Goal = 1,
							Progress = 1
						}
					},
					Level = diamond,
					IsUnlocked = false
				};
				downtime2.Achievements = downtime2.Achievements.Append(achieve).ToList();

				DowntimeTable ResTable2 = new DowntimeTable
				{
					Name = "Magic Item Cost Table",
					HasHead = true,
					DowntimeParent = downtime2
				};

				List<DowntimeTableRow> ResRow2 = new List<DowntimeTableRow>
				{
					new DowntimeTableRow(),
					new DowntimeTableRow(),
					new DowntimeTableRow(),
					new DowntimeTableRow(),
					new DowntimeTableRow(),
					new DowntimeTableRow()
				};

				ResRow2[0].Row = new List<StringListItem>
				{
					new StringListItem {Item = "Roll" },
					new StringListItem {Item = "Item Cost" },
				};
				ResRow2[1].Row = new List<StringListItem>
				{
					new StringListItem {Item = "1-5" },
					new StringListItem { Item = "+25%" },
				};
				ResRow2[2].Row = new List<StringListItem>
				{
					new StringListItem { Item = "6-10" },
					new StringListItem { Item = "+15%" },
				};
				ResRow2[3].Row = new List<StringListItem>
				{
					new StringListItem { Item = "11-15" },
					new StringListItem { Item = "+0%" },
				};
				ResRow2[4].Row = new List<StringListItem>
				{
					new StringListItem { Item = "16-20" },
					new StringListItem { Item = "-15%" },
				};
				ResRow2[5].Row = new List<StringListItem>
				{
					new StringListItem { Item = "21+" },
					new StringListItem { Item = "-25%" },
				};

				ResTable2.Table = ResRow2;

				downtime2.Tables = new List<DowntimeTable>
				{
					ResTable2
				};

				context.Downtime.Add(downtime);
				context.Downtime.Add(downtime2);
				context.SaveChanges();
			}
		}

		public object GetService(Type serviceType)
		{
			throw new NotImplementedException();
		}
	}
}
