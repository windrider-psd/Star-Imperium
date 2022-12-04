using Assets.Source.Components;
using Assets.Source.Factions;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Entities.Construction
{
    internal class ShipConstructionInfo
    {
        public List<InternalComponent> InternalComponents = new();
        public Vector3 SectorLocalPosition;
        public ShipChassis Chassis { get; set; }
        public Faction Faction { get; set; }
        public Sector Sector { get; set; }
    }
}