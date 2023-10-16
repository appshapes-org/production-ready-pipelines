namespace Common.Hosting;

public class ProcessUnhandledExceptionCommand
{
    public virtual void Execute(object _, UnhandledExceptionEventArgs e)
    {
        if (e.IsTerminating)
            new HandleTerminationCommand().Execute();
    }
}