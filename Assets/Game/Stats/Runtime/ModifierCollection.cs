using System.Collections;
using System.Collections.Generic;

namespace ShatteredPath.Stats.Runtime
{
    public sealed class ModifierCollection : IEnumerable<Modifier>
    {
        private readonly List<Modifier> modifiers =
            new List<Modifier>();

        public int Count
        {
            get
            {
                return modifiers.Count;
            }
        }

        public Modifier this[int index]
        {
            get
            {
                return modifiers[index];
            }
        }

        public void Add(Modifier modifier)
        {
            modifiers.Add(modifier);
        }

        public bool Remove(Modifier modifier)
        {
            return modifiers.Remove(modifier);
        }

        public void Clear()
        {
            modifiers.Clear();
        }

        public IEnumerator<Modifier> GetEnumerator()
        {
            return modifiers.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}