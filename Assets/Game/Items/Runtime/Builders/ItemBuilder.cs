using UnityEngine;
using ShatteredPath.Items.Data;
using ShatteredPath.Items.Runtime;
using System.Collections.Generic;

namespace ShatteredPath.Items.Runtime.Builders
{
    public static class ItemBuilder
    {
        public static ItemInstance Build(BaseItemDefinition definition)
        {
            ItemInstance item = new ItemInstance(definition);

            RollAffix(item, definition.PrefixPool);
            RollAffix(item, definition.SuffixPool);

            RollBaseStats(item);

            item.RecalculateLocalStats();

            return item;
        }

        private static void RollBaseStats(ItemInstance item)
        {
            // Temporary.
            // The ItemInstance constructor already copied the BaseStats.
            // Later this method will roll min/max values.
        }

        private static void RollAffix(ItemInstance item, AffixPoolDefinition pool)
        {
            if (pool == null)
            {
                return;
            }

            if (pool.Affixes.Count == 0)
            {
                return;
            }

            AffixDefinition affix = RollWeightedAffix(pool, item.Definition.ItemLevel);

            if (affix == null)
            {
                return;
            }

            item.AddAffix(affix);
        }

        private static AffixDefinition RollWeightedAffix(AffixPoolDefinition pool, int itemLevel)
        {
            List<AffixDefinition> validAffixes = new List<AffixDefinition>();

            int totalWeight = 0;

            foreach (AffixDefinition affix in pool.Affixes)
            {
                if (affix.RequiredLevel > itemLevel)
                {
                    continue;
                }

                validAffixes.Add(affix);
                totalWeight += affix.Weight;
            }

            if (validAffixes.Count == 0)
            {
                return null;
            }

            int roll = Random.Range(0, totalWeight);

            foreach (AffixDefinition affix in validAffixes)
            {
                roll -= affix.Weight;

                if (roll < 0)
                {
                    return affix;
                }
            }

            return validAffixes[validAffixes.Count - 1];
        }
    }
}