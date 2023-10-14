using Serilog;

namespace Common.Hosting;

public class HandleTerminationCommand
{
    public virtual void Execute()
    {
        try
        {
            Log.CloseAndFlush();
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
        }
    }
}