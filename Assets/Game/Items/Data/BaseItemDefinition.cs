using System.Collections.Generic;
using ShatteredPath.Stats.Data;
using ShatteredPath.Stats.Runtime;
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
        private EquipmentSlot defaultEquipmentSlot;

        [SerializeField]
        private List<BaseStat> baseStats = new List<BaseStat>();
        
        [SerializeField]
        private List<ModifierDefinition> localModifiers = new List<ModifierDefinition>();

        [SerializeField]
        private List<ModifierDefinition> globalModifiers = new List<ModifierDefinition>();

        public string DisplayName => displayName;

        public EquipmentSlot DefaultEquipmentSlot => defaultEquipmentSlot;

        public GameObject Prefab => prefab;

        public ItemClassDefinition ItemClass => itemClass;

        [SerializeField]
        [Min(1)]
        private int itemLevel = 1;
        //test

        public int ItemLevel => itemLevel;

        public IReadOnlyList<BaseStat> BaseStats => baseStats;
        public IReadOnlyList<ModifierDefinition> LocalModifiers => localModifiers;

        public IReadOnlyList<ModifierDefinition> GlobalModifiers => globalModifiers;

        [SerializeField]
        private ItemPoolDefinition itemPool;

        public ItemPoolDefinition ItemPool => itemPool;
    }
}