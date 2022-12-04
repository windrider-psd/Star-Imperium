namespace Assets.Source.Entities.Ships
{
    public abstract class ShipCommand
    {
        public AutoShipMovementCoordinator coordinator;
        public Ship ship;
        public ShipCommandType type;

        public ShipCommand(ShipCommandType type, Ship ship)
        {
            this.type = type;
            this.ship = ship;
            this.coordinator = ship.GetComponent<AutoShipMovementCoordinator>();
        }

        public abstract void Execute();

        public abstract bool IsFinished();

        public virtual void OnRemoved()
        {
        }
    }
}