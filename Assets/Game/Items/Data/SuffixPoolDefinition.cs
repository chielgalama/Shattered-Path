using System.Collections.Generic;
using UnityEngine;

namespace ShatteredPath.Items.Data
{
    [CreateAssetMenu(
        fileName = "Suffix Pool",
        menuName = "Shattered Path/Items/Suffix Pool")]
    public sealed class SuffixPoolDefinition : AffixPoolDefinition
    {
        [SerializeField]
        private List<SuffixTierListDefinition> tierLists =
            new List<SuffixTierListDefinition>();

        public IReadOnlyList<SuffixTierListDefinition> TierLists => tierLists;
    }
}