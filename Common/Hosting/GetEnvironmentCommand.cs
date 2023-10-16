namespace Common.Hosting;

public class GetEnvironmentCommand
{
    private static string _environmentName;

    public virtual string Execute()
    {
        _environmentName ??= GetEnvironmentName();
        return _environmentName;
    }

    protected virtual string GetEnvironmentKey()
    {
        string key = Environment.GetEnvironmentVariables().Keys.Cast<string>().FirstOrDefault(IsEnvironmentKey);
        return key;
    }

    protected virtual List<string> GetEnvironmentKeys()
    {
        return new List<string> { "DOTNET_ENVIRONMENT", "ASPNETCORE_ENVIRONMENT" };
    }

    protected virtual string GetEnvironmentName()
    {
        string key = GetEnvironmentKey();
        return key == null ? string.Empty : Environment.GetEnvironmentVariable(key);
    }

    protected virtual bool IsEnvironmentKey(string key)
    {
        List<string> keys = GetEnvironmentKeys();
        return keys.Exists(x => string.Equals(x, key, StringComparison.OrdinalIgnoreCase));
    }
}