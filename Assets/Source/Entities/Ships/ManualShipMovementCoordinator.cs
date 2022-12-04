using Assets.Source.Managers;
using UnityEngine;

namespace Assets.Source.Entities.Ships
{
    public class ManualShipMovementCoordinator : MonoBehaviour
    {
        public bool turningLeft;
        public bool turningRight;
        
        private ControlMapManager controlMapManager;

        Ship ship;

        private void Start()
        {
            
            controlMapManager = FindObjectOfType<ControlMapManager>();

            ship = GetComponent<Ship>();

            controlMapManager.OnBindingStateChanged.AddListener(Options.KeyBindingCode.Accelerate, (bool value) =>
            {
                ship.ShipChassis.Engine.Accelerating = value;
            });

            controlMapManager.OnBindingStateChanged.AddListener(Options.KeyBindingCode.Reverse, (bool value) =>
            {   
                ship.ShipChassis.Engine.Reversing = value;
            });

            controlMapManager.OnBindingActivated.AddListener(Options.KeyBindingCode.Break, () =>
            {
                ship.ShipChassis.Engine.Breaking = true;
            });

            controlMapManager.OnBindingActivated.AddListener(Options.KeyBindingCode.TurnLeft, () =>
            {              
                ship.ShipChassis.Thruster.TurnLeft();
            });

            controlMapManager.OnBindingActivated.AddListener(Options.KeyBindingCode.TurnRight, () =>
            {
               ship.ShipChassis.Thruster.TurnRight();
            });
        }

        private void Update()
        {

        }
    }
}