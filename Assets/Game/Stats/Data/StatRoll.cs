using UnityEngine;

namespace ShatteredPath.Stats.Data
{
    [System.Serializable]
    public struct StatRoll
    {
        [SerializeField]
        private StatType statType;

        [SerializeField]
        private float minimumValue;

        [SerializeField]
        private float maximumValue;

        public StatRoll(
            StatType statType,
            float minimumValue,
            float maximumValue)
        {
            this.statType = statType;
            this.minimumValue = minimumValue;
            this.maximumValue = maximumValue;
        }

        public StatType StatType => statType;

        public float MinimumValue => minimumValue;

        public float MaximumValue => maximumValue;
    }
}