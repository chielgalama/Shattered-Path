using ShatteredPath.Items.Data;
using ShatteredPath.Stats.Runtime;

namespace ShatteredPath.Items.Runtime
{
    public sealed class Item
    {
        public BaseItemDefinition Definition
        {
            get;
        }

        public StatCollection LocalStats
        {
            get;
        }

        public ModifierCollection Modifiers
        {
            get;
        }

        public Item(
            BaseItemDefinition definition,
            StatCollection localStats,
            ModifierCollection modifiers)
        {
            Definition = definition;
            LocalStats = localStats;
            Modifiers = modifiers;
        }
    }
}