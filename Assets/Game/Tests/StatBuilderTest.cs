using UnityEngine;
using ShatteredPath.Stats.Runtime;
using ShatteredPath.Stats.Runtime.Building;
using ShatteredPath.Stats.Data;

namespace ShatteredPath.Tests
{
    public sealed class StatBuilderTest : MonoBehaviour
    {
        private void Start()
        {
            StatCollection definitionStats =
                new StatCollection();

            definitionStats.AddStat(
                StatType.MaximumLife,
                100.0f);

            definitionStats.AddStat(
                StatType.MaximumMana,
                50.0f);

            StatContext context =
                new StatContext();

            context.AddSource(definitionStats);

            StatCollection runtimeStats =
                new StatCollection();

            StatBuilder.Build(
                context,
                runtimeStats);

            Debug.Log(
                runtimeStats.GetValue(
                    StatType.MaximumLife));

            Debug.Log(
                runtimeStats.GetValue(
                    StatType.MaximumMana));
        }
    }
}