using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Utilities
{
    internal class UnityObjectPool
    {
        private static UnityObjectPoolRoot _poolRoot;
        private static Dictionary<object, UnityObjectPool> _pools = new Dictionary<object, UnityObjectPool>();
        private List<UnityPooledObject> _free = new List<UnityPooledObject>();
        private UnityPooledObject _prefab;

        public UnityObjectPool(UnityPooledObject prefab)
        {
            _prefab = prefab;
        }

        public List<UnityPooledObject> freeObjects => _free;

        public UnityPooledObject prefab
        {
            get { return _prefab; }
        }

        public static void ClearPools()
        {
            foreach (UnityObjectPool pool in _pools.Values)
            {
                pool.Clear();
            }

            _pools = new Dictionary<object, UnityObjectPool>();
        }

        public static UnityObjectPool Get<T>(T prefab) where T : UnityPooledObject
        {
            UnityObjectPool pool;
            if (!_pools.TryGetValue(prefab, out pool))
            {
                pool = new UnityObjectPool(prefab);
                _pools[prefab] = pool;
            }

            return pool;
        }

        public static T Instantiate<T>(T prefab) where T : UnityPooledObject
        {
            return Instantiate(prefab, Vector3.zero, Quaternion.identity);
        }

        public static T Instantiate<T>(T prefab, Vector3 pos, Quaternion q, Transform parent = null) where T : UnityPooledObject
        {
            return (T)Get(prefab).Instantiate(pos, q, parent);
        }

        public static T Instantiate<T>(Vector3 pos, Quaternion q, Transform parent = null) where T : UnityPooledObject
        {
            UnityObjectPool pool;
            if (!_pools.TryGetValue(typeof(T), out pool))
            {
                GameObject go = new GameObject("Prefab<" + typeof(T).Name + ">");
                go.SetActive(false);
                T prefab = go.AddComponent<T>();
                pool = new UnityObjectPool(prefab);
                _pools[typeof(T)] = pool;
            }

            return (T)pool.Instantiate(pos, q, parent);
        }

        public static void Recycle(UnityPooledObject po)
        {
            if (po != null)
            {
                if (po.pool == null)
                {
                    po.gameObject.SetActive(false); // Should always disable before re-parenting, or we will dirty it twice
                    po.transform.SetParent(null, false);
                    Object.Destroy(po.gameObject);
                }
                else
                {
                    po.pool._free.Add(po);
                    if (_poolRoot == null)
                    {
                        _poolRoot = MonoBehaviourSingleton<UnityObjectPoolRoot>.Instance;
                        _poolRoot.name = "ObjectPoolRoot";
                    }

                    po.gameObject.SetActive(false); // Should always disable before re-parenting, or we will dirty it twice
                    po.transform.SetParent(_poolRoot.transform, false);
                }
            }
        }

        public UnityPooledObject Instantiate()
        {
            return Instantiate(_prefab.transform.position, _prefab.transform.rotation);
        }

        public UnityPooledObject Instantiate(Vector3 p, Quaternion q, Transform parent = null)
        {
            UnityPooledObject newt = null;

            if (_free.Count > 0)
            {
                var t = _free[0];
                if (t) // In case a recycled object was destroyed
                {
                    Transform xform = t.transform;
                    xform.SetParent(parent, false);
                    xform.position = p;
                    xform.rotation = q;
                    newt = t;
                }
                else
                {
                    Debug.LogWarning("Recycled object of type <" + _prefab + "> was destroyed - not re-using!");
                }

                _free.RemoveAt(0);
            }

            if (newt == null)
            {
                newt = Object.Instantiate(_prefab, p, q, parent);
                newt.name = "Instance(" + newt.name + ")";
                newt.pool = this;
            }

            newt.OnRecycled();
            newt.gameObject.SetActive(true);
            return newt;
        }

        private void Clear()
        {
            foreach (var pooled in _free)
            {
                Object.Destroy(pooled);
            }

            _free = new List<UnityPooledObject>();
        }
    }
}