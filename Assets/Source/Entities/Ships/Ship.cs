using Assets.Source.Entities.Construction;
using Assets.Source.Entities.Data;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Entities.Ships
{
    [RequireComponent(typeof(AutoShipMovementCoordinator))]
    public class Ship : MapActor
    {
        private HashSet<SectorHashGridClient> lastNearby = new();
        public ShipChassis ShipChassis { get; set; }

        public void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;

            Gizmos.DrawWireSphere(transform.position, 30);
        }

        public void Update()
        {
            this.sectorHashGridClient.Update();

            if (sectorHashGridClient != null)
            {
                var nearby = sectorHashGridClient.FindNearby(3);

                foreach (var n in nearby)
                {
                    if (n == this.sectorHashGridClient) continue;

                    var cubeRenderer = n.source.GetComponent<Renderer>();

                    // Call SetColor using the shader property name "_Color" and setting the color to red
                    cubeRenderer.material.SetColor("_Color", Color.red);
                }

                foreach (var n in lastNearby)
                {
                    if (!nearby.Contains(n))
                    {
                        var cubeRenderer = n.source.GetComponent<Renderer>();
                        cubeRenderer.material.SetColor("_Color", Color.white);
                    }
                }
                lastNearby = nearby;
            }
        }

       

    }
}