using Assets.Source.Events;
using Assets.Source.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Assets.Source.Managers
{
    public class GameEventManager : MonoBehaviourSingleton<GameEventManager>
    {
        private Dictionary<Type, HashSet<EventSubscriber>> subscribers = new();

        public delegate void EventSubscriber(GameEvent @event);

        public void FireEvent(GameEvent @event)
        {
            RemoveNulls();

            foreach (var kv in subscribers)
            {
                Type t = @event.GetType();

                if (kv.Key.GetType().IsInstanceOfType(t))
                {
                    foreach (var sub in kv.Value)
                    {
                        sub.Invoke(@event);
                    }
                }
            }
        }

        public void Subscribe<T>(T eventType, EventSubscriber subscriber) where T : Type
        {
            if (eventType is GameEvent)
            {
                subscribers[eventType].Add(subscriber);
            }
        }

        public void Unsubscribe<T>(T eventType, EventSubscriber subscriber) where T : Type
        {
            if (eventType is GameEvent)
            {
                subscribers[eventType].Remove(subscriber);
            }
        }

        private static IEnumerable<Type> GetEnumerableOfType(Type t)
        {
            List<Type> objects = new();
            foreach (Type type in
                Assembly.GetAssembly(t).GetTypes()
                .Where(myType => myType.IsClass && (myType.Equals(t) || myType.IsSubclassOf(t))))
            {
                objects.Add(type);
            }
            
            return objects;
        }

        private void Awake()
        {
            var events = GetEnumerableOfType(typeof(GameEvent));

            foreach (var @event in events)
            {
                subscribers.Add(@event, new());
            }
        }

        private void RemoveNulls()
        {
            foreach (var kv in subscribers)
            {
                kv.Value.RemoveWhere((item) => item == null);
            }
        }
    }
}