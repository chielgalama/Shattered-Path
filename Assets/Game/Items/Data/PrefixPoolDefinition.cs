using System.Collections.Generic;
using UnityEngine;

namespace ShatteredPath.Items.Data
{
    [CreateAssetMenu(
        fileName = "Prefix Pool",
        menuName = "Shattered Path/Items/Prefix Pool")]
    public sealed class PrefixPoolDefinition : AffixPoolDefinition
    {
        [SerializeField]
        private List<PrefixTierListDefinition> tierLists =
            new List<PrefixTierListDefinition>();

        public IReadOnlyList<PrefixTierListDefinition> TierLists => tierLists;
    }
}