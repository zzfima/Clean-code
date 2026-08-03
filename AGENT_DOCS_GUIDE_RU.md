# Руководство по документам конфигурации агента (Русский)

В этом документе описано, какие типы агентных документов используются в репозитории, что в них писать и как применять их на практике.

## 1) `AGENTS.md` (область действия: репозиторий/папка)

### Назначение
`AGENTS.md` задает правила для coding-агента в пределах дерева папок.

### Куда размещать
- `AGENTS.md` в корне: действует на весь репозиторий.
- Вложенный `AGENTS.md`: действует только на эту папку и ее подпапки.

### Что писать внутри
- Правила код-стиля (нейминг, архитектурные ограничения).
- Обязательные команды build/test после изменений.
- Ограничения (например: не переименовывать символы без запроса).
- Пояснение области действия при необходимости.

### Как используется
- Применяется автоматически, когда агент редактирует файлы в его области.
- Если подходят несколько `AGENTS.md`, приоритет у более глубокого (вложенного).
- Прямой запрос пользователя в чате все равно имеет наивысший приоритет.

## 2) `.devin/instructions.md` (дефолтные правила Devin)

### Назначение
Определяет дефолтное поведение Devin для этого репозитория.

### Куда размещать
- В корень репозитория: `.devin/instructions.md`.

### Что писать внутри
- Глобальные правила для Devin в этом проекте.
- Правила, синхронизированные с `AGENTS.md`.
- Общие требования к качеству и валидации.

### Как используется
- Загружается как базовый контекст инструкций Devin в репозитории.
- Практика: держать в согласованном состоянии с `AGENTS.md`.

## 3) `.devin/skills/SKILL.md` (переиспользуемый плейбук задачи)

### Назначение
Описывает переиспользуемый навык (например, `run-tests`) с понятными шагами.

### Куда размещать
- Внутри `.devin/skills/`.
- Типовой файл навыка: `SKILL.md`.

### Что писать внутри
- Frontmatter:
  - `name`: имя навыка.
  - `description`: когда этот навык применять.
- Пошаговые действия, лучше с конкретными командами.

### Как используется
- Подхватывается, когда запрос совпадает с назначением навыка.
- Можно явно попросить использовать навык в запросе.

## 4) Опционально: `.devin/workflows/*.md`

### Назначение
Описывает повторяемые многошаговые процессы.

### Что писать внутри
- YAML frontmatter с кратким описанием.
- Четкие упорядоченные шаги.

### Как используется
- Удобно для стандартных процедур (релиз, миграция, онбординг).

## Практические примеры

### Пример корневого `AGENTS.md`

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

### Пример вложенного `AGENTS.md` (переопределение)

Путь: `Chapter2/fitnesse/AGENTS.md`

```md
# FitNesse Area Rules

## Scope
These instructions apply only to `Chapter2/fitnesse` and its subfolders.

## Rules
- Do not change scenario names unless requested.
- Keep fixture class names unchanged.
```

### Пример `.devin/instructions.md`

```md
# Devin Instructions for Clean-code

This file mirrors `AGENTS.md` for Devin-specific configuration.

- Keep changes minimal and focused.
- Follow existing code style and project patterns.
- Report clearly if build or tests cannot run locally.
```

### Пример `.devin/skills/SKILL.md`

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

### Примеры запросов для триггера поведения

- `Refactor Chapter2/Chapter2/Program.cs and follow AGENTS.md.`
- `Use the run-tests skill and report any failing tests.`
- `Apply repo defaults from .devin/instructions.md while updating converter logic.`

## Приоритет правил (важно)
Если есть несколько источников, практический приоритет:
1. Прямой запрос пользователя в чате.
2. Подходящий `AGENTS.md` (более глубокий уровень имеет приоритет).
3. Дефолты из `.devin/instructions.md`.
4. Общие best practices по разработке.

## Как "триггерить" правила на практике
- Ставьте конкретную задачу с конкретным путем к файлу.
- Пример: `Refactor Chapter2/Chapter2/Program.cs and follow repo conventions.`
- Агент автоматически применит релевантные правила.

## Рекомендуемая структура для этого репозитория

- `AGENTS.md`
- `.devin/instructions.md`
- `.devin/skills/SKILL.md`

## Советы по поддержке
- Держите `AGENTS.md` кратким и авторитетным.
- Синхронизируйте `.devin/instructions.md` с `AGENTS.md`.
- В skills указывайте точные команды, а не общие фразы.
- Обновляйте документы при изменении командных соглашений.
