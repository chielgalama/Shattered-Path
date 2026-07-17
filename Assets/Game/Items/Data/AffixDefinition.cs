using System.Collections.Generic;
using UnityEngine;
using ShatteredPath.Stats.Data;

namespace ShatteredPath.Items.Data
{
    [CreateAssetMenu(
        fileName = "Affix",
        menuName = "Shattered Path/Items/Affix")]
    public sealed class AffixDefinition : ScriptableObject
    {
        [SerializeField]
        private string affixName;

        [SerializeField]
        private AffixType affixType;

        public AffixType AffixType => affixType;

        [SerializeField]
        [Min(1)]
        private int requiredLevel = 1;

        public int RequiredLevel => requiredLevel;

        [SerializeField]
        [Min(1)]
        private int weight = 100;

        public int Weight => weight;

        [SerializeField]
        private List<ModifierDefinition> modifiers = new List<ModifierDefinition>();

        public string AffixName => affixName;

        public IReadOnlyList<ModifierDefinition> Modifiers => modifiers;
    }
}