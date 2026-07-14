using ShatteredPath.Stats.Data;
using ShatteredPath.Stats.Runtime;
using UnityEngine;

namespace ShatteredPath.Tests
{
    public sealed class StatTest : MonoBehaviour
    {
        private void Start()
        {
            Stat armour = new Stat(
                StatType.Armour,
                100.0f);

            armour.AddModifier(
                new Modifier(
                    StatType.Armour,
                    ModifierOperation.Flat,
                    25.0f));

            armour.AddModifier(
                new Modifier(
                    StatType.Armour,
                    ModifierOperation.Additive,
                    0.20f));

            armour.AddModifier(
                new Modifier(
                    StatType.Armour,
                    ModifierOperation.Multiplicative,
                    0.10f));

            Debug.Log(armour.Value);
        }
    }
}