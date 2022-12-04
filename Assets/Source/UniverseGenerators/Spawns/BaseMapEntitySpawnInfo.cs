using Assets.Source.Entities;
using Assets.Source.Factions;
using UnityEngine;

namespace Assets.Source.UniverseGenerators.Spawns
{
    public abstract class BaseMapEntitySpawnInfo
    {
        public Faction Faction { get; set; }
        public Quaternion Rotation { get; set; } = Quaternion.identity;
        public Vector3 Scale { get; set; } = Vector3.one;
        public Sector Sector { get; set; }
        public Vector3 SectorLocalPos { get; set; }
    }
}