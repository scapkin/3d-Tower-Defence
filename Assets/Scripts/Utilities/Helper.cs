using System;
using System.Collections.Generic;

namespace Utilities
{
    public static class Helper
    {
        public static T GetLowestFromList<T>(this List<T> list, Func<T, float> predicate)
        {
            if (list.Count <= 0) throw new Exception("List cannot be null");

            var lowest = predicate(list[0]);
            var lowestIdx = 0;
            for (var i = 0; i < list.Count; i++)
            {
                var value = predicate(list[i]);

                if (!(value < lowest)) continue;
                lowestIdx = i;
                lowest = value;
            }

            return list[lowestIdx];
        }

        public static T GetLowestFromArray<T>(this T[] array, Func<T, float> predicate)
        {
            if (array.Length <= 0) throw new Exception("List cannot be null");

            var lowest = predicate(array[0]);
            var lowestIdx = 0;
            for (var i = 0; i < array.Length; i++)
            {
                var value = predicate(array[i]);

                if (!(value < lowest)) continue;
                lowestIdx = i;
                lowest = value;
            }

            return array[lowestIdx];
        }

        public static T GetHighestFromList<T>(this List<T> list, Func<T, float> predicate)
        {
            if (list.Count <= 0) throw new Exception("List cannot be null");

            var highest = predicate(list[0]);
            var highestIdx = 0;
            for (var i = 0; i < list.Count; i++)
            {
                var value = predicate(list[i]);

                if (!(value > highest)) continue;
                highestIdx = i;
                highest = value;
            }

            return list[highestIdx];
        }

        public static T GetHighestFromArray<T>(this T[] array, Func<T, float> predicate)
        {
            if (array.Length <= 0) throw new Exception("List cannot be null");

            var highest = predicate(array[0]);
            var highestIdx = 0;
            for (var i = 0; i < array.Length; i++)
            {
                var value = predicate(array[i]);

                if (!(value > highest)) continue;
                highestIdx = i;
                highest = value;
            }

            return array[highestIdx];
        }
    }
}