using System.Collections.Generic;
using ShatteredPath.Items.Data;
using ShatteredPath.Stats.Data;
using ShatteredPath.Stats.Runtime;

namespace ShatteredPath.Items.Runtime
{
    public sealed class ItemInstance
    {
        public BaseItemDefinition Definition { get; }

        // Immutable runtime copy of the definition.
        public StatCollection BaseStats { get; }

        // Calculated local stats after all local modifiers.
        public StatCollection FinalStats { get; }
        public Dictionary<StatType, Modifier> AppliedModifiers { get; }
        public ModifierCollection LocalModifiers { get; }
        public ModifierCollection GlobalModifiers { get; }

        private readonly List<AffixInstance> prefixes = new List<AffixInstance>();

        private readonly List<AffixInstance> suffixes = new List<AffixInstance>();

        public IReadOnlyList<AffixInstance> Prefixes => prefixes;

        public IReadOnlyList<AffixInstance> Suffixes => suffixes;

        public ItemInstance(BaseItemDefinition definition)
        {
            Definition = definition;
            
            BaseStats = new StatCollection(definition.BaseStats);

            LocalModifiers = new ModifierCollection();
            foreach (ModifierDefinition modifier in definition.LocalModifiers)
            {
                LocalModifiers.AddModifier(modifier.CreateRuntimeModifier());
            }

            GlobalModifiers = new ModifierCollection();
            foreach (ModifierDefinition modifier in definition.GlobalModifiers)
            {
                GlobalModifiers.AddModifier(
                    modifier.CreateRuntimeModifier());
            }

            FinalStats = new StatCollection(definition.BaseStats);
            AppliedModifiers = new Dictionary<StatType, Modifier>();

            RecalculateLocalStats();
        }

        public void AddPrefix(AffixInstance prefix)
        {
            prefixes.Add(prefix);

            foreach (Modifier modifier in prefix.Modifiers)
            {
                LocalModifiers.AddModifier(modifier);
            }

            RecalculateLocalStats();
        }

        public void AddSuffix(AffixInstance suffix)
        {
            suffixes.Add(suffix);

            foreach (Modifier modifier in suffix.Modifiers)
            {
                LocalModifiers.AddModifier(modifier);
            }

            RecalculateLocalStats();
        }

        // public bool RemoveAffix(AffixDefinition affix)
        // {
        //    switch (affix.AffixType)
        //     {
        //         case AffixType.Prefix:
        //             prefixes.Remove(affix);
        //             break;

        //         case AffixType.Suffix:
        //             suffixes.Remove(affix);
        //             break;
        //     }

        //     foreach (ModifierDefinition modifier in affix.Modifiers)
        //     {
        //         LocalModifiers.RemoveModifier(
        //             modifier.CreateRuntimeModifier());
        //     }

        //     RecalculateLocalStats();

        //     return true;
        // }

        public void AddLocalModifier(Modifier modifier)
        {
            LocalModifiers.AddModifier(modifier);
            RecalculateLocalStats();
        }

        public void RemoveLocalModifier(Modifier modifier)
        {
            LocalModifiers.RemoveModifier(modifier);
            RecalculateLocalStats();
        }

        public void RecalculateLocalStats()
        {
            FinalStats.Clear();

            foreach (Stat baseStat in BaseStats.Stats)
            {
                Stat finalStat = new Stat(
                    baseStat.StatType,
                    baseStat.BaseValue);

                FinalStats.AddStat(finalStat);
            }

            foreach (Modifier modifier in LocalModifiers.Modifiers)
            {
                if (!FinalStats.TryGetStat(modifier.StatType, out Stat stat))
                {
                    continue;
                }

                stat.AddModifier(modifier);
            }
        }
    }
}