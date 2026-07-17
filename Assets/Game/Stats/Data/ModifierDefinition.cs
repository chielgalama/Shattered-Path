using UnityEngine;
using ShatteredPath.Stats.Runtime;

namespace ShatteredPath.Stats.Data
{
    [System.Serializable]
    public struct ModifierDefinition
    {
        [SerializeField]
        private StatType statType;

        [SerializeField]
        private ModifierOperation operation;

        [SerializeField]
        private float value;

        public ModifierDefinition(
            StatType statType,
            ModifierOperation operation,
            float value)
        {
            this.statType = statType;
            this.operation = operation;
            this.value = value;
        }

        public StatType StatType => statType;

        public ModifierOperation Operation => operation;

        public float Value => value;

        public Modifier CreateRuntimeModifier()
        {
            return new Modifier(statType, operation, value);
        }
    }
}