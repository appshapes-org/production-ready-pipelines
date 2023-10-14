using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Common.Hosting;
using Common.Lifetime;
using Microsoft.Extensions.Logging;
using Serilog.Context;

namespace Common.Logging;

[ExcludeFromCodeCoverage]
public static class LoggingExtensions
{
    public static void Debug(this ILogger logger, string message, object propertyValue1 = null, object propertyValue2 = null, [CallerArgumentExpression("propertyValue1")] string propertyName1 = null, [CallerArgumentExpression("propertyValue2")] string propertyName2 = null, [CallerMemberName] string memberName = null, [CallerFilePath] string classPath = null)
    {
        List<(string Name, object Value)> namedValues = new List<(string Name, object Value)>();
        if (propertyName1 != null)
            namedValues.Add((propertyName1, propertyValue1));
        if (propertyName2 != null)
            namedValues.Add((propertyName2, propertyValue2));
        using (PushProperties(memberName, classPath, namedValues))
        {
            logger.LogDebug(message);
        }
    }

    public static void Debug(this ILogger logger, Exception exception, string message, object propertyValue = null, [CallerArgumentExpression("propertyValue")] string propertyName = null, [CallerMemberName] string memberName = null, [CallerFilePath] string classPath = null)
    {
        using (PushProperties(memberName, classPath, propertyName != null ? new (string Name, object Value)[] { (propertyName, propertyValue) } : null))
        {
            logger.LogDebug(exception, message);
        }
    }

    public static void Error(this ILogger logger, string message, object propertyValue = null, [CallerArgumentExpression("propertyValue")] string propertyName = null, [CallerMemberName] string memberName = null, [CallerFilePath] string classPath = null)
    {
        using (PushProperties(memberName, classPath, propertyName != null ? new (string Name, object Value)[] { (propertyName, propertyValue) } : null))
        {
            logger.LogError(message);
        }
    }

    public static void Error(this ILogger logger, Exception exception, string message = null, object propertyValue = null, [CallerArgumentExpression("propertyValue")] string propertyName = null, [CallerMemberName] string memberName = null, [CallerFilePath] string classPath = null)
    {
        using (PushProperties(memberName, classPath, propertyName != null ? new (string Name, object Value)[] { (propertyName, propertyValue) } : null))
        {
            logger.LogError(exception, message);
        }
    }

    public static void Information(this ILogger logger,
        string message,
        object propertyValue1 = null,
        object propertyValue2 = null,
        object propertyValue3 = null,
        object propertyValue4 = null,
        [CallerArgumentExpression("propertyValue1")] string propertyName1 = null,
        [CallerArgumentExpression("propertyValue2")] string propertyName2 = null,
        [CallerArgumentExpression("propertyValue3")] string propertyName3 = null,
        [CallerArgumentExpression("propertyValue4")] string propertyName4 = null,
        [CallerMemberName] string memberName = null,
        [CallerFilePath] string classPath = null)
    {
        List<(string Name, object Value)> namedValues = new List<(string Name, object Value)>();
        if (propertyName1 != null)
            namedValues.Add((propertyName1, propertyValue1));
        if (propertyName2 != null)
            namedValues.Add((propertyName2, propertyValue2));
        if (propertyName3 != null)
            namedValues.Add((propertyName3, propertyValue3));
        if (propertyName4 != null)
            namedValues.Add((propertyName4, propertyValue4));
        using (PushProperties(memberName, classPath, namedValues))
        {
            logger.LogInformation(message);
        }
    }

    public static void Information(this ILogger logger, Exception exception, string message, object propertyValue1 = null, object propertyValue2 = null, [CallerArgumentExpression("propertyValue1")] string propertyName1 = null, [CallerArgumentExpression("propertyValue2")] string propertyName2 = null, [CallerMemberName] string memberName = null, [CallerFilePath] string classPath = null)
    {
        List<(string Name, object Value)> namedValues = new List<(string Name, object Value)>();
        if (propertyName1 != null)
            namedValues.Add((propertyName1, propertyValue1));
        if (propertyName2 != null)
            namedValues.Add((propertyName2, propertyValue2));
        using (PushProperties(memberName, classPath, namedValues))
        {
            logger.LogInformation(exception, message);
        }
    }

    public static void Trace(this ILogger logger, string message, object propertyValue = null, [CallerArgumentExpression("propertyValue")] string propertyName = null, [CallerMemberName] string memberName = null, [CallerFilePath] string classPath = null)
    {
        using (PushProperties(memberName, classPath, propertyName != null ? new (string Name, object Value)[] { (propertyName, propertyValue) } : null))
        {
            logger.LogTrace(message);
        }
    }

    public static void Trace(this ILogger logger, Exception exception, string message, object propertyValue = null, [CallerArgumentExpression("propertyValue")] string propertyName = null, [CallerMemberName] string memberName = null, [CallerFilePath] string classPath = null)
    {
        using (PushProperties(memberName, classPath, propertyName != null ? new (string Name, object Value)[] { (propertyName, propertyValue) } : null))
        {
            logger.LogTrace(exception, message);
        }
    }

    public static void Warning(this ILogger logger, string message, object propertyValue = null, [CallerArgumentExpression("propertyValue")] string propertyName = null, [CallerMemberName] string memberName = null, [CallerFilePath] string classPath = null)
    {
        using (PushProperties(memberName, classPath, propertyName != null ? new (string Name, object Value)[] { (propertyName, propertyValue) } : null))
        {
            logger.LogWarning(message);
        }
    }

    public static void Warning(this ILogger logger, Exception exception, string message, object propertyValue = null, [CallerArgumentExpression("propertyValue")] string propertyName = null, [CallerMemberName] string memberName = null, [CallerFilePath] string classPath = null)
    {
        using (PushProperties(memberName, classPath, propertyName != null ? new (string Name, object Value)[] { (propertyName, propertyValue) } : null))
        {
            logger.LogWarning(exception, message);
        }
    }

    private static void AddNamedProperties(Disposables properties, IEnumerable<(string Name, object Value)> namedProperties)
    {
        namedProperties ??= Array.Empty<(string Name, object Value)>();
        foreach ((string name, object value) in namedProperties)
            properties.Add(LogContext.PushProperty(name, value, true));
    }

    private static Disposables PushProperties(string memberName, string classPath, IEnumerable<(string Name, object Value)> namedValues = null)
    {
        Disposables properties = new Disposables
        {
            LogContext.PushProperty("Environment", new GetEnvironmentCommand().Execute()),
            LogContext.PushProperty("MemberName", memberName),
            LogContext.PushProperty("ClassName", Path.GetFileNameWithoutExtension(classPath))
        };
        AddNamedProperties(properties, namedValues);
        return properties;
    }
}