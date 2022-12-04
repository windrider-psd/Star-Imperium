using Assets.Source.CustomAttributes;
using Assets.Source.Factions;
using Assets.Source.Managers;
using Assets.Source.Utilities;
using UnityEngine;

namespace Assets.Source.Entities
{
    public class Entity : MonoBehaviour
    {
        public Faction faction;
        public string id;
        private OnDestroyedEventHandler onDestroyed;

        public delegate void OnDestroyedEventHandler(Entity entity);

        public GameCoordinator Coordinator { get => FindObjectOfType<GameCoordinator>(); }
        public OnDestroyedEventHandler OnDestroyed { get => onDestroyed; set => onDestroyed = value; }

        public void OnDestroy()
        {
           // ReflectionUtility.ExecuteMethodsWithAttribute<ExecuteOnDestroyAttribute>(this);
            OnDestroyed?.Invoke(this);
        }
    }
}