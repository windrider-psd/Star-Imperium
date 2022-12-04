using System.Collections.Generic;

namespace Assets.Source.RuntimeResources
{
    public abstract class ResourceDatabase<K, V>
    {
        protected Dictionary<K, V> resources = new();

        public abstract void LoadDefaultResources();
    }
}