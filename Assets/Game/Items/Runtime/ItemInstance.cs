
using ShatteredPath.Items.Data;
using ShatteredPath.Stats.Runtime;

namespace ShatteredPath.Items.Runtime
{
    public sealed class ItemInstance
    {
        public BaseItemDefinition Definition { get; }

        public StatCollection Stats { get; }

        public ItemInstance(BaseItemDefinition definition)
        {
            Definition = definition;
            Stats = new StatCollection(definition.BaseStats);
        }
    }
}