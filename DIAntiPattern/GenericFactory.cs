using System;

namespace DIAntiPattern
{
    public class GenericFactory
    {
        public static Func<object> CreationClosure;
        public T GetDefault<T>()
        {
            return (T) CreationClosure();//executes closure
        }
    }
}