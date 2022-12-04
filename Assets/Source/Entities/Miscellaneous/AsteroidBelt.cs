using Assets.Source.Extensions;
using Assets.Source.Managers;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Entities.Miscellaneous
{
    public class AsteroidBelt : MonoBehaviour
    {
        public GameObject asteroidPrefab;
        public int radius;
        public List<AsteroidBeltSection> sections;
        public Sector Sector { get => GetComponentInParent<Sector>(); }
        public float usableCircurference;



        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, radius);
        }

        public void SpawnBelt()
        {
            if (sections.Count == 0) return;

            double distribution = usableCircurference / sections.Count;
            var r = new System.Random();
            
            SpawnManager spawnManager = FindObjectOfType<SpawnManager>();
            for (int i = 0; i < sections.Count; i++)
            {
                var section = sections[i];
                double minrange = i * distribution;
                double maxrange = (1 + i) * distribution;

                for (int j = 0; j < section.numberOfAsteroids; j++)
                {
                    double angle = r.NextDouble(minrange, maxrange);
                    double teta = angle * Math.PI / 180;

                    var initialPosition = new Vector3((float)(transform.position.x + radius * Math.Cos(teta)), (float)(transform.position.y + radius * Math.Sin(teta)), transform.position.z);
                    var direction = (transform.position - initialPosition).normalized;

                    bool inwards = r.NextBoolean();
                    double dislocation;

                    if (inwards)
                    {
                        dislocation = r.NextDouble(0.0, section.maxInwardsDistance);
                    }
                    else
                    {
                        dislocation = r.NextDouble(0.0, section.maxOutwardsDistance);
                    }

                    if (!inwards)
                    {
                        direction *= -1;
                    }

                    var position = initialPosition + direction * (float)dislocation;
                    //var asteroid = Instantiate(asteroidPrefab, position, Quaternion.identity).GetComponent<Asteroid>();
                    //asteroid.Sector = sector;

                    spawnManager.SpawnAsteroid(new()
                    {
                        Faction = null,
                        Sector = Sector,
                        SectorLocalPos = Sector.transform.InverseTransformPoint(position)
                    });
                }
            }
            Sector.DrawGrid();
        }

        [Serializable]
        public struct AsteroidBeltSection
        {
            public int maxInwardsDistance;
            public int maxOutwardsDistance;
            public int numberOfAsteroids;
        }
    }
}