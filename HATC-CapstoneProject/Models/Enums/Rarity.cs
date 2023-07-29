namespace HATC_CapstoneProject.Models.Enums;

[Flags]
public enum Rarity
{
    None = 0,
    Bronze = 8,
    Silver = 16,
    Gold = 32,
    Platinum = 64,
    Diamond = 128,
    Restricted = 256,
    Banned = 512,
    All = Bronze | Silver | Gold | Platinum | Diamond | Restricted | Banned,
}
