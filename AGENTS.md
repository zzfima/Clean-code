# Clean-code Agent Guidance

## Scope
These instructions apply to the entire repository.

## Working Principles
- Keep changes minimal and focused on the requested task.
- Follow existing code style and project patterns.
- Prefer root-cause fixes over quick patches.
- Do not rename existing symbols only for style compliance unless requested.

## C# Naming Conventions
For new or modified C# code:
- Class names use the `C` prefix (for example, `CCalculator`).
- Interface names use the `I` prefix (for example, `ICalculatorService`).
- Private class-level fields use the `m_` prefix (for example, `m_retryCount`).

## Validation for C# Changes
When changing C# code under `Chapter2`, run:
- `dotnet build Chapter2/Chapter2/Chapter2.csproj`
- `dotnet test Chapter2/Chapter2.Tests/Chapter2.Tests.csproj`

If local environment limitations prevent running these commands, report that clearly.
