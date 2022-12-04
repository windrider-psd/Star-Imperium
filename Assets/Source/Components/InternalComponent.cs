using Assets.Source.Miscellaneous;
using UnityEngine;

namespace Assets.Source.Components
{
    public class InternalComponent : MapEntityComponent
    {
        public int Size { get; set; }

        public override MapEntityComponent Clone()
        {
            return new InternalComponent()
            {
                MapEntity = MapEntity,
                Size = Size
            };
        }
    }
}