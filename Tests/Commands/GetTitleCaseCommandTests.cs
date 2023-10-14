using Api.Commands;
using Xunit;

namespace Tests.Commands;

public class GetTitleCaseCommandTests
{
    [Fact]
    public void Execute_ReturnsTitleCaseWhenValueIsNotUppercase()
    {
        Assert.Equal("The Answer Is 42", new GetTitleCaseCommand().Execute("the answer is 42"));
    }
}
