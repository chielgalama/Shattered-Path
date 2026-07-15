1. Runtime Objects are Persistent
Runtime objects are created once and remain alive during gameplay.

Runtime objects are never recreated because of gameplay changes.

Examples:

Character
ItemInstance
Stat
ModifierCollection
Buff
Skill
2. Base Values are Immutable
A Stat receives its BaseValue during construction.

The BaseValue never changes afterwards.

BaseValue is not a modifier.

BaseValue is not recalculated.

BaseValue is never overwritten.

Dit voorkomt dat ik ooit nog SetBaseValue() voorstel.

3. Runtime is Event Driven
Gameplay never rebuilds runtime objects.

Gameplay generates events.

Examples:

Equip Item

Unequip Item

Buff Applied

Buff Removed

Passive Allocated

Passive Removed

Skill Activated
4. Gameplay Adds and Removes Modifiers
Gameplay never edits BaseValue.

Gameplay only adds or removes modifiers.

Examples:

Equipment

Buffs

Passives

Auras

Skills
5. ModifierCollection Owns Modifiers
Stat does not own gameplay logic.

ModifierCollection owns:

AddModifier()

RemoveModifier()

Clear()

Enumeration

Dus:

Stat

BaseValue

ModifierCollection

Dirty

CachedValue
6. Dirty Flag
Whenever ModifierCollection changes:

Dirty = true

Nothing else happens.

Geen recalculation.

7. Lazy Evaluation
When Value is requested:

if Dirty

↓

Recalculate

↓

Cache

↓

Dirty = false

Dus nooit recalculeren tijdens equip.

8. StatBuilder

Hier wil ik zelfs expliciet inzetten:

StatBuilder has exactly one responsibility.

Create runtime Stat objects from Definitions.

StatBuilder is never used during gameplay.

Dit is volgens mij de grootste wijziging ten opzichte van mijn eerdere denken.

9. Equipment
Equipment never changes stats.

Equipment only changes modifiers.

Equipment sends gameplay events.

The Stat system reacts.
10. Rebuild

Hier zou ik zelfs zetten:

Rebuilding runtime stats during gameplay is prohibited.

Runtime state is modified incrementally.

Only Definitions create runtime objects.