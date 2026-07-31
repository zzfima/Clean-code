# C# Coding Style Instructions

## General Rule

When creating or modifying code:
- Follow the existing project coding style.
- Consistency with existing code is more important than personal preference.
- Before adding new code, inspect nearby classes and follow their conventions.

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