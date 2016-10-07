using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SexExercise
{
    public static class Sextensions
    {
        public static T FirstOrDefault<T>(this IEnumerable<T> collection, Predicate<T> predicate)
        {
            foreach (var element in collection)
            {
                if(predicate(element))
                {
                    return element;
                }
            }
            return default(T);
        }
        
        public static IEnumerable<T> MyTakeWhile<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            var listche = new List<T>();
            foreach (var item in collection)
            {
                if(predicate(item))
                {
                    listche.Add(item);
                }
                else
                {
                    break;
                }
            }
            return listche;
        }
    }
}
