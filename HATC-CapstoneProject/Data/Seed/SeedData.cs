namespace HATC_CapstoneProject.Data.Seed
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
                Player user1 = new()
                {
                    UserName = "root"
                };
                userManager.CreateAsync(user1, PASSWORD);



                context.SaveChanges();

            }
        }
        public static void Seed2(HavenDbContext context, IServiceProvider provider)
        {
            if (!context.Downtime.Any())
            {


                // Generate downtime
                List<StringListItem> Resources = new()
                {
                    new StringListItem
                    {
                        Item = "Herbalism kit, gold, and time."
                    }
                };
                List<StringListItem> Resolution = new()
                {
                    new StringListItem
                    {
                        Item = "No roll. Potion made depends on gold and time invested"
                    }
                };



                Downtime downtime;
                downtime = new Downtime
                {
                    Name = "Brewing a Potion of Healing",
                    Status = true,
                    Resources = Resources,
                    Resolution = Resolution,
                    Achievements = new List<Achievement>()
                };

                DowntimeTable ResTable = new()
                {
                    Name = "Potion Brewing Table",
                    HasHead = true

                };
                List<DowntimeTableRow> ResRow = new()
                {
                    new DowntimeTableRow(),
                    new DowntimeTableRow(),
                    new DowntimeTableRow(),
                    new DowntimeTableRow(),
                    new DowntimeTableRow()
                };

                ResRow[0].Row = new List<TableListItem>
                {
                    new TableListItem { Item = "Potion Type", Index = 0 },
                    new TableListItem { Item = "Downtime", Index = 1 },
                    new TableListItem { Item = "Gold Cost", Index = 2 }
                };
                ResRow[1].Row = new List<TableListItem>
                {
                    new TableListItem { Item = "Potion of Healing", Index = 0 },
                    new TableListItem { Item = "One Day", Index = 1 },
                    new TableListItem { Item = "25 gp", Index = 2 }
                };
                ResRow[2].Row = new List<TableListItem>
                {
                    new TableListItem { Item = "Potion of Greater Healing" , Index = 0},
                    new TableListItem { Item = "One Workweek", Index = 1 } , new TableListItem { Item = "100 gp", Index = 2 }
                };
                ResRow[3].Row = new List<TableListItem>
                {
                    new TableListItem { Item = "Potion of Superior Healing" , Index = 0},
                    new TableListItem { Item = "Three Workweeks", Index = 1 } , new TableListItem { Item = "1,000 gp", Index = 2 }
                };
                ResRow[4].Row = new List<TableListItem>
                {
                    new TableListItem { Item = "Potion of Supreme Healing" , Index = 0},
                    new TableListItem { Item = "Four Workweeks", Index = 1 } , new TableListItem { Item = "5,000 gp", Index = 2 }
                };

                ResTable.Table = ResRow;

                downtime.Tables = new List<DowntimeTable>
                {
                    ResTable
                };

                List<StringListItem> Resources2 = new()
                {
                    new StringListItem
                    {
                        Item = "At least one workweek"
                    },
                    new StringListItem
                    {
                        Item = "100 GP, probably more"
                    },
                    new StringListItem
                    {
                        Item = "One workweek is needed per specific item being purchased."
                    },
                    new StringListItem
                    {
                        Item = "Availability is dependent on price and what exists in the shop. "
                    }
                };

                List<StringListItem> Resolution2 = new()
                {
                    new StringListItem
                    {
                        Item = "Player makes a Charisma (Persuasion) check."
                    },
                    new StringListItem
                    {
                        Item = "+1 bonus for each workweek."
                    },
                    new StringListItem
                    {
                        Item = "+1 bonus for each 100 gp."
                    },
                    new StringListItem
                    {
                        Item = "Max total bonus +6."
                    }
                };

                Downtime downtime2 = new()
                {
                    Name = "Buying a Magic Item",
                    Status = true,
                    Resources = Resources2,
                    Resolution = Resolution2,
                    Achievements = new List<Achievement>()
                };
                Rank bronze = new()
                {
                    Name = "Bronze",
                    Level = 0,
                    Color = "#F8F8F8",
                    BgColor = "#CD7F32"
                };
                Rank silver = new()
                {
                    Name = "Silver",
                    Level = 1,
                    Color = "#101010",
                    BgColor = "#BEC2CB"
                };
                Rank gold = new()
                {
                    Name = "Gold",
                    Level = 2,
                    Color = "#F8F8F8",
                    BgColor = "#D4AF37"
                };
                Rank platinum = new()
                {
                    Name = "Platinum",
                    Level = 3,
                    Color = "#101010",
                    BgColor = "#9DD9F3"
                };
                Rank diamond = new()
                {
                    Name = "Diamond",
                    Level = 4,
                    Color = "#101010",
                    BgColor = "#E6E6FA"
                };
                Rank restricted = new()
                {
                    Name = "Restricted",
                    Level = 5,
                    Color = "#101010",
                    BgColor = "#FF0800"
                };
                Rank banned = new()
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

                Achievement achieve = new()
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
                    IsUnlocked = true,
                    IsMasked = true
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

                DowntimeTable ResTable2 = new()
                {
                    Name = "Magic Item Cost Table",
                    HasHead = true
                };

                List<DowntimeTableRow> ResRow2 = new()
                {
                    new DowntimeTableRow(),
                    new DowntimeTableRow(),
                    new DowntimeTableRow(),
                    new DowntimeTableRow(),
                    new DowntimeTableRow(),
                    new DowntimeTableRow()
                };

                ResRow2[0].Row = new List<TableListItem>
                {
                    new TableListItem {Item = "Roll", Index = 0  },
                    new TableListItem {Item = "Item Cost", Index = 1  },
                };
                ResRow2[1].Row = new List<TableListItem>
                {
                    new TableListItem {Item = "1-5", Index = 0  },
                    new TableListItem { Item = "+25%", Index = 1  },
                };
                ResRow2[2].Row = new List<TableListItem>
                {
                    new TableListItem { Item = "6-10", Index = 0  },
                    new TableListItem { Item = "+15%", Index = 1  },
                };
                ResRow2[3].Row = new List<TableListItem>
                {
                    new TableListItem { Item = "11-15", Index = 0  },
                    new TableListItem { Item = "+0%", Index = 1  },
                };
                ResRow2[4].Row = new List<TableListItem>
                {
                    new TableListItem { Item = "16-20", Index = 0  },
                    new TableListItem { Item = "-15%" , Index = 1 },
                };
                ResRow2[5].Row = new List<TableListItem>
                {
                    new TableListItem { Item = "21+", Index = 0  },
                    new TableListItem { Item = "-25%", Index = 1  },
                };

                ResTable2.Table = ResRow2;


                DowntimeTable ResTable3 = new()
                {
                    Name = "Magic Item Complication Table",
                    HasHead = true,
                    IsComplication = true
                };

                List<DowntimeTableRow> ResRow3 = new()
                {
                    new DowntimeTableRow(),
                    new DowntimeTableRow(),
                    new DowntimeTableRow(),
                    new DowntimeTableRow(),
                    new DowntimeTableRow(),
                    new DowntimeTableRow(),
                    new DowntimeTableRow(),
                    new DowntimeTableRow(),
                    new DowntimeTableRow(),
                    new DowntimeTableRow(),
                    new DowntimeTableRow(),
                    new DowntimeTableRow(),
                    new DowntimeTableRow()
                };

                ResRow3[0].Row = new List<TableListItem>
                {
                    new TableListItem {Item = "d12", Index = 0 },
                    new TableListItem {Item = "Buying Magical Item Complication", Index = 1 },
                };
                ResRow3[1].Row = new List<TableListItem>
                {
                    new TableListItem {Item = "1", Index = 0 },
                    new TableListItem {Item = "The item is stolen before the sale.", Index = 1 },
                };
                ResRow3[2].Row = new List<TableListItem>
                {
                    new TableListItem {Item = "2", Index = 0 },
                    new TableListItem {Item = "A third party bids on the item, doubling its price.", Index = 1 },
                };
                ResRow3[3].Row = new List<TableListItem>
                {
                    new TableListItem {Item = "3", Index = 0 },
                    new TableListItem {Item = "You get the last available stock of the item, angering a wealthy noble who also wanted it.", Index = 1 },
                };
                ResRow3[4].Row = new List<TableListItem>
                {
                    new TableListItem {Item = "4", Index = 0 },
                    new TableListItem {Item = "The item's original owner will kill to reclaim it; the party's enemies spread news of its sale.*", Index = 1 },
                };
                ResRow3[5].Row = new List<TableListItem>
                {
                    new TableListItem {Item = "5", Index = 0 },
                    new TableListItem {Item = "The item is tied to a cult." , Index = 1},
                };
                ResRow3[6].Row = new List<TableListItem>
                {
                    new TableListItem {Item = "6" , Index = 0},
                    new TableListItem {Item = "The seller is murdered before the sale.*" , Index = 1},
                };
                ResRow3[7].Row = new List<TableListItem>
                {
                    new TableListItem {Item = "7" , Index = 0},
                    new TableListItem {Item = "The seller is looking for an additional favor along with the  sale of this item. (Can be tied to quest or other long term goal)" , Index = 1},
                };
                ResRow3[8].Row = new List<TableListItem>
                {
                    new TableListItem {Item = "8" , Index = 0},
                    new TableListItem {Item = "The shopkeep takes a liking to you and wants to share their absurd theories about the nature of magic." , Index = 1},
                };
                ResRow3[9].Row = new List<TableListItem>
                {
                    new TableListItem {Item = "9" , Index = 0},
                    new TableListItem {Item = "The chatty seller wants to hear the latest juicy gossip about Haven. They may or may not spread this gossip around to others on their path. " , Index = 1},
                };
                ResRow3[10].Row = new List<TableListItem>
                {
                    new TableListItem {Item = "10" , Index = 0},
                    new TableListItem {Item = "The item is garish and unappealingly shaped or colored." , Index = 1},
                };
                ResRow3[11].Row = new List<TableListItem>
                {
                    new TableListItem {Item = "11" , Index = 0},
                    new TableListItem {Item = "The item has an unfortunate odor or is covered in something gross, and needs to be washed before its used." , Index = 1},
                };
                ResRow3[12].Row = new List<TableListItem>
                {
                    new TableListItem {Item = "12" , Index = 0},
                    new TableListItem {Item = "The item’s maker mark is prominent and magically prevents it from ever being obscured, whether or not that is a good thing remains to be seen." , Index = 1},
                };

                ResTable3.Table = ResRow3;

                downtime2.Tables = new List<DowntimeTable>
                {
                    ResTable2,
                    ResTable3
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
                NPC ffredd = new()
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
                NPC ttedd = new()
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

                FactionShop shop = new()
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
                FactionShop shop2 = new()
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
                FactionShop shop3 = new()
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
                FactionShop shop4 = new()
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

                FactionPerk perk = new()
                {
                    Renown = 10,
                    Item = "You are granted proficiency with F.U.T.U.R.E.’s Disguise Kit.",
                    IsLocked = false
                };
                FactionPerk perk2 = new()
                {
                    Renown = 30,
                    Item = "Add 1d4 to F.U.T.U.R.E. Disguise Kit and 1d4 to either Deception or Sleight of Hand checks, the skill chosen when 30 renown is reached. ",
                    IsLocked = false
                };
                FactionPerk perk3 = new()
                {
                    Renown = 60,
                    Item = "The bonus granted by the Renown 30 perk grows to 1d6.\r\n\r\nFor each venture out of Haven, you get an F.U.T.U.R.E. charm. This is returned to the faction at the end of a session if not used.\r\nF.U.T.U.R.E Charm\r\nWhen you activate this charm, you can cast the Charm Person or Enemies Abound  spells, with a save DC of 15. Alternatively, when you make a Deception, Intimidation, Performance or Persuasion check, you can replace the number rolled on the d20 with a 10. You can do this after seeing the roll, but before the DM says what the result is.\r\nAfter being used in any of these ways, the charm vanishes..",
                    IsLocked = false

                };
                FactionPerk perk4 = new()
                {
                    Renown = 100,
                    Item = "You are granted proficiency with F.U.T.U.R.E.’s Disguise Kit.",
                    IsLocked = true
                };

                Faction faction = new()
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

                Faction faction2 = new()
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

                Faction faction3 = new()
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

                Faction faction4 = new()
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

                Faction faction5 = new()
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

        public static void Seed4(HavenDbContext context, IServiceProvider provider)
        {
            if (!context.Shop.Any())
            {
                List<Rank> rarities = context.Ranks
                    .OrderBy(rank => rank.Level)
                    .ToList();

                ShopItem item1 = new()
                {
                    Name = "Ammunition +1 (20)",
                    Value = 500,
                    Source = "DMG",
                    Rarity = rarities[0],
                    IsAttunement = false,
                    IsShoppable = true,
                    IsCraftable = true
                };
                ShopItem item2 = new()
                {
                    Name = "Armor, +3",
                    Value = 100000,
                    Source = "DMG",
                    Rarity = rarities[4],
                    IsAttunement = false,
                    IsShoppable = false,
                    IsCraftable = true
                };
                ShopItem item3 = new()
                {
                    Name = "Absorbing Tattoo",
                    Value = 35000,
                    Source = "TCE",
                    Rarity = rarities[2],
                    IsAttunement = true,
                    IsShoppable = true,
                    IsCraftable = true
                };
                ShopItem item4 = new()
                {
                    Name = "Amethyst Lodestone",
                    Value = 78000,
                    Source = "FTD",
                    Rarity = rarities[3],
                    IsAttunement = true,
                    IsShoppable = false,
                    IsCraftable = true
                };
                ShopItem item5 = new()
                {
                    Name = "Abracadabrus",
                    Value = 0,
                    Source = "IDRotF",
                    Rarity = rarities[6],
                    IsAttunement = false,
                    IsShoppable = false,
                    IsCraftable = false
                };
                ShopItem item6 = new()
                {
                    Name = "Apparatus of Kwalish",
                    Value = 0,
                    Source = "DMG",
                    Rarity = rarities[5],
                    IsAttunement = false,
                    IsShoppable = false,
                    IsCraftable = false
                };
                context.Shop.Add(item1);
                context.Shop.Add(item2);
                context.Shop.Add(item3);
                context.Shop.Add(item4);
                context.Shop.Add(item5);
                context.Shop.Add(item6);
                context.SaveChanges();
            }
        }

        public static async void Seed5(HavenDbContext context, IServiceProvider provider)
        {
            if (!context.Characters.Any())
            {
                if (context.Players.Any())
                {
                    if (context.Factions.Any())
                    {
                        List<Faction> factions = context.Factions
                                                    .Include(faction => faction.Members)
                                                    .Include(faction => faction.Members)
                                                        .ThenInclude(npc => npc.AdventureHooks)
                                                    .Include(faction => faction.Members)
                                                        .ThenInclude(npc => npc.Interactions)
                                                    .Include(faction => faction.Shops)
                                                        .ThenInclude(shops => shops.List)
                                                    .Include(faction => faction.Perks)
                                                        .OrderBy(faction => faction.Name)
                                                        .ToList();

                        List<FactionCardEntry> facEntry = new();
                        List<FactionCardEntry> facEntry2 = new();
                        List<FactionCardEntry> facEntry3 = new();

                        foreach (Faction fac in factions)
                        {
                            facEntry.Add(new FactionCardEntry
                            {
                                Fac = fac
                            });
                            facEntry2.Add(new FactionCardEntry
                            {
                                Fac = fac
                            });
                            facEntry3.Add(new FactionCardEntry
                            {
                                Fac = fac
                            });
                        }


                        Player user = context.Players.FirstOrDefault();

                        Character char1 = new()
                        {
                            Player = user,
                            Name = "Tassa",
                            Description = "This is a description of Tassa",
                            FactionPoints = new FactionCard
                            {
                                FactionPoints = facEntry
                            }
                        };
                        Character char2 = new()
                        {
                            Player = user,
                            Name = "Erabrix",
                            Description = "This is a description of Erabrix",
                            FactionPoints = new FactionCard
                            {
                                FactionPoints = facEntry
                            }
                        };
                        Character char3 = new()
                        {
                            Player = user,
                            Name = "Ildia",
                            Description = "This is a description of Ildia",
                            FactionPoints = new FactionCard
                            {
                                FactionPoints = facEntry
                            }
                        };

                        context.Characters.Add(char1);
                        context.Characters.Add(char2);
                        context.Characters.Add(char3);
                        context.SaveChanges();
                    }
                }
            }
        }
        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }
    }
}
