using Api.Commands;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace Tests.Commands;

public class GetTitleCaseCommandTests
{
    [Fact]
    public void Execute_ReturnsTitleCaseWhenValueIsNotUppercase()
    {
        Assert.Equal("The Answer Is 42", new GetTitleCaseCommand(NullLogger<GetTitleCaseCommand>.Instance)
            .Execute("the answer is 42"));
    }
}
