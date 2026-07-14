using ShatteredPath.Stats.Data;

namespace ShatteredPath.Stats.Runtime
{
    public readonly struct Modifier
    {
        public Modifier(
            StatType statType,
            ModifierOperation operation,
            float value)
        {
            StatType = statType;
            Operation = operation;
            Value = value;
        }

        public StatType StatType { get; }

        public ModifierOperation Operation { get; }

        public float Value { get; }
    }
}