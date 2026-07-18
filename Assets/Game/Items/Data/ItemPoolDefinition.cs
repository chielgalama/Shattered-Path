using UnityEngine;

namespace ShatteredPath.Items.Data
{
    [CreateAssetMenu(
        fileName = "Item Pool",
        menuName = "Shattered Path/Items/Item Pool")]
    public sealed class ItemPoolDefinition : ScriptableObject
    {
        [SerializeField]
        private PrefixPoolDefinition prefixPool;

        [SerializeField]
        private SuffixPoolDefinition suffixPool;

        public PrefixPoolDefinition PrefixPool => prefixPool;

        public SuffixPoolDefinition SuffixPool => suffixPool;
    }
}