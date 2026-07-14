using UnityEngine;
using ShatteredPath.Items.Data;
using ShatteredPath.Items.Runtime;
using ShatteredPath.Stats.Data;
using ShatteredPath.Items.Runtime.Building;

namespace ShatteredPath.Tests
{
    public sealed class ItemBuilderTest : MonoBehaviour
    {
        public BaseItemDefinition helmetDefinition;

        private void Start()
        {
            Item helmet = ItemBuilder.Build(helmetDefinition);

            Debug.Log(
                helmet.LocalStats.GetValue(
                    StatType.Armour));
        }
    }
}