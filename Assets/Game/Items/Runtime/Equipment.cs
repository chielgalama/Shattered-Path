using System.Collections.Generic;
using ShatteredPath.Items.Data;

namespace ShatteredPath.Items.Runtime
{
    public sealed class Equipment
    {
        private readonly Dictionary<EquipmentSlot, ItemInstance> equippedItems = new Dictionary<EquipmentSlot, ItemInstance>();

        public bool TryGetItem(
            EquipmentSlot slot,
            out ItemInstance item)
        {
            return equippedItems.TryGetValue(slot, out item);
        }

        public void Equip(
            EquipmentSlot slot,
            ItemInstance item)
        {
            equippedItems[slot] = item;
        }

        public bool Unequip(EquipmentSlot slot)
        {
            return equippedItems.Remove(slot);
        }

        public IEnumerable<ItemInstance> GetEquippedItems()
        {
            return equippedItems.Values;
        }

        public void Clear()
        {
            equippedItems.Clear();
        }
    }
}