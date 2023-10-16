using Common.Hosting;
using Serilog;
using Tests.Testing;
using Xunit;

namespace Tests.Hosting;

public class ProcessUnhandledExceptionCommandTests
{
    [Fact]
    public void ExecuteMustExecuteHandleTerminationCommandWhenUnhandledExceptionIsTerminating()
    {
        lock (MockLogger.Sync)
        {
            MockLogger logger = new MockLogger();
            Log.Logger = logger;
            Assert.Equal(0, logger.DisposeCalled);
            new ProcessUnhandledExceptionCommand().Execute(null, new UnhandledExceptionEventArgs(null!, true));
            Assert.Equal(1, logger.DisposeCalled);
        }
    }

    [Fact]
    public void ExecuteMustNotExecuteHandleTerminationCommandWhenUnhandledExceptionIsNotTerminating()
    {
        lock (MockLogger.Sync)
        {
            MockLogger logger = new MockLogger();
            Log.Logger = logger;
            Assert.Equal(0, logger.DisposeCalled);
            new ProcessUnhandledExceptionCommand().Execute(null, new UnhandledExceptionEventArgs(null!, false));
            Assert.Equal(0, logger.DisposeCalled);
        }
    }
}