using System;
using System.Collections.Generic;

namespace Assets.Source.Utilities
{
    public class ConditionalEventSystem<C>
    {
        ///private HashSet<Action> listeners = new();
        private Dictionary<C, HashSet<Action>> dict = new();

        public void AddListener(C condition, Action action)
        {
            if (!dict.ContainsKey(condition))
            {
                dict.Add(condition, new());
            }
            dict[condition].Add(action);
        }

        public void RemoveListener(C condition, Action action)
        {
            if (!dict.ContainsKey(condition))
            {
                dict.Add(condition, new());
            }
            dict[condition].Remove(action);
        }

        public void TriggerListeners(C condition)
        {
            if (dict.TryGetValue(condition, out var listeners))
            {
                foreach (var listener in listeners)
                {
                    listener.Invoke();
                }
            }
        }
    }

    public class ConditionalEventSystem<C, P1>
    {
        ///private HashSet<Action> listeners = new();
        private Dictionary<C, HashSet<Action<P1>>> dict = new();

        public void AddListener(C condition, Action<P1> action)
        {
            if (!dict.ContainsKey(condition))
            {
                dict.Add(condition, new());
            }
            dict[condition].Add(action);
        }

        public void RemoveListener(C condition, Action<P1> action)
        {
            if (!dict.ContainsKey(condition))
            {
                dict.Add(condition, new());
            }
            dict[condition].Remove(action);
        }

        public void TriggerListeners(C condition, P1 parameter)
        {
            if (dict.TryGetValue(condition, out var listeners))
            {
                foreach (var listener in listeners)
                {
                    listener.Invoke(parameter);
                }
            }
        }
    }

    public class ConditionalEventSystem<C, P1, P2>
    {
        ///private HashSet<Action> listeners = new();
        private Dictionary<C, HashSet<Action<P1, P2>>> dict = new();

        public void AddListener(C condition, Action<P1, P2> action)
        {
            if (!dict.ContainsKey(condition))
            {
                dict.Add(condition, new());
            }
            dict[condition].Add(action);
        }

        public void RemoveListener(C condition, Action<P1, P2> action)
        {
            if (!dict.ContainsKey(condition))
            {
                dict.Add(condition, new());
            }
            dict[condition].Remove(action);
        }

        public void TriggerListeners(C condition, P1 p1, P2 p2)
        {
            if (dict.TryGetValue(condition, out var listeners))
            {
                foreach (var listener in listeners)
                {
                    listener.Invoke(p1, p2);
                }
            }
        }
    }

    /*
    public class ConditionalEventSystem<T>
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
    public class ConditionalEventSystem<T1, T2>
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
    }*/
}