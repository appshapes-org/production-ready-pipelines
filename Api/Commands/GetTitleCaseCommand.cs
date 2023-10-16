using System.Globalization;
using Common.Logging;

namespace Api.Commands;

public class GetTitleCaseCommand
{
    private readonly ILogger<GetTitleCaseCommand> _logger;

    public GetTitleCaseCommand(ILogger<GetTitleCaseCommand> logger)
    {
        _logger = logger;
    }

    public virtual string Execute(string text)
    {
        string titleCase = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text);
        _logger.Information("Converted {text} to {titleCase}", text, titleCase);
        return titleCase;
    }
}