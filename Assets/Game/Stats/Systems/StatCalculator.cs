using ShatteredPath.Stats.Runtime;

namespace ShatteredPath.Stats.Systems
{
    public static class StatCalculator
    {
        public static float Calculate(
            float baseValue,
            ModifierCollection modifiers)
        {
            float result = baseValue;

            // foreach (Modifier modifier in modifiers.FlatModifiers)
            // {
            //     result += modifier.Value;
            // }

            // float additiveMultiplier = 1f;

            // foreach (Modifier modifier in modifiers.AdditiveModifiers)
            // {
            //     additiveMultiplier += modifier.Value / 100f;
            // }

            // result *= additiveMultiplier;

            // foreach (Modifier modifier in modifiers.MultiplicativeModifiers)
            // {
            //     result *= 1f + modifier.Value / 100f;
            // }

            return result;
        }
    }
}

