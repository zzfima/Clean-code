# Devin Instructions for Clean-code

This file mirrors `AGENTS.md` for Devin-specific configuration. Keep both files aligned to avoid conflicts.

## General Rule

When creating or modifying code:
- Keep changes minimal and focused on the requested task.
- Follow existing code style and project patterns.
- Prefer root-cause fixes over quick patches.
- Do not rename existing symbols only for style compliance unless requested.

---

# Naming Conventions

## Classes

All class names must start with the prefix `C`.

Examples:

```csharp
public class CCustomerManager
{
}

public class CWaferController
{
}

```

## Interfaces

All interface names must start with the prefix I.

Examples:

```csharp
public interface ICustomerRepository
{
}

public interface IServiceManager
{
}
```

## Private Class Member Variables

All private class-level fields must start with the prefix m_.

Examples:
```csharp
private readonly ICustomerRepository m_customerRepository;

private int m_retryCount;
private string m_currentState;
```

## Validation for C# Changes

When changing C# code under `Chapter2`, run:
- `dotnet build Chapter2/Chapter2/Chapter2.csproj`
- `dotnet test Chapter2/Chapter2.Tests/Chapter2.Tests.csproj`

If local environment limitations prevent running these commands, report that clearly.