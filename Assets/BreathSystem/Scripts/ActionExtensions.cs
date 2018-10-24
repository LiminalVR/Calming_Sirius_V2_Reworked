using System;

public static class ActionExtensions
{
    public static void InvokeSafe(this Action action)
    {
        if (action != null)
        {
            action.Invoke();
        }
    }

    public static void InvokeSafe<T>(this Action<T> action, T t)
    {
        if (action != null)
        {
            action.Invoke(t);
        }
    }
}