using System.Collections.Generic;
using ShatteredPath.Stats.Data;
using UnityEngine;

namespace ShatteredPath.Items.Data
{
    [CreateAssetMenu(
        fileName = "ItemBase",
        menuName = "Shattered Path/Items/Base Item")]
    public sealed class BaseItemDefinition : ScriptableObject
    {
        [SerializeField]
        private string displayName = string.Empty;

        [SerializeField]
        private GameObject prefab = null!;

        [SerializeField]
        private ItemClassDefinition itemClass = null!;

        [SerializeField]
        private List<BaseStat> baseStats = new List<BaseStat>();

        [SerializeField]
        private EquipmentSlot defaultEquipmentSlot;

        public string DisplayName => displayName;
        
        public EquipmentSlot DefaultEquipmentSlot => defaultEquipmentSlot;

        public GameObject Prefab => prefab;

        public ItemClassDefinition ItemClass => itemClass;

        public IReadOnlyList<BaseStat> BaseStats => baseStats;
    }
}