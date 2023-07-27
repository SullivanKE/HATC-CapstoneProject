namespace HATC_CapstoneProject.Models.Enums;

[Flags]
public enum Criteria
{
    None = 0,
    Shoppable = 1,
    Craftable = 2,
    Attunable = 4,
    Bronze = Rarity.Bronze,
    Silver = Rarity.Silver,
    Gold = Rarity.Gold,
    Restricted = Rarity.Restricted,
    Banned = Rarity.Banned,
    All = Rarity.All | Shoppable | Craftable | Attunable,
}


