using Assets.Source.Entities;
using Assets.Source.Entities.Miscellaneous;
using Assets.Source.Entities.Ships;
using Assets.Source.Factions;
using Assets.Source.UniverseGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Assets.Source.Managers
{
    public class GameLoadManager : MonoBehaviour
    {
        public void StartUniverse(UniverseStartInfo startInfo)
        {

            FactionDatabaseManager factionDatabaseManager = FindObjectOfType<FactionDatabaseManager>();
            SpawnManager spawnManager = FindObjectOfType<SpawnManager>();
            ShipPresetsManager shipPresetsManager = FindObjectOfType<ShipPresetsManager>();

            factionDatabaseManager.LoadDefaultFactions();
            Faction playerFaction = new()
            {
                Behaviour = FactionBehaviour.Player,
                Name = "Player Faction",
                Description = "Wah",
            };

            factionDatabaseManager.AddFaction(playerFaction);
            factionDatabaseManager.PlayerFaction = playerFaction;

            foreach(var sector in FindObjectsOfType<Sector>())
            {
                foreach(var belt in sector.GetComponentsInChildren<AsteroidBelt>())
                {
                    belt.SpawnBelt();
                }
                foreach(var ss in sector.GetComponentsInChildren<UniverseCreateShipPreSpawn>())
                {
                    spawnManager.SpawnShip(new()
                    {
                        Faction = ss.ownedByPlayer ? playerFaction : factionDatabaseManager.Factions.First(f => f.Id == factionDatabaseManager.defaultFactionIds[ss.faction]),
                        Sector = sector,
                        SectorLocalPos = ss.transform.localPosition,
                        ShipBuildConfiguration = shipPresetsManager.presets[shipPresetsManager.defaultPresetIds[ss.preset]].BuildConfiguration,
                        Rotation = ss.transform.rotation,
                        Scale = ss.transform.localScale
                    });
                }
            }


            var selectedPlayerShip = factionDatabaseManager.PlayerFaction.Entities.Where(e => e is Ship).ToList()[0];

            if(selectedPlayerShip != null)
            {
                selectedPlayerShip.gameObject.AddComponent<ManualShipMovementCoordinator>();
                selectedPlayerShip.gameObject.GetComponent<AutoShipMovementCoordinator>().enabled = false;
                FindObjectOfType<ShipCamera>().transform.position = new(selectedPlayerShip.transform.position.x, selectedPlayerShip.transform.position.y, FindObjectOfType<ShipCamera>().transform.position.z);
                FindObjectOfType<ShipCamera>().target_object = selectedPlayerShip.gameObject.transform;
            }
        }

        public void Start()
        {
            StartUniverse(new());
        }
    }
}
