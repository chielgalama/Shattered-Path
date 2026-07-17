namespace ShatteredPath.Stats.Data
{
    public static class StatApplicationDatabase
    {
        public static StatApplication GetApplication(StatType statType)
        {
            switch (statType)
            {
                case StatType.AttackSpeed:
                case StatType.CriticalStrikeChance:
                case StatType.PhysicalDamageMinimum:
                case StatType.PhysicalDamageMaximum:
                    return StatApplication.BaseOverride;

                default:
                    return StatApplication.FlatModifier;
            }
        }
    }
}