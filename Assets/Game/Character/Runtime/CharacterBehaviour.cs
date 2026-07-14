using UnityEngine;
using ShatteredPath.Characters.Data;

namespace ShatteredPath.Characters.Runtime
{
    public sealed class CharacterBehaviour : MonoBehaviour
    {
        [SerializeField]
        private CharacterDefinition definition = null!;

        public Character Character { get; private set; } = null!;

        private void Awake()
        {
            Character = new Character(definition);

            Debug.Log(
                $"{definition.DisplayName} spawned with " +
                $"{Character.Stats.GetValue(Stats.Data.StatType.MaximumLife)} Life.");
        }
    }
}