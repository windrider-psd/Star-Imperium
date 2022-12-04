using UnityEngine;

namespace Assets.Source.Utilities
{
    internal class UnityPooledObject : MonoBehaviour
    {
        public UnityObjectPool pool { get; set; }

        public virtual void OnRecycled()
        {
        }
    }
}