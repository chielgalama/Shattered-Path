using System;
using System.Collections.Generic;
using ShatteredPath.Stats.Data;

namespace ShatteredPath.Stats.Runtime
{
    public sealed class StatCollection
    {
        private readonly Dictionary<StatType, Stat> stats = new Dictionary<StatType, Stat>();

        public StatCollection()
        {
        }
        
        public StatCollection(IEnumerable<BaseStat> baseStats)
            : this()
        {
            AddBaseStats(baseStats);
        }

        public IEnumerable<Stat> Stats
        {
            get
            {
                return stats.Values;
            }
        }

        public bool Contains(StatType statType)
        {
            return stats.ContainsKey(statType);
        }

        // Like the constructor, maybe this can be removed
        public void AddBaseStats(IEnumerable<BaseStat> baseStats)
        {
            foreach (BaseStat baseStat in baseStats)
            {
                AddBaseStat(baseStat);
            }
        }

        // Like the constructor, maybe this can be removed
        public void AddBaseStat(BaseStat baseStat)
        {
            if(Contains(baseStat.StatType))
                return;

            Stat stat = new Stat(baseStat.StatType, baseStat.Value);
            AddStat(stat);
        }

        public void AddStat(StatType statType, float baseValue = 0f)
        {   
            Stat stat = new Stat(statType, baseValue);
            AddStat(stat);
        }
        
        public void AddStat(Stat stat)
        {
            if (stat == null)
            {
                throw new ArgumentNullException(nameof(stat));
            }

            if (stats.ContainsKey(stat.StatType))
            {
                throw new InvalidOperationException(
                    "StatCollection already contains stat: "
                    + stat.StatType);
            }

            stats.Add(stat.StatType, stat);
        }

        public bool TryGetStat(StatType statType, out Stat stat)
        {
            return stats.TryGetValue(statType, out stat);
        }

        public float GetValue(StatType statType)
        {
            if (!TryGetStat(
                statType,
                out Stat stat))
            {
                return 0.0f;
            }

            return stat.Value;
        }

        public void Clear()
        {
            stats.Clear();
        }
    }
}