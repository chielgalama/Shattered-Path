using System;
using ShatteredPath.Items.Data;
using ShatteredPath.Stats.Runtime;

namespace ShatteredPath.Items.Runtime.Building
{
    public static class ItemBuilder
    {
        public static ItemInstance Build(
            BaseItemDefinition definition)
        {
            if (definition == null)
            {
                throw new ArgumentNullException(nameof(definition));
            }

            return new ItemInstance(definition);
        }
    }
}