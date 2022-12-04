using Assets.Source.Entities;

namespace Assets.Source.Events
{
    public class CombatEvent : GameEvent
    {
        public CombatEvent(MapEntity source, MapEntity target) : base("Combat Event")
        {
            Source = source;
            Target = target;
        }

        public CombatEvent(MapEntity source, MapEntity target, string name) : base(name)
        {
            Source = source;
            Target = target;
        }

        public MapEntity Source { get; private set; }
        public MapEntity Target { get; private set; }
    }
}