using Common.Hosting;
using Serilog;
using Tests.Testing;
using Xunit;

namespace Tests.Hosting;

public class HandleTerminationCommandTests
{
    [Fact]
    public void ExecuteMustDisposeGlobalSharedLogger()
    {
        lock (MockLogger.Sync)
        {
            MockLogger logger = new MockLogger();
            Log.Logger = logger;
            Assert.Equal(0, logger.DisposeCalled);
            new HandleTerminationCommand().Execute();
            Assert.Equal(1, logger.DisposeCalled);
        }
    }

    [Fact]
    public void ExecuteMustHandleExceptionGlobalSharedLoggerDisposeThrowsException()
    {
        lock (MockLogger.Sync)
        {
            MockLogger logger = new MockLogger { DisposeException = new Exception() };
            Log.Logger = logger;
            new HandleTerminationCommand().Execute();
            Assert.Equal(1, logger.DisposeCalled);
        }
    }
}