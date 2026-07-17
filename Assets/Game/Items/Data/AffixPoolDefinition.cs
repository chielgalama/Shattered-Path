using System.Collections.Generic;
using UnityEngine;

namespace ShatteredPath.Items.Data
{
    [CreateAssetMenu(
        fileName = "Affix Pool",
        menuName = "Shattered Path/Items/Affix Pool")]
    public sealed class AffixPoolDefinition : ScriptableObject
    {
        [SerializeField]
        private List<AffixDefinition> affixes =
            new List<AffixDefinition>();

        public IReadOnlyList<AffixDefinition> Affixes => affixes;
    }
}