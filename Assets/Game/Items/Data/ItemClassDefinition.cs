using UnityEngine;
using ShatteredPath.Items.Runtime;

namespace ShatteredPath.Items.Data
{
    [CreateAssetMenu(
        fileName = "ItemClass",
        menuName = "Shattered Path/Items/Item Class")]
    public sealed class ItemClassDefinition : ScriptableObject
    {
        [SerializeField]
        private string displayName = string.Empty;

        public string DisplayName => displayName;

        [SerializeField]
        private EquipmentSlot slot;

        public EquipmentSlot Slot => slot;
    }
}