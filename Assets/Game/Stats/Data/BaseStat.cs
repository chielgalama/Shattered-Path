using UnityEngine;

namespace ShatteredPath.Stats.Data
{
    [System.Serializable]
    public struct BaseStat
    {
        [SerializeField]
        private StatType statType;

        [SerializeField]
        private float value;

        public BaseStat(StatType statType, float value)
        {
            this.statType = statType;
            this.value = value;
        }

        public StatType StatType => statType;

        public float Value => value;
    }
}