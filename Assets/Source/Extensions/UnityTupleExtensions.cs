using Assets.Source.Utilities;
using System.Collections.Generic;

namespace Assets.Source.Extensions
{
    internal static class UnityTupleExtensions
    {
        public static V GetUnityTupleValue<K, V>(this List<UnityTuple<K, V>> list, K key)
        {
            foreach (var kv in list)
            {
                if (kv.key.Equals(key))
                {
                    return kv.value;
                }
            }
            return default;
        }

        public static Dictionary<K, V> ToDictonary<K, V>(this List<UnityTuple<K, V>> list)
        {
            var dict = new Dictionary<K, V>();
            foreach (var kv in list)
            {
                dict.Add(kv.key, kv.value);
            }
            return dict;
        }
    }
}