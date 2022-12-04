using Assets.Source.Managers;
using UnityEngine;

namespace Assets.Source.Test
{
    public class ShipMovementTest : MonoBehaviour
    {
        public bool accelerating;
        public float breakAcceleration;
        public float deaccelerationVelocity;
        public float forwardAcceleration;
        public float forwardMaxSpeed;
        public float reverseMaxSpeed;
        public bool reversing;
        public float rotationVelocity;
        public float speed;
        public bool turningLeft;
        public bool turningRight;

        private GameCoordinator coordinator;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawRay(transform.position, transform.up);
        }

        // Use this for initialization
        private void Start()
        {
            coordinator = FindObjectOfType<GameCoordinator>();

            coordinator.ControlMapManager.OnBindingStateChanged.AddListener(Options.KeyBindingCode.Accelerate, (bool value) =>
            {
                accelerating = value;
            });

            coordinator.ControlMapManager.OnBindingStateChanged.AddListener(Options.KeyBindingCode.Break, (bool value) =>
            {
                reversing = value;
            });

            coordinator.ControlMapManager.OnBindingStateChanged.AddListener(Options.KeyBindingCode.TurnLeft, (bool value) =>
            {
                turningLeft = value;
            });

            coordinator.ControlMapManager.OnBindingStateChanged.AddListener(Options.KeyBindingCode.TurnRight, (bool value) =>
            {
                turningRight = value;
            });
        }

        // Update is called once per frame
        private void Update()
        {
            if (accelerating)
            {
                speed += forwardAcceleration * Time.deltaTime;
                if (speed > forwardMaxSpeed)
                {
                    speed = forwardMaxSpeed;
                }
            }

            if (reversing)
            {
                speed -= (deaccelerationVelocity + breakAcceleration) * Time.deltaTime;
                if (speed < -reverseMaxSpeed)
                {
                    speed = -reverseMaxSpeed;
                }
            }
            if (!accelerating && !reversing)
            {
                var previousSpeed = speed;

                if (speed < 0)
                {
                    speed += (deaccelerationVelocity) * Time.deltaTime;
                }
                else if (speed > 0)
                {
                    speed -= (deaccelerationVelocity) * Time.deltaTime;
                }

                if ((previousSpeed <= 0 && speed > 0) || (previousSpeed >= 0 && speed < 0))
                {
                    speed = 0;
                }
            }

            if (speed != 0)
                transform.position += transform.up * speed * Time.deltaTime;

            if (turningLeft)
                transform.rotation *= Quaternion.AngleAxis(rotationVelocity * Time.deltaTime, transform.forward);

            if (turningRight)
                transform.rotation *= Quaternion.AngleAxis(rotationVelocity * Time.deltaTime, -transform.forward);
        }
    }
}