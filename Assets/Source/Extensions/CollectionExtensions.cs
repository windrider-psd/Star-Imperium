using System;
using System.Collections.Generic;

namespace Assets.Source.Extensions
{
    internal static class CollectionExtensions
    {
        public static V GetHighestValueOfDictonary<K, V>(this Dictionary<K, V> dict, out List<K> output) where V : IComparable<V>
        {
            output = new();

            V lowest = default;

            bool lowestSet = false;

            foreach (var kv in dict)
            {
                if (!lowestSet)
                {
                    lowest = kv.Value;
                    output.Clear();
                    output.Add(kv.Key);
                    lowestSet = true;
                }
                else if (kv.Value.CompareTo(lowest) == 1)
                {
                    lowest = kv.Value;
                    output.Clear();
                    output.Add(kv.Key);
                }
                else if (kv.Value.CompareTo(lowest) == 0)
                {
                    output.Add(kv.Key);
                }
            }
            return lowest;
        }

        public static V GetLowestValueOfDictonary<K, V>(this Dictionary<K, V> dict, out List<K> output) where V : IComparable<V>
        {
            output = new();

            V lowest = default;

            bool lowestSet = false;

            foreach (var kv in dict)
            {
                if (!lowestSet)
                {
                    lowest = kv.Value;
                    output.Clear();
                    output.Add(kv.Key);
                }
                else if (kv.Value.CompareTo(lowest) == -1)
                {
                    lowest = kv.Value;
                    output.Clear();
                    output.Add(kv.Key);
                }
                else if (kv.Value.CompareTo(lowest) == 0)
                {
                    output.Add(kv.Key);
                }
            }
            return lowest;
        }

        public static int ReverseIndex<T>(this List<T> list, int index)
        {
            return Math.Abs(index - list.Count + 1);
        }

        public static void ShallowCopyDictonary<K, V>(this Dictionary<K, V> dict, out Dictionary<K, V> output)
        {
            output = new();

            foreach (var kv in dict)
            {
                output[kv.Key] = kv.Value;
            }
        }
    }
}