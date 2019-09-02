/*胡明涛 2017-07-05*/
/*给所有数组扩展高阶函数*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriticalMass.TagNode.Utility
{ 
    public static class EList
    {
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> lt, Predicate<T> func)
        {
            foreach (T item in lt)
            {
                if (func(item))
                {
                    yield return item;
                }
            }
        }
        public static IEnumerable<R> Map<T, R>(this IEnumerable<T> lt, Func<T, R> func)
        {
            foreach (T item in lt)
            {
                yield return func(item);
            }
        }

        public static void Each<T>(this IEnumerable<T> lt, Action<T> action)
        {
            foreach (T item in lt)
            {
                action(item);
            }
        }

        public static void Do<T>(this IEnumerable<T> lt, Action<IEnumerable<T>> action)
        {
            action(lt);
        }

    }
}
