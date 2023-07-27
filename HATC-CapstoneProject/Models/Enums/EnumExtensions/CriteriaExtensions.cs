namespace HATC_CapstoneProject.Models.Enums.EnumExtensions
{
    public static class CriteriaExtensions
    {
        /// <summary>
        /// Convert a <see cref="Criteria"/> enum into it's corresponding <see cref="Rarity"/> enum type if the given Criteria is more 8 or greater.
        /// Branze, Silver, Gold, Restricted, Banned
        /// </summary>
        /// <param name="criteria">the criteria to convert</param>
        /// <returns>the converted Rarity or Rarity.None if it does not exist</returns>
        public static Rarity ConvertToRarity(this Criteria criteria)
        {
            if (criteria >= Criteria.Bronze)
            {
                return (Rarity)criteria;
            }
            return Rarity.None;
        }

        /// <summary>
        /// Convert a given Rank into it corresponding <see cref="Rarity"/> enum
        /// </summary>
        /// <param name="rank">the rank instance to convert to it's related Rarity</param>
        /// <returns></returns>
        public static Rarity ConvertToRarity(this Rank rank)
        {
            if (Enum.TryParse(rank.Name, out Rarity rarity))
            {
                return rarity;
            }
            return Rarity.None;

        }

    }
}
