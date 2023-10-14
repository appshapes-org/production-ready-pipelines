using Common.Hosting;
using Xunit;

namespace Tests.Hosting;

public class GetEnvironmentCommandTests
{
    [Fact]
    public void GetEnvironmentName_ReturnsEmptyWhenEnvironmentKeyIsNotSet()
    {
        StubGetEnvironmentCommand command = new StubGetEnvironmentCommand { ShouldReturnNullKey = true };
        Assert.Equal(string.Empty, command.InvokeGetEnvironmentName());
    }

    private class StubGetEnvironmentCommand : GetEnvironmentCommand
    {
        public bool ShouldReturnNullKey { private get; init; }

        public string InvokeGetEnvironmentName()
        {
            return GetEnvironmentName();
        }

        protected override string GetEnvironmentKey()
        {
            return ShouldReturnNullKey ? null! : base.GetEnvironmentKey();
        }
    }
}