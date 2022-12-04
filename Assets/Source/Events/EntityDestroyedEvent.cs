using Assets.Source.Entities;

namespace Assets.Source.Events
{
    public class EntityDestroyedEvent : CombatEvent
    {
        public EntityDestroyedEvent(MapEntity source, MapEntity target) : base(source, target, "Entity Destroyed")
        {
        }

        public EntityDestroyedEvent(MapEntity source, MapEntity target, string name) : base(source, target, name)
        {
        }
    }
}