namespace ShatteredPath.Stats.Data
{
    public enum StatType
    {
        // Resources
        MaximumLife,
        MaximumMana,

        // Attributes
        Strength,
        Dexterity,
        Intelligence,

        // Defence
        Armour,
        Evasion,

        FireResistance,
        ColdResistance,
        LightningResistance,
        ChaosResistance,

        // Offence
        PhysicalDamage,
        PhysicalDamageMinimum,
        PhysicalDamageMaximum,
        FireDamage,
        ColdDamage,
        LightningDamage,
        ChaosDamage,

        AttackSpeed,
        CastSpeed,

        CriticalStrikeChance,
        CriticalStrikeMultiplier,

        // Utility
        MovementSpeed,
        CooldownRecovery
    }
}