using Serilog;
using Serilog.Events;

namespace Tests.Testing;

public class MockLogger : ILogger, IDisposable
{
    public static object Sync = new object();

    public int DisposeCalled { get; private set; }

    public Exception DisposeException { get; set; } = null!;

    public void Dispose()
    {
        ++DisposeCalled;
        if (DisposeException != null)
            throw DisposeException;
    }

    public void Write(LogEvent _)
    {
    }
}