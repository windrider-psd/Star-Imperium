using System;
using System.Collections.Generic;

namespace Assets.Source.Utilities
{
    public class GenericEventSystem
    {
        private HashSet<Action> listeners = new();

        public void AddListener(Action action)
        {
            listeners.Add(action);
        }

        public void RemoveListener(Action action)
        {
            listeners.Remove(action);
        }

        public void TriggerListeners()
        {
            foreach (var listener in listeners)
            {
                listener.Invoke();
            }
        }
    }

    public class GenericEventSystem<T>
    {
        private HashSet<Action<T>> listeners = new();

        public void AddListener(Action<T> action)
        {
            listeners.Add(action);
        }

        public void RemoveListener(Action<T> action)
        {
            listeners.Remove(action);
        }

        public void TriggerListeners(T parameter)
        {
            foreach (var listener in listeners)
            {
                listener.Invoke(parameter);
            }
        }
    }

    public class GenericEventSystem<T1, T2>
    {
        private HashSet<Action<T1, T2>> listeners = new();

        public void AddListener(Action<T1, T2> action)
        {
            listeners.Add(action);
        }

        public void RemoveListener(Action<T1, T2> action)
        {
            listeners.Remove(action);
        }

        public void TriggerListeners(T1 parameter, T2 parameter2)
        {
            foreach (var listener in listeners)
            {
                listener.Invoke(parameter, parameter2);
            }
        }
    }
}