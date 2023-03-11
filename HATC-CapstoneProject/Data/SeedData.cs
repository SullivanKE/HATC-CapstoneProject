using HATC_CapstoneProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
		public static void Seed3(HavenDbContext context, IServiceProvider provider)
		{
			if (!context.Factions.Any())
			{
				NPC ffredd = new NPC
				{
					Name = "Ffredd",
					Image = "../uploads/images/ffredd.webp",
					Description = "Goliath who makes a living by showing up at businesses and forcing them to buy whatever stuff he has decided to collect and sell to them",
					Personality = "Pushy, Intimidating, opportunistic",
					Motivation = "Selling items to PCs",
					Apperance = "Goliath man",
					Background = "Merchant",
					Quirk = "This is the quirk field",
					Interactions = new List<StringListItem>
						{
							new StringListItem
							{
								Item = "Tried to sell a wagon full of random stuff he’d found in the woods to Mahvi at Foraged and Foretold.",
							},
							new StringListItem
							{
								Item = "He acts as a constant threat during downtime.",
							},
							new StringListItem
							{
								Item = "Could easily do similar things with other types of “findings” to others.",
							}
						},
					AdventureHooks = new List<StringListItem>
						{
							new StringListItem
							{
								Item = "We could have an adventure to run Ffredd out of town."
							},
							new StringListItem
							{
								Item = "Ffredd learns the power of friendship."
							},
							new StringListItem
							{
								Item = "Part of the hidden fake quest to reach the deepest parts of the ruins."
							}
						},
					Notes = "Better dead than Ffredd"
				};
				NPC ttedd = new NPC
				{
					Name = "Ttedd",
					Image = "/uploads/images/ffredd.webp",
					Description = "Goliath who makes a living by showing up at businesses and forcing them to buy whatever stuff he has decided to collect and sell to them",
					Personality = "Pushy, Intimidating, opportunistic",
					Motivation = "Selling items to PCs",
					Apperance = "Goliath man",
					Background = "Merchant",
					Quirk = "This is the quirk field",
					Interactions = new List<StringListItem>
						{
							new StringListItem
							{
								Item = "Tried to sell a wagon full of random stuff he’d found in the woods to Mahvi at Foraged and Foretold.",
							},
							new StringListItem
							{
								Item = "He acts as a constant threat during downtime.",
							},
							new StringListItem
							{
								Item = "Could easily do similar things with other types of “findings” to others.",
							}
						},
					AdventureHooks = new List<StringListItem>
						{
							new StringListItem
							{
								Item = "We could have an adventure to run Ffredd out of town."
							},
							new StringListItem
							{
								Item = "Ffredd learns the power of friendship."
							},
							new StringListItem
							{
								Item = "Part of the hidden fake quest to reach the deepest parts of the ruins."
							}
						},
					Notes = "Better dead than Ffredd"
				};

				FactionShop shop = new FactionShop
				{
					Cost = 1,
					List = new List<StringListItem>
				{
					new StringListItem
					{
						Item = "Acid"
					},
					new StringListItem
					{
						Item = "Basic Poison"
					},
					new StringListItem
					{
						Item = "Alchemist Fire"
					},
					new StringListItem
					{
						Item = "Antivenom"
					}
				}
				};
				FactionShop shop2 = new FactionShop
				{
					Cost = 5,
					List = new List<StringListItem>
				{
					new StringListItem
					{
						Item = "Acid"
					},
					new StringListItem
					{
						Item = "Basic Poison"
					},
					new StringListItem
					{
						Item = "Alchemist Fire"
					},
					new StringListItem
					{
						Item = "Antivenom"
					}
				}
				};
				FactionShop shop3 = new FactionShop
				{

					Cost = 10,
					List = new List<StringListItem>
				{
					new StringListItem
					{
						Item = "Acid"
					},
					new StringListItem
					{
						Item = "Basic Poison"
					},
					new StringListItem
					{
						Item = "Alchemist Fire"
					},
					new StringListItem
					{
						Item = "Antivenom"
					}
				}
				};
				FactionShop shop4 = new FactionShop
				{
					Cost = 15,
					List = new List<StringListItem>
				{
					new StringListItem
					{
						Item = "Acid"
					},
					new StringListItem
					{
						Item = "Basic Poison"
					},
					new StringListItem
					{
						Item = "Alchemist Fire"
					},
					new StringListItem
					{
						Item = "Antivenom"
					}
				}
				};

				FactionPerk perk = new FactionPerk
				{
					Renown = 10,
					Item = "You are granted proficiency with F.U.T.U.R.E.’s Disguise Kit.",
					IsLocked = false
				};
				FactionPerk perk2 = new FactionPerk
				{
					Renown = 30,
					Item = "Add 1d4 to F.U.T.U.R.E. Disguise Kit and 1d4 to either Deception or Sleight of Hand checks, the skill chosen when 30 renown is reached. ",
					IsLocked = false
				};
				FactionPerk perk3 = new FactionPerk
				{
					Renown = 60,
					Item = "The bonus granted by the Renown 30 perk grows to 1d6.\r\n\r\nFor each venture out of Haven, you get an F.U.T.U.R.E. charm. This is returned to the faction at the end of a session if not used.\r\nF.U.T.U.R.E Charm\r\nWhen you activate this charm, you can cast the Charm Person or Enemies Abound  spells, with a save DC of 15. Alternatively, when you make a Deception, Intimidation, Performance or Persuasion check, you can replace the number rolled on the d20 with a 10. You can do this after seeing the roll, but before the DM says what the result is.\r\nAfter being used in any of these ways, the charm vanishes..",
					IsLocked = false

				};
				FactionPerk perk4 = new FactionPerk
				{
					Renown = 100,
					Item = "You are granted proficiency with F.U.T.U.R.E.’s Disguise Kit.",
					IsLocked = true
				};

				Faction faction = new Faction
				{
					Name = "FUTURE",
					Description = "F.U.T.U.R.E. is a highly organized and bureaucratic non-governmental agency acting on Haven to ensure the settlement’s prosperity and continual growth. They do this by boosting the local magical item economy through raw materials and simple finished products; and by investing heavily in the local infrastructure and accommodation industries.\r\nThe Foundation strongly believes that what's best for the settlement may not match exactly what is considered correct, legal or moral. They are always in need of adventurers willing to look the other way and who believe that a worthy end goal can justify unsavory means to get there.",
					Members = new List<NPC>
				{
					ffredd, ttedd
				},
					Shops = new List<FactionShop>
				{
					shop,
					shop2,
					shop3,
					shop4
				},
					Perks = new List<FactionPerk>
				{
					perk,
					perk2,
					perk3,
					perk4
				}
				};
				context.Factions.Add(faction);

				Faction faction2 = new Faction
				{
					Name = "Pathfinders Guild",
					Description = "One of the older and more reliable charter guilds this side of the continent, the Pathfinders' Guild both chart out new territory and protect the causeways in between.  A mix between cartographers, archaeologists, and a neighborhood watch, the Pathfinders' Guild are always vying for the opportunity to find the next uncharted expanse or valuable artifact to add to their cache.  Who knows, maybe you could help them in their most noble of pursuits?",
					Members = new List<NPC>
				{
					ffredd, ttedd
				},
					Shops = new List<FactionShop>
				{
					shop,
					shop2,
					shop3,
					shop4
				},
					Perks = new List<FactionPerk>
				{
					perk,
					perk2,
					perk3,
					perk4
				}
				};
				context.Factions.Add(faction2);

				Faction faction3 = new Faction
				{
					Name = "Occurian Order",
					Description = "One of the oldest religious institutions in the known world with international reach: they come to Haven in peace and trust, to seek out religious artifacts, carry out great works, and bring the faith of Sonatheri of the Sun and Khol Kaisaron of the Moons to new horizons.  Open to all, they are willing and able to embrace like-minded adventurers and reward them for a job well done.  Keep the Faith.",
					Members = new List<NPC>
				{
					ffredd, ttedd
				},
					Shops = new List<FactionShop>
				{
					shop,
					shop2,
					shop3,
					shop4
				},
					Perks = new List<FactionPerk>
				{
					perk,
					perk2,
					perk3,
					perk4
				}
				};
				context.Factions.Add(faction3);

				Faction faction4 = new Faction
				{
					Name = "Tharmekhul",
					Description = "In one of the mountain ranges of the Crossroads is the cloistered kingdom of Tharmekhûl. Inhabited mostly but not exclusively by underground dwelling races, the kingdom has been hit hard by the calamity a year ago. The various lawmaking powers: the royalists, parliament, and paragon supporters, all have their own ideas about how to rebuild.",
					Members = new List<NPC>
				{
					ffredd, ttedd
				},
					Shops = new List<FactionShop>
				{
					shop,
					shop2,
					shop3,
					shop4
				},
					Perks = new List<FactionPerk>
				{
					perk,
					perk2,
					perk3,
					perk4
				}
				};
				context.Factions.Add(faction4);

				Faction faction5 = new Faction
				{
					Name = "Green Sleeves",
					Description = "A druidic circle with agents moving into Haven to protect nature from the encroach of civilization as more and more people come to investigate the recently exposed ruins. Green Sleeves defend nature and seek to preserve balance above all else.",
					Members = new List<NPC>
				{
					ffredd, ttedd
				},
					Shops = new List<FactionShop>
				{
					shop,
					shop2,
					shop3,
					shop4
				},
					Perks = new List<FactionPerk>
				{
					perk,
					perk2,
					perk3,
					perk4
				}
				};
				context.Factions.Add(faction5);
				context.SaveChanges();
			}
		}

		public object GetService(Type serviceType)
		{
			throw new NotImplementedException();
		}
	}
}
