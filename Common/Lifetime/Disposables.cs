namespace Common.Lifetime;

public class Disposables : List<IDisposable>, IDisposable
{
    public void Dispose()
    {
        foreach (IDisposable disposable in this)
            Dispose(disposable);
        Clear();
    }

    protected virtual void Dispose(IDisposable disposable)
    {
        try
        {
            disposable.Dispose();
        }
        catch
        {
            // swallow exception
        }
    }
}