using System.Collections.Generic;
using ShatteredPath.Items.Data;
using ShatteredPath.Characters.Runtime;
using ShatteredPath.Stats.Runtime;
using ShatteredPath.Stats.Data;

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
            ApplyGlobalModifiers(item);
        }

        private void ApplyItem(ItemInstance item)
        {
            foreach (Stat stat in item.FinalStats.Stats)
            {
                StatApplication application = StatApplicationDatabase.GetApplication(stat.StatType);

                switch (application)
                {
                    case StatApplication.FlatModifier:
                        if (!owner.Stats.TryGetStat(stat.StatType, out Stat ownerStat))
                        {
                            ownerStat = new Stat(stat.StatType, 0f);
                            owner.Stats.AddStat(ownerStat);
                        }

                        Modifier modifier = new Modifier(
                            stat.StatType,
                            ModifierOperation.Flat,
                            stat.Value);

                        ownerStat.AddModifier(modifier);

                        item.AppliedModifiers[stat.StatType] = modifier;

                        break;

                    case StatApplication.BaseOverride:
                        break;
                };
            }
        }

        private void ApplyGlobalModifiers(ItemInstance item)
        {
            foreach (Modifier modifier in item.GlobalModifiers.Modifiers)
            {
                Stat stat = owner.Stats.GetOrCreateStat(modifier.StatType);
                stat.AddModifier(modifier);
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
            foreach (Stat stat in item.FinalStats.Stats)
            {
                StatApplication application = StatApplicationDatabase.GetApplication(stat.StatType);

                switch (application)
                {
                    case StatApplication.FlatModifier:
                        if (!owner.Stats.TryGetStat(stat.StatType, out Stat ownerStat))
                        {
                            break;
                        }

                        if (!item.AppliedModifiers.TryGetValue(stat.StatType, out Modifier modifier))
                        {
                            break;
                        }

                        ownerStat.RemoveModifier(modifier);

                        break;

                    case StatApplication.BaseOverride:
                        break;
                };
            }

            // remove global item modifiers
        }

        private void RemoveGlobalModifiers(ItemInstance item)
        {
            foreach (Modifier modifier in item.GlobalModifiers.Modifiers)
            {
                if (owner.Stats.TryGetStat(modifier.StatType, out Stat stat))
                {
                    stat.RemoveModifier(modifier);
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