using ShatteredPath.Items.Data;
using ShatteredPath.Items.Runtime;
using ShatteredPath.Items.Runtime.Builders;
using ShatteredPath.Stats.Runtime;
using UnityEngine;

namespace ShatteredPath.Tests
{
    public sealed class ItemBuilderTest : MonoBehaviour
    {
        [SerializeField]
        private BaseItemDefinition itemDefinition;

        private void Start()
        {
            for (int i = 0; i < 10; i++)
            {
                ItemInstance item = ItemBuilder.Build(itemDefinition);

                LogItem(item);
            }
        }

        private static void LogItem(ItemInstance item)
        {
            string message = item.Definition.DisplayName;

            if (item.Prefixes.Count > 0)
            {
                AffixInstance prefix = item.Prefixes[0];

                message +=
                    "\nPrefix: "
                    + prefix.TierList.AffixName
                    + " - "
                    + prefix.Tier.TierName;

                AppendModifiers(
                    ref message,
                    prefix.Modifiers);
            }
            else
            {
                message += "\nPrefix: none";
            }

            if (item.Suffixes.Count > 0)
            {
                AffixInstance suffix = item.Suffixes[0];

                message +=
                    "\nSuffix: "
                    + suffix.TierList.AffixName
                    + " - "
                    + suffix.Tier.TierName;

                AppendModifiers(
                    ref message,
                    suffix.Modifiers);
            }
            else
            {
                message += "\nSuffix: none";
            }

            message += "\nFinal Stats:";

            foreach (Stat stat in item.FinalStats.Stats)
            {
                message +=
                    "\n  "
                    + stat.StatType
                    + ": "
                    + stat.Value;
            }

            Debug.Log(message);
        }

        private static void AppendModifiers(
            ref string message,
            ModifierCollection modifiers)
        {
            foreach (Modifier modifier in modifiers)
            {
                message +=
                    "\n  "
                    + modifier.StatType
                    + " | "
                    + modifier.Operation
                    + " | "
                    + modifier.Value;
            }
        }
    }
}