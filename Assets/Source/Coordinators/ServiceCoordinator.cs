using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace Assets.Source.Coordinators
{
    public class ServiceCoordinator : MonoBehaviour
    {
        protected HashSet<Component> components = new();

        public void Awake()
        {
            components = GetComponents<Component>().ToHashSet();
        }

        public T GetService<T>()
        {
            return components.OfType<T>().FirstOrDefault();
        }
    }
}