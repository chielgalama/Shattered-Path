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

            switch(operation)
            {
                case ModifierOperation.Additive:
                case ModifierOperation.Multiplicative:
                    value /= 100f;
                    break;
            }

            Value = value;
        }

        public StatType StatType { get; }

        public ModifierOperation Operation { get; }

        public float Value { get; }

        public override bool Equals(object obj)
        {
            if (obj is not Modifier other)
            {
                return false;
            }

            return
                StatType == other.StatType &&
                Operation == other.Operation &&
                Value == other.Value;
        }

        public override int GetHashCode()
        {
            return System.HashCode.Combine(
                StatType,
                Operation,
                Value);
        }
    }
}