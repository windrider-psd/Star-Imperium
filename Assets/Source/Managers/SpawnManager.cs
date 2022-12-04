using Assets.Source.Components;
using Assets.Source.Entities;
using Assets.Source.Entities.Construction;
using Assets.Source.Entities.Miscellaneous;
using Assets.Source.Entities.Ships;
using Assets.Source.UniverseGenerators.Spawns;
using Assets.Source.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Source.Managers
{
    public class SpawnManager : MonoBehaviourSingleton<SpawnManager>
    {
        public GameObject asteroidPrefab;

        public List<Sprite> asteroidSprites = new();

        private ResourceManager resourceManager;

        public delegate void OnEntityCreatedEventHandler(Entity entity);

        public event OnEntityCreatedEventHandler OnEntityCreated;

        public void SpawnAsteroid(AsteroidSpawnInfo spawnInfo)
        {
            int index = UnityEngine.Random.Range(0, asteroidSprites.Count);
            var asteroidgo = Instantiate(asteroidPrefab);

            var asteroid = asteroidgo.GetComponent<Asteroid>();
            asteroid.Sprite = asteroidSprites[index];

            SpawnMapEntity(asteroid, spawnInfo);
        }

        public void SpawnMapEntity(MapEntity mapEntity, BaseMapEntitySpawnInfo spawnInfo)
        {
            mapEntity.faction = spawnInfo.Faction;
            mapEntity.Sector = spawnInfo.Sector;
            mapEntity.SectorLocalPosition = spawnInfo.SectorLocalPos;
            mapEntity.UpdateHashGridClientSetup();
            mapEntity.id = Guid.NewGuid().ToString();
            mapEntity.transform.localScale = spawnInfo.Scale;
            mapEntity.transform.rotation = spawnInfo.Rotation;

            OnEntityCreated?.Invoke(mapEntity);
        }

        public void SpawnShip(ShipSpawnInfo info)
        {
            var shipModel = resourceManager.ShipChassis(info.ShipBuildConfiguration.ShipChassisType);
            var chassis = DefaultShipChassis.GetDefault(info.ShipBuildConfiguration.ShipChassisType);

            var instantiatedGO = Instantiate(shipModel);
            var ship = instantiatedGO.GetComponent<Ship>();

            chassis.Model = instantiatedGO;
            
            foreach (var c in info.ShipBuildConfiguration.InternalComponents)
            {
                chassis.InternalComponents.Add(c.Clone() as InternalComponent);
            }

            ship.ShipChassis = chassis;

            var slots = chassis.ExternalComponentSlots;
            foreach (var kv in info.ShipBuildConfiguration.ExternalComponents)
            {
                var found = slots.First((i) => i.Number == kv.Key);

                if (found != null)
                {
                    found.ExternalComponent = kv.Value.Clone() as ExternalComponent;
                    found.ExternalComponent.MapEntity = ship;
                }
            }

            SpawnMapEntity(ship, info);
        }

        private void Awake()
        {
            resourceManager = FindObjectOfType<ResourceManager>();
        }

        private void Start()
        {
        }
    }
}