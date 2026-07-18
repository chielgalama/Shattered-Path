using System;
using UnityEngine;

namespace ShatteredPath.Items.Data
{
    [Serializable]
    public sealed class TierDefinition
    {
        [SerializeField]
        private string tierName;

        [SerializeField]
        [Min(1)]
        private int requiredItemLevel = 1;

        [SerializeField]
        [Min(1)]
        private int weight = 100;

        [SerializeField]
        private float minimumValue;

        [SerializeField]
        private float maximumValue;

        public string TierName => tierName;

        public int RequiredItemLevel => requiredItemLevel;

        public int Weight => weight;

        public float MinimumValue => minimumValue;

        public float MaximumValue => maximumValue;
    }
}