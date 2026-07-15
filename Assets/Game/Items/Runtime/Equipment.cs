using System.Collections.Generic;
using ShatteredPath.Items.Data;
using ShatteredPath.Characters.Runtime;
using ShatteredPath.Stats.Runtime;

namespace ShatteredPath.Items.Runtime
{
    public sealed class Equipment
    {
        private readonly Dictionary<EquipmentSlot, ItemInstance> equippedItems = new Dictionary<EquipmentSlot, ItemInstance>();
        private readonly Character owner;

        public Equipment(Character owner)
        {
            this.owner = owner;
        }

        public bool TryGetItem(
            EquipmentSlot slot,
            out ItemInstance item)
        {
            return equippedItems.TryGetValue(slot, out item);
        }

        public void Equip(EquipmentSlot slot, ItemInstance item)
        {
            if (equippedItems.TryGetValue(slot, out ItemInstance previousItem))
            {
                RemoveItem(previousItem);
            }

            equippedItems[slot] = item;

            ApplyItem(item);
        }

        private void ApplyItem(ItemInstance item)
        {
            foreach (Stat stat in item.LocalStats.Stats)
            {
                if (!owner.Stats.TryGetStat(stat.StatType, out Stat ownerStat))
                {
                    continue;
                }

                foreach (Modifier modifier in stat.Modifiers)
                {
                    ownerStat.AddModifier(modifier);
                }
            }
        }

        public bool Unequip(EquipmentSlot slot)
        {
            if (!equippedItems.TryGetValue(slot, out ItemInstance item))
            {
                return false;
            }

            RemoveItem(item);

            return equippedItems.Remove(slot);
        }

        private void RemoveItem(ItemInstance item)
        {
            foreach (Stat stat in item.LocalStats.Stats)
            {
                if (!owner.Stats.TryGetStat(stat.StatType, out Stat ownerStat))
                {
                    continue;
                }

                foreach (Modifier modifier in stat.Modifiers)
                {
                    ownerStat.RemoveModifier(modifier);
                }
            }
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