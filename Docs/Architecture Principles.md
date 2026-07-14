# Shattered Path - Architecture Principles

Version: 1.0

---

# Purpose

This document defines the architectural principles of Shattered Path.

These principles exist to keep the project consistent throughout development.

When implementation details change, this document should remain largely unchanged.

When in doubt:

**Follow these principles instead of introducing new architecture.**

---

# Vision

Shattered Path is built around three core goals:

* Maintainability
* Readability
* Extensibility

The project is designed to grow over many years.

Architecture should support development rather than slow it down.

---

# Core Philosophy

We prefer a good architecture that evolves over time over a perfect architecture that never gets implemented.

Working software always has priority over theoretical perfection.

Refactoring is considered a normal part of development.

---

# Source of Truth

The GitHub repository is the single source of truth.

The current implementation always takes precedence over discussions or earlier designs.

Before writing new code:

* Review the current repository.
* Review the documentation.
* Continue from the existing implementation.

Never recreate systems that already exist.

---

# Development Process

Development happens in small vertical slices.

Each sprint has exactly one goal.

Example:

Implement ItemBuilder

Implement Local Modifiers

Implement Combat

Implement Loot

A sprint is finished when:

The feature works.

The feature is tested.

The project still compiles.

Only then is the next sprint started.

---

# Architecture First, Once

Before implementing a new system:

Discuss the overall architecture.

Identify major risks.

Choose a direction.

After implementation starts:

Avoid redesigning the architecture.

Continue until a real problem appears.

Only then consider refactoring.

---

# Refactoring

Refactoring is encouraged.

However, refactoring requires a concrete reason.

Valid reasons include:

The architecture blocks new functionality.

Code duplication becomes significant.

The design becomes difficult to understand.

Performance profiling identifies a bottleneck.

Refactoring should never happen because a solution might become useful someday.

---

# Data vs Runtime

The project follows a strict separation between data and runtime.

## Data

Data describes objects.

Data never contains gameplay logic.

Data is editable by designers.

Data is immutable during gameplay.

Examples:

CharacterDefinition

BaseItemDefinition

SkillDefinition

AffixDefinition

BaseStat

---

## Runtime

Runtime represents active gameplay.

Runtime contains behaviour.

Runtime may cache values.

Runtime may change continuously.

Examples:

Character

ItemInstance

Equipment

Stat

Buff

Projectile

---

# Builders

Builders convert data into runtime objects.

Builders are responsible only for construction.

Builders never execute gameplay.

Examples:

CharacterBuilder

ItemBuilder

SkillBuilder

Builders should remain deterministic.

Given identical input they should always produce identical runtime objects.

---

# Systems

Systems execute gameplay.

Examples:

CombatSystem

LootSystem

StatSystem

AISystem

Systems coordinate behaviour between runtime objects.

Runtime objects should remain relatively small.

---

# Definitions

Definitions describe game content.

Definitions should be understandable by designers.

Definitions should avoid implementation details.

Definitions should never contain runtime state.

---

# Runtime Objects

Runtime objects represent active entities.

Runtime objects own mutable state.

Runtime objects should expose behaviour rather than internal implementation.

---

# Statistics

All statistics follow one calculation model.

FinalValue = (Base + Flat) × Additive × Multiplicative

Base values are immutable after creation.

Modifiers never modify base values.

All gameplay systems use the same stat pipeline.

No system should implement its own stat calculation.

---

# Items

Items are generated from definitions.

Runtime ItemInstances contain generated state.

Future systems such as:

Affixes

Influence

Crafting

Corruption

Sockets

Implicit modifiers

must build upon the same item architecture.

No special-case implementations should exist.

---

# Gameplay Systems

Whenever possible, gameplay systems should reuse existing systems instead of introducing new implementations.

Examples:

Passives use modifiers.

Items use modifiers.

Buffs use modifiers.

Debuffs use modifiers.

Skills use modifiers.

The engine should solve problems once.

---

# Simplicity

Simple solutions are preferred.

Generic solutions should only be introduced when multiple systems actually require them.

Avoid speculative abstractions.

---

# Performance

Correctness comes before optimization.

Readable code comes before micro-optimizations.

Performance improvements should be driven by profiling.

Do not optimize hypothetical bottlenecks.

---

# Consistency

Consistency is more important than individual preferences.

When multiple valid solutions exist:

Choose the solution that best matches the existing project.

---

# Naming

Names should describe responsibilities.

A class should be understandable from its name.

Avoid abbreviations unless universally understood.

---

# Dependencies

Dependencies should point inward.

Definitions should never depend on runtime.

Runtime may depend on definitions.

Systems may depend on runtime.

Avoid circular dependencies.

---

# Testing

Every new feature should be tested immediately after implementation.

Large batches of untested code should be avoided.

Small verified improvements are preferred over large unverified implementations.

---

# Documentation

Documentation should explain decisions.

Documentation should not duplicate code.

If documentation becomes outdated:

Update it immediately or remove it.

---

# Collaboration Rules

The repository is reviewed before proposing new code.

Documentation is reviewed before proposing architectural changes.

Existing architecture is respected unless a concrete limitation has been identified.

Suggestions for improvements may be recorded for later consideration.

Current sprint work always has priority.

---

# Decision Making

When making architectural decisions, use the following priority:

1. Correctness
2. Simplicity
3. Readability
4. Extensibility
5. Performance

If two solutions are equally correct:

Choose the simpler one.

---

# Long-Term Goal

The objective is not to build the perfect engine.

The objective is to build a complete ARPG.

Architecture exists to help finish the game.

Every architectural decision should increase the likelihood that Shattered Path will eventually be completed.

---

# Final Principle

Keep moving forward.

Small, tested improvements made consistently over time will outperform perfect plans that never become working software.
