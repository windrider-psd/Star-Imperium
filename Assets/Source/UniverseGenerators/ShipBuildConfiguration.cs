using Assets.Source.Components;
using Assets.Source.Entities.Construction;
using System.Collections.Generic;

namespace Assets.Source.UniverseGenerators
{
    public class ShipBuildConfiguration
    {
        public Dictionary<int, ExternalComponent> ExternalComponents { get; set; }
        public List<InternalComponent> InternalComponents { get; set; }
        public ShipChassisType ShipChassisType { get; set; }
    }
}