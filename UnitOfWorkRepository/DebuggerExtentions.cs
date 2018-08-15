using System;
using System.Collections.Generic;

namespace UnitOfWorkRepository
{
    public static class DebuggerExtentions
    {
        public static IEnumerable<T> Output<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (T element in source)
            {
                action(element);
                yield return element;
            }
        }
    }
}
