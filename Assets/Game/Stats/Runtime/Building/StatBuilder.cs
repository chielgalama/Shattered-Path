using ShatteredPath.Characters.Runtime;

namespace ShatteredPath.Stats.Runtime
{
    public static class StatBuilder
    {
        public static void Rebuild(Character character)
        {
            character.Stats.Clear();

            AddCharacterBaseStats(character);

            // Equipment
            // Buffs
            // Passives
            // Skills
        }

        private static void AddCharacterBaseStats(Character character)
        {
            foreach (Stat stat in character.BaseStats.Stats)
            {
                character.Stats.AddStat(stat.StatType, stat.BaseValue);
            }
        }

        
    }
}