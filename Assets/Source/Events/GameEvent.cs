using System.Collections.Generic;

namespace Assets.Source.Events
{
    public class GameEvent
    {
        private Dictionary<object, object> data = new();
        private string name;

        public GameEvent(string name)
        {
            Name = name;
        }

        public GameEvent(string name, Dictionary<object, object> data) : this(name)
        {
            Data = data;
        }

        public Dictionary<object, object> Data { get => data; set => data = value; }
        public string Name { get => name; set => name = value; }
    }
}