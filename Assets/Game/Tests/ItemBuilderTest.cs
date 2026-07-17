using UnityEngine;
using ShatteredPath.Items.Data;
using ShatteredPath.Items.Runtime;
using ShatteredPath.Stats.Data;
using ShatteredPath.Items.Runtime.Builders;
using System.Linq;
using System.Collections.Generic;

namespace ShatteredPath.Tests
{
    public sealed class ItemBuilderTest : MonoBehaviour
    {
        public BaseItemDefinition helmetDefinition;

        private void Start()
        {
            Dictionary<string, int> results = new Dictionary<string, int>();

            for (int i = 0; i < 10000; i++)
            {
                ItemInstance helmet =
                    ItemBuilder.Build(helmetDefinition);

                string name =
                    helmet.Prefixes.First().AffixName;

                if (!results.ContainsKey(name))
                {
                    results.Add(name, 0);
                }

                results[name]++;
            }

            foreach (var result in results)
            {
                Debug.Log($"{result.Key}: {result.Value}");
            }
        }
    }
}