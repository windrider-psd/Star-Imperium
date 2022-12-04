using Assets.Source.Entities.Construction;
using Assets.Source.Managers;
using System.Collections;
using UnityEngine;

namespace Assets.Source.UniverseGenerators
{
    public class UniverseCreateShipPreSpawn : MonoBehaviour
    {
        public ShipDefaultPreset preset;
        public DefaultFaction faction;
        public bool ownedByPlayer;
    }
}