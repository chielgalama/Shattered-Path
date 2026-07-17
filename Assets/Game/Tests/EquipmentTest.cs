using UnityEngine;
using ShatteredPath.Characters.Data;
using ShatteredPath.Characters.Runtime;
using ShatteredPath.Items.Data;
using ShatteredPath.Items.Runtime;
using ShatteredPath.Stats.Data;
using ShatteredPath.Stats.Runtime;
using ShatteredPath.Items.Runtime.Builders;

public sealed class EquipmentTest : MonoBehaviour
{
    [SerializeField]
    private CharacterDefinition characterDefinition = null!;

    [SerializeField]
    private BaseItemDefinition helmetDefinition = null!;

    [SerializeField]
    private AffixDefinition heavyAffix = null!;

    private void Start()
    {
        Character character = new Character(characterDefinition);
        ItemInstance helmet = ItemBuilder.Build(helmetDefinition);
        helmet.AddAffix(heavyAffix);

        Debug.Log(helmet.BaseStats.GetValue(StatType.Armour));
        Debug.Log(helmet.FinalStats.GetValue(StatType.Armour));

        helmet.RemoveAffix(heavyAffix);

        Debug.Log(helmet.BaseStats.GetValue(StatType.Armour));
        Debug.Log(helmet.FinalStats.GetValue(StatType.Armour));

        character.Equipment.Equip(
            EquipmentSlot.Head,
            helmet);

        Debug.Log(
            $"Character Life: {character.Stats.GetValue(StatType.MaximumLife)}");

        Debug.Log(
            $"Helmet Armour: {helmet.FinalStats.GetValue(StatType.Armour)}");

        int equippedItems = 0;

        foreach (ItemInstance item in character.Equipment.GetEquippedItems())
        {
            equippedItems++;
        }

        Debug.Log($"Equipped Items: {equippedItems}");
    }
}