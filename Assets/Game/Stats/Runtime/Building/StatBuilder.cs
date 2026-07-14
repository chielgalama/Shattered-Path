using System;
using ShatteredPath.Stats.Runtime;

namespace ShatteredPath.Stats.Runtime.Building
{
    public static class StatBuilder
    {
        public static void Build(
            StatContext context,
            StatCollection result)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }

            result.Clear();

            foreach (StatCollection source in context.Sources)
            {
                foreach (Stat stat in source.Stats)
                {
                    Stat runtimeStat =
                        new Stat(
                            stat.StatType,
                            stat.BaseValue);

                    result.AddStat(runtimeStat);
                }
            }
        }
    }
}