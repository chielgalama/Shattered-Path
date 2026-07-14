using System;
using ShatteredPath.Items.Data;
using ShatteredPath.Stats.Runtime;

namespace ShatteredPath.Items.Runtime.Building
{
    public static class ItemBuilder
    {
        public static Item Build(
            BaseItemDefinition definition)
        {
            if (definition == null)
            {
                throw new ArgumentNullException(nameof(definition));
            }

            StatCollection localStats =
                new StatCollection(definition.BaseStats);

            ModifierCollection modifiers =
                new ModifierCollection();

            Item item = new Item(
                definition,
                localStats,
                modifiers);

            return item;
        }
    }
}