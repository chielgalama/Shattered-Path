using UnityEngine;
using ShatteredPath.Characters.Data;
using ShatteredPath.Characters.Runtime;
using ShatteredPath.Items.Data;
using ShatteredPath.Items.Runtime;
using ShatteredPath.Stats.Data;

public sealed class EquipmentTest : MonoBehaviour
{
    [SerializeField]
    private CharacterDefinition characterDefinition = null!;

    [SerializeField]
    private BaseItemDefinition helmetDefinition = null!;

    private void Start()
    {
        Character character = new Character(characterDefinition);

        ItemInstance helmet = new ItemInstance(helmetDefinition);

        character.Equipment.Equip(
            EquipmentSlot.Head,
            helmet);

        Debug.Log(
            $"Character Life: {character.Stats.GetValue(StatType.MaximumLife)}");

        Debug.Log(
            $"Helmet Armour: {helmet.Stats.GetValue(StatType.Armour)}");

        int equippedItems = 0;

        foreach (ItemInstance item in character.Equipment.GetEquippedItems())
        {
            equippedItems++;
        }

        Debug.Log($"Equipped Items: {equippedItems}");
    }
}