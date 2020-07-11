using System.Collections.Generic;

public class Observable<T>
{
    List<IObserver<T>> observers = new List<IObserver<T>>();

    public T Propriety { get; set; }

    public void Register(IObserver<T> observer)
    {
        if (!observers.Contains(observer))
            observers.Add(observer);
    }

    public void Unregister(IObserver<T> observer)
    {
        if (observers.Contains(observer))
            observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in observers)
        {
            observer.UpdatePropriety(Propriety);
        }
    }
}
