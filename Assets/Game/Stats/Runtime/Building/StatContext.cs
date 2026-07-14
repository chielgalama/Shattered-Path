using System;
using System.Collections.Generic;

namespace ShatteredPath.Stats.Runtime.Building
{
    public sealed class StatContext
    {
        private readonly List<StatCollection> sources = new List<StatCollection>();

        public IReadOnlyList<StatCollection> Sources => sources;

        public void AddSource(StatCollection source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            sources.Add(source);
        }

        public bool RemoveSource(StatCollection source)
        {
            return sources.Remove(source);
        }

        public void Clear()
        {
            sources.Clear();
        }
    }
}