using System.Collections.Generic;
using ShatteredPath.Stats.Data;
using UnityEngine;

namespace ShatteredPath.Items.Data
{
    public abstract class AffixTierListDefinition : ScriptableObject
    {
        [SerializeField]
        private string affixName;

        [SerializeField]
        private StatType statType;

        [SerializeField]
        private ModifierOperation modifierOperation;

        [SerializeField]
        private List<TierDefinition> tiers =
            new List<TierDefinition>();

        public string AffixName => affixName;

        public StatType StatType => statType;

        public ModifierOperation ModifierOperation => modifierOperation;

        public IReadOnlyList<TierDefinition> Tiers => tiers;
    }
}