using ShatteredPath.Stats.Data;

namespace ShatteredPath.Stats.Runtime
{
    public sealed class Stat
    {
        public StatType StatType { get; }

        public float BaseValue { get; }

        public ModifierCollection Modifiers { get; }

        private float calculatedValue;

        private bool isDirty;

        public float Value
        {
            get
            {
                if (isDirty)
                {
                    Recalculate();
                }

                return calculatedValue;
            }
        }

        public Stat(
            StatType statType,
            float baseValue)
        {
            StatType = statType;
            BaseValue = baseValue;

            Modifiers = new ModifierCollection();

            calculatedValue = baseValue;
            isDirty = false;
        }

        public void AddModifier(Modifier modifier)
        {
            Modifiers.Add(modifier);

            isDirty = true;
        }

        public bool RemoveModifier(Modifier modifier)
        {
            bool removed = Modifiers.Remove(modifier);

            if (removed)
            {
                isDirty = true;
            }

            return removed;
        }

        public void ClearModifiers()
        {
            Modifiers.Clear();

            isDirty = true;
        }

        private void Recalculate()
        {
            float flatBonus = 0.0f;
            float additiveMultiplier = 1.0f;
            float multiplicativeMultiplier = 1.0f;

            foreach (Modifier modifier in Modifiers)
            {
                switch (modifier.Operation)
                {
                    case ModifierOperation.Flat:
                        flatBonus += modifier.Value;
                        break;

                    case ModifierOperation.Additive:
                        additiveMultiplier += modifier.Value;
                        break;

                    case ModifierOperation.Multiplicative:
                        multiplicativeMultiplier *= 1.0f + modifier.Value;
                        break;
                }
            }

            calculatedValue =
                (BaseValue + flatBonus)
                * additiveMultiplier
                * multiplicativeMultiplier;

            isDirty = false;
        }
    }
}