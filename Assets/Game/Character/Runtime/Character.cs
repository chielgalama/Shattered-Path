using ShatteredPath.Characters.Data;
using ShatteredPath.Items.Runtime;
using ShatteredPath.Stats.Runtime;

namespace ShatteredPath.Characters.Runtime
{
    public sealed class Character
    {
        public CharacterDefinition Definition { get; }

        public StatCollection BaseStats { get; }

        public StatCollection Stats { get; }

        public Equipment Equipment { get; }

        public Character(CharacterDefinition definition)
        {
            Definition = definition;

            BaseStats = new StatCollection(definition.BaseStats);

            Stats = new StatCollection();

            StatBuilder.Rebuild(this);

            Equipment = new Equipment(this);
        }
    }
}