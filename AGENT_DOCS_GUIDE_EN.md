# Agent Configuration Documents Guide (English)

This guide explains what agent-related documents are used in this repository, what to put inside them, and how to use them effectively.

## 1) `AGENTS.md` (Repository or Folder Scope)

### Purpose
`AGENTS.md` defines coding-agent rules for a directory tree.

### Where to place it
- Root `AGENTS.md`: applies to the full repository.
- Nested `AGENTS.md`: applies only to that subfolder and its children.

### What to put inside
- Coding conventions (naming, style, architecture limits).
- Testing/build commands required after changes.
- Guardrails (for example: do not rename symbols unless requested).
- Scope notes if needed.

### How it is used
- Applied automatically when the agent edits files in its scope.
- If multiple `AGENTS.md` files apply, the deeper one has priority.
- Direct user request in chat still has highest priority.

## 2) `.devin/instructions.md` (Devin Defaults)

### Purpose
Defines Devin-specific default behavior for this repo.

### Where to place it
- At `.devin/instructions.md` in repository root.

### What to put inside
- Repo-wide defaults that should always be true for Devin.
- Rules that mirror your canonical guidance (usually from `AGENTS.md`).
- High-level quality expectations and validation steps.

### How it is used
- Loaded as default instruction context by Devin for this repository.
- Best practice: keep it aligned with `AGENTS.md` to avoid confusion.

## 3) `.devin/skills/SKILL.md` (Reusable Task Playbook)

### Purpose
Defines a reusable skill (for example, `run-tests`) with clear steps.

### Where to place it
- Under `.devin/skills/`.
- Typical filename is `SKILL.md` in a skill folder.

### What to put inside
- Frontmatter:
  - `name`: skill name.
  - `description`: when to use the skill.
- Action steps with explicit commands where possible.

### How it is used
- Triggered when your prompt matches the skill intent.
- Can be invoked explicitly by mentioning the skill goal in your prompt.

## 4) Optional: `.devin/workflows/*.md`

### Purpose
Defines repeatable multi-step workflows.

### What to put inside
- YAML frontmatter with short description.
- Ordered, concrete instructions.

### How it is used
- Useful for standard procedures (release, migration, onboarding tasks).

## Practical Examples

### Example root `AGENTS.md`

```md
# Clean-code Agent Guidance

## Scope
These instructions apply to the entire repository.

## C# Naming Conventions
- Class names use the `C` prefix.
- Interface names use the `I` prefix.
- Private class-level fields use the `m_` prefix.

## Validation
- `dotnet build Chapter2/Chapter2/Chapter2.csproj`
- `dotnet test Chapter2/Chapter2.Tests/Chapter2.Tests.csproj`
```

### Example nested `AGENTS.md` override

Path: `Chapter2/fitnesse/AGENTS.md`

```md
# FitNesse Area Rules

## Scope
These instructions apply only to `Chapter2/fitnesse` and its subfolders.

## Rules
- Do not change scenario names unless requested.
- Keep fixture class names unchanged.
```

### Example `.devin/instructions.md`

```md
# Devin Instructions for Clean-code

This file mirrors `AGENTS.md` for Devin-specific configuration.

- Keep changes minimal and focused.
- Follow existing code style and project patterns.
- Report clearly if build or tests cannot run locally.
```

### Example `.devin/skills/SKILL.md`

```md
---
name: run-tests
description: Run Chapter2 validation before PR.
---

# Run Tests

1. `dotnet restore Chapter2/Chapter2.slnx`
2. `dotnet build Chapter2/Chapter2/Chapter2.csproj`
3. `dotnet test Chapter2/Chapter2.Tests/Chapter2.Tests.csproj`
4. Report failed tests with names and error messages.
```

### Example prompts to trigger behavior

- `Refactor Chapter2/Chapter2/Program.cs and follow AGENTS.md.`
- `Use the run-tests skill and report any failing tests.`
- `Apply repo defaults from .devin/instructions.md while updating converter logic.`

## Rule Priority (Important)
When multiple sources exist, practical priority is:
1. Direct user request in chat.
2. Applicable `AGENTS.md` (closest/deepest scope wins).
3. `.devin/instructions.md` defaults.
4. General coding best practices.

## How to Trigger These Rules in Practice
- Ask for a concrete task on a concrete file path.
- Example: `Refactor Chapter2/Chapter2/Program.cs and follow repo conventions.`
- The agent will automatically apply rules from relevant files.

## Recommended Structure for This Repo

- `AGENTS.md`
- `.devin/instructions.md`
- `.devin/skills/SKILL.md`

## Maintenance Tips
- Keep `AGENTS.md` concise and authoritative.
- Keep `.devin/instructions.md` synchronized with `AGENTS.md`.
- Put exact commands in skills (not only generic steps).
- Update docs whenever team conventions change.
