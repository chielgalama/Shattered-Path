# Shattered Path - Coding Guidelines

Version: 1.0

---

# Philosophy

These guidelines exist to keep the codebase consistent, maintainable and easy to extend.

The primary goal is **clarity over cleverness**.

We prefer a simple solution that is easy to understand over a complex solution that is theoretically more flexible.

Premature optimization should be avoided. Performance optimizations are only introduced when profiling shows they are necessary.

Refactoring is encouraged when a concrete problem is encountered.

---

# General Principles

## SOLID

Follow the SOLID principles whenever practical.

Do not force patterns where they add unnecessary complexity.

---

## Keep It Simple

Prefer simple implementations.

Avoid unnecessary abstractions.

Avoid generic systems until they are actually required.

---

## Readability First

Code is read far more often than it is written.

Optimize for readability.

If a piece of code requires explanation, it should probably be simplified.

---

## One Responsibility

Every class should have one clear responsibility.

Large classes should be split before they become difficult to understand.

---

## Explicit over Implicit

Avoid "magic".

Prefer explicit constructors.

Prefer explicit variable names.

Prefer explicit object creation.

---

# C#

## Language Version

Target Unity's officially supported C# version.

Do not use language features that require newer versions unless Unity officially supports them.

---

## Namespaces

Do not use file-scoped namespaces.

Always use block namespaces.

Example:

namespace ShatteredPath.Stats.Runtime
{
}

---

## Object Creation

Always use explicit constructors.

Correct:

new List<Modifier>();

Incorrect:

new();

---

## Braces

Always use braces.

Correct:

if (condition)
{
...
}

Incorrect:

if (condition)
...

---

## Visibility

Always declare visibility.

public

private

protected

internal

Never rely on default visibility.

---

## var Usage

Use var only when the type is obvious.

Correct:

var list = new List<Modifier>();

Incorrect:

var result = CalculateSomethingComplicated();

---

## Properties

Use expression-bodied properties only for very small properties.

Example:

public float Value => value;

Complex properties should always use full getter blocks.

---

## Fields

Private fields use camelCase.

Example:

private float value;

Do not prefix fields with underscores.

---

## Constants

Use PascalCase.

Example:

public const int MaximumLevel = 100;

---

## Enums

Enums use PascalCase.

Do not prefix enum values.

Correct:

ModifierOperation.Flat

Incorrect:

ModifierOperation.ModifierFlat

---

## Exceptions

Throw specific exceptions.

Prefer:

ArgumentNullException

ArgumentException

InvalidOperationException

Avoid throwing generic Exception.

---

# Naming

Follow Microsoft's C# naming conventions.

Classes

PascalCase

Interfaces

Prefix with I

Methods

PascalCase

Properties

PascalCase

Enums

PascalCase

Enum values

PascalCase

Private fields

camelCase

Parameters

camelCase

Local variables

camelCase

---

# Folder Structure

Group by feature before type.

Example:

Characters/

Items/

Stats/

Combat/

Skills/

Every feature contains its own:

Data

Runtime

Builders

Systems

Editor (when needed)

Avoid large global Runtime or Data folders.

---

# Architecture

## Definitions

Definitions only contain data.

Definitions never contain gameplay logic.

Definitions are immutable during gameplay.

Definitions are implemented as ScriptableObjects.

Examples:

CharacterDefinition

BaseItemDefinition

SkillDefinition

AffixDefinition

---

## Runtime

Runtime contains behaviour.

Runtime may cache values.

Runtime may change during gameplay.

Examples:

Character

ItemInstance

Stat

Equipment

Buff

---

## Builders

Builders convert Definition data into Runtime objects.

Builders never perform gameplay.

Correct:

CharacterBuilder

ItemBuilder

SkillBuilder

Incorrect:

CombatBuilder

DamageBuilder

---

## Systems

Systems execute gameplay.

Examples:

CombatSystem

LootSystem

StatSystem

Systems own gameplay logic.

---

# Stats

Base values are immutable.

Modifiers never change BaseValue.

Every stat is calculated as:

(Base + Flat) × Additive × Multiplicative

Modifier order:

Flat

Additive

Multiplicative

Never modify BaseValue after runtime creation.

---

# Items

Definitions describe items.

Runtime ItemInstances contain runtime state.

Items may contain:

Local stats

Modifiers

Sockets (future)

Affixes (future)

Durability (if ever added)

Definitions remain unchanged.

---

# ScriptableObjects

Never modify ScriptableObjects during gameplay.

All runtime changes belong inside runtime classes.

---

# Performance

Do not optimize before profiling.

Avoid unnecessary allocations inside Update.

Avoid LINQ in hot paths.

Prefer foreach over LINQ unless readability significantly improves.

Caching is allowed only when it improves measurable performance.

---

# Unity

Do not use FindObjectOfType during gameplay.

Avoid GameObject.Find.

Prefer dependency injection through constructors or initialization.

Serialize only data that designers should edit.

Keep MonoBehaviours as thin as possible.

Gameplay logic should live in plain C# classes whenever possible.

---

# Testing

Every new gameplay system should be tested before expanding it.

Build small vertical slices.

Do not continue until the previous slice works.

---

# Refactoring

Refactoring is encouraged.

Do not refactor because something "might" become a problem.

Refactor only when:

A real problem exists.

Readability decreases.

Code duplication becomes significant.

The architecture blocks new functionality.

---

# Working Agreement

Before every coding session:

Review the current GitHub repository.

Review Architecture.md.

Review Decisions.md.

Continue from the current sprint.

Do not redesign completed systems unless required.

One sprint.

One goal.

Finish.

Test.

Commit.

Repeat.

---

# Final Rule

Working code is better than perfect code.

The project should continuously move forward.

Architecture exists to support development, not to slow it down.
