using UnityEngine;
using ShatteredPath.Items.Data;
using ShatteredPath.Items.Runtime;
using System.Collections.Generic;
using ShatteredPath.Stats.Data;

namespace ShatteredPath.Items.Runtime.Builders
{
    public static class ItemBuilder
    {
        public static ItemInstance Build(BaseItemDefinition definition)
        {
            ItemInstance item = new ItemInstance(definition);

            RollPrefix(item, definition.ItemPool.PrefixPool);
            RollSuffix(item, definition.ItemPool.SuffixPool);

            // RollBaseStats(item);

            item.RecalculateLocalStats();

            return item;
        }

        // private static void RollBaseStats(ItemInstance item)
        // {
        //     // Temporary.
        //     // The ItemInstance constructor already copied the BaseStats.
        //     // Later this method will roll min/max values.
        // }

        private static void RollPrefix(ItemInstance item, PrefixPoolDefinition pool)
        {
            PrefixTierListDefinition tierList = RollRandom(item.Definition.ItemPool.PrefixPool.TierLists);

            if (tierList != null)
            {
                TierDefinition tier =
                    RollTier(
                        tierList,
                        item.Definition.ItemLevel);

                if (tier != null)
                {
                    AffixInstance prefix =
                        CreateAffix(
                            tierList,
                            tier);

                    item.AddPrefix(prefix);
                }
            }
        }

        private static void RollSuffix(ItemInstance item, SuffixPoolDefinition pool)
        {
            SuffixTierListDefinition tierList = RollRandom(item.Definition.ItemPool.SuffixPool.TierLists);

            if (tierList != null)
            {
                TierDefinition tier = RollTier(tierList, item.Definition.ItemLevel);

                if (tier != null)
                {
                    AffixInstance suffix = CreateAffix(tierList, tier);

                    item.AddSuffix(suffix);
                }
            }
        }

        // private static void RollAffix(ItemInstance item, AffixPoolDefinition pool)
        // {
        //     if (pool == null)
        //     {
        //         return;
        //     }

        //     if (pool.Affixes.Count == 0)
        //     {
        //         return;
        //     }

        //     AffixDefinition affix = RollWeightedAffix(pool, item.Definition.ItemLevel);

        //     if (affix == null)
        //     {
        //         return;
        //     }

        //     item.AddAffix(affix);
        // }

        private static T RollRandom<T>(IReadOnlyList<T> list)
        {
            if (list == null || list.Count == 0)
            {
                return default;
            }

            return list[Random.Range(0, list.Count)];
        }

        // private static AffixDefinition RollWeightedAffix(AffixPoolDefinition pool, int itemLevel)
        // {
        //     List<AffixDefinition> validAffixes = new List<AffixDefinition>();

        //     int totalWeight = 0;

        //     foreach (AffixDefinition affix in pool.Affixes)
        //     {
        //         if (affix.RequiredLevel > itemLevel)
        //         {
        //             continue;
        //         }

        //         validAffixes.Add(affix);
        //         totalWeight += affix.Weight;
        //     }

        //     if (validAffixes.Count == 0)
        //     {
        //         return null;
        //     }

        //     int roll = Random.Range(0, totalWeight);

        //     foreach (AffixDefinition affix in validAffixes)
        //     {
        //         roll -= affix.Weight;

        //         if (roll < 0)
        //         {
        //             return affix;
        //         }
        //     }

        //     return validAffixes[validAffixes.Count - 1];
        // }

        private static PrefixTierListDefinition RollTierList(PrefixPoolDefinition pool)
        {
            if (pool == null)
            {
                return null;
            }

            if (pool.TierLists.Count == 0)
            {
                return null;
            }

            int index = Random.Range(0, pool.TierLists.Count);

            return pool.TierLists[index];
        }

        private static TierDefinition RollTier(AffixTierListDefinition tierList, int itemLevel)
        {
            List<TierDefinition> validTiers =
                new List<TierDefinition>();

            int totalWeight = 0;

            foreach (TierDefinition tier in tierList.Tiers)
            {
                if (tier.RequiredItemLevel > itemLevel)
                {
                    continue;
                }

                validTiers.Add(tier);
                totalWeight += tier.Weight;
            }

            if (validTiers.Count == 0)
            {
                return null;
            }

            int roll = Random.Range(0, totalWeight);

            foreach (TierDefinition tier in validTiers)
            {
                roll -= tier.Weight;

                if (roll < 0)
                {
                    return tier;
                }
            }

            return validTiers[validTiers.Count - 1];
        }

        private static AffixInstance CreateAffix(AffixTierListDefinition tierList, TierDefinition tier)
        {
            float rolledValue = RollModifierValue(tierList.ModifierOperation, tier.MinimumValue, tier.MaximumValue);

            return new AffixInstance(
                tierList,
                tier,
                rolledValue);
        }

        private static float RollModifierValue(ModifierOperation operation, float minimumValue, float maximumValue)
        {
            if (minimumValue > maximumValue)
            {
                (minimumValue, maximumValue) = (maximumValue, minimumValue);
            }

            switch (operation)
            {
                case ModifierOperation.Flat:
                    return Random.Range(
                        Mathf.RoundToInt(minimumValue),
                        Mathf.RoundToInt(maximumValue) + 1);

                case ModifierOperation.Additive:
                case ModifierOperation.Multiplicative:
                    return Mathf.Round(
                        Random.Range(minimumValue, maximumValue) * 100f) / 100f;

                default:
                    return minimumValue;
            }
        }
    }
}