using Assets.Source.Entities.Data;
using UnityEngine;
using System.Linq;
namespace Assets.Source.Entities.Ships
{
    [RequireComponent(typeof(Ship))]
    public class AutoShipMovementCoordinator : MonoBehaviour
    {
        protected Ship ship;

        protected void Start()
        {
            ship = GetComponent<Ship>();
        }

        protected void Update()
        {

            var nearby = ship.sectorHashGridClient.FindNearby(30);

            if(nearby.Count == 0)
            {
                ship.ShipChassis.Engine.Accelerating = false;
                ship.ShipChassis.Engine.Reversing = false;
            }
            else
            {
                var selected = nearby.ElementAt(0);
                ship.ShipChassis.Engine.Accelerating = true;
                ship.ShipChassis.Thruster.TurnTowards(selected.source.transform.position);
            }



            /*

            if (accelerating)
            {
                ship.speed += ship.forwardAcceleration * Time.deltaTime;
                if (ship.speed > ship.forwardMaxSpeed)
                {
                    ship.speed = ship.forwardMaxSpeed;
                }
            }

            if (reversing)
            {
                ship.speed -= (ship.deaccelerationSpeed + ship.breakAcceleration) * Time.deltaTime;
                if (ship.speed < -ship.reverseMaxSpeed)
                {
                    ship.speed = -ship.reverseMaxSpeed;
                }
            }
            if (!accelerating && !reversing)
            {
                var previousSpeed = ship.speed;

                if (ship.speed < 0)
                {
                    ship.speed += (ship.deaccelerationSpeed) * Time.deltaTime;
                }
                else if (ship.speed > 0)
                {
                    ship.speed -= (ship.deaccelerationSpeed) * Time.deltaTime;
                }

                if ((previousSpeed <= 0 && ship.speed > 0) || (previousSpeed >= 0 && ship.speed < 0))
                {
                    ship.speed = 0;
                }
            }

            if (ship.speed != 0)
                transform.position += transform.up * ship.speed * Time.deltaTime;
             */
        }
    }
}