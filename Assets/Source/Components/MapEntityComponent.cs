using Assets.Source.Entities;
using Assets.Source.Utilities;

namespace Assets.Source.Components
{
    public abstract class MapEntityComponent : ICloneable<MapEntityComponent>
    {
        public MapEntity MapEntity { get; set; }

        public virtual void Update()
        {

        }
        public abstract MapEntityComponent Clone();
    }
}