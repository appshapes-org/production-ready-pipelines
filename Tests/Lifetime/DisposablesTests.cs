using Common.Lifetime;
using Xunit;

namespace Tests.Lifetime;

public class DisposablesTests
{
    [Fact]
    public void DisposeMustDisposeInternalCollectionOfDisposablesWhenOneOrMoreDisposableThrowsException()
    {
        Disposables disposables = new Disposables { new StubDisposable(), new StubDisposable(new Exception()) };
        Assert.NotEmpty(disposables);
        disposables.Dispose();
        Assert.Empty(disposables);
    }

    private class StubDisposable : IDisposable
    {
        private Exception Exception { get; }

        public StubDisposable(Exception exception = null!)
        {
            Exception = exception;
        }

        public void Dispose()
        {
            if (Exception != null)
                throw Exception;
        }
    }
}