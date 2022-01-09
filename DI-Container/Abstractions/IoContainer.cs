using System;

public interface IoContainer
{
    void RegisterClass<T>()
        where T : class;

    void Register<T, R>()
        where R : class, T;

    void RegisterDel<T>(Func<T> factory);

    T Resolve<T>();
}