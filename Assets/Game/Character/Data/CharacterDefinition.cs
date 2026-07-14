using System.Collections.Generic;
using ShatteredPath.Stats.Data;
using UnityEngine;

namespace ShatteredPath.Characters.Data
{
    [CreateAssetMenu(
        fileName = "CharacterDefinition",
        menuName = "Shattered Path/Characters/Character Definition")]
    public sealed class CharacterDefinition : ScriptableObject
    {
        [Header("General")]
        [SerializeField]
        private string displayName = string.Empty;

        [Header("Base Stats")]
        [SerializeField]
        private List<BaseStat> baseStats = new List<BaseStat>();

        public string DisplayName => displayName;

        public IReadOnlyList<BaseStat> BaseStats => baseStats;

        private void OnValidate()
        {
            // Controleer op dubbele StatTypes
        }
    }
}