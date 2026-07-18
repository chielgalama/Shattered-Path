using ShatteredPath.Items.Data;
using ShatteredPath.Stats.Runtime;

namespace ShatteredPath.Items.Runtime
{
    public sealed class AffixInstance
    {
        public AffixTierListDefinition TierList { get; }

        public TierDefinition Tier { get; }

        public ModifierCollection Modifiers { get; }

        public AffixInstance(
            AffixTierListDefinition tierList,
            TierDefinition tier,
            float rolledValue)
        {
            TierList = tierList;
            Tier = tier;

            Modifiers = new ModifierCollection();

            Modifier modifier = new Modifier(
                tierList.StatType,
                tierList.ModifierOperation,
                rolledValue);

            Modifiers.AddModifier(modifier);
        }
    }
}