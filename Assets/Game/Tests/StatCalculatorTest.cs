using UnityEngine;
using ShatteredPath.Stats.Data;
using ShatteredPath.Stats.Runtime;
using ShatteredPath.Stats.Systems;

public sealed class StatCalculatorTest : MonoBehaviour
{
    private void Start()
    {
        ModifierCollection modifiers = new ModifierCollection();

        modifiers.AddModifier(new Modifier(
            StatType.MaximumLife,
            ModifierOperation.Flat,
            50));

        modifiers.AddModifier(new Modifier(
            StatType.MaximumLife,
            ModifierOperation.Additive,
            20));

        modifiers.AddModifier(new Modifier(
            StatType.MaximumLife,
            ModifierOperation.Multiplicative,
            10));

        float result = StatCalculator.Calculate(
            100,
            modifiers);

        Debug.Log(result);
    }
}