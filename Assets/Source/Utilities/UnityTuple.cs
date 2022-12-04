using System;

namespace Assets.Source.Utilities
{
    [Serializable]
    public class UnityTuple<K, V>
    {
        public K key;
        public V value;

        public override string ToString()
        {
            return $"{{key: {key}, value: {value}}}";
        }
    }
}