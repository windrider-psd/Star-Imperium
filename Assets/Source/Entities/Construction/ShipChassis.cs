using Assets.Source.Components;
using System.Linq;

namespace Assets.Source.Entities.Construction
{
    public enum ShipChassisType
    {
        Nova
    }

    public static class DefaultShipChassis
    {
        public static ShipChassis GetDefault(ShipChassisType type)
        {
            switch (type)
            {
                case ShipChassisType.Nova:
                    return new()
                    {
                        Name = "Nova Base Chassis",
                        BaseHp = 300,
                        BaseWeight = 100,
                        Type = ShipChassisType.Nova,
                        InternalSpace = 70
                    };

                default:
                    return default;
            }
        }
    }

    public class ShipChassis : BaseChassis
    {
        public ExternalComponentSlot EngineSlot
        {
            get => ExternalComponentSlots.First((i) => i.ExternalComponentType == ExternalComponentType.Engine);
        }

        public ExternalComponentSlot ThrusterSlot
        {
            get => ExternalComponentSlots.First((i) => i.ExternalComponentType == ExternalComponentType.Thruster);
        }

        public Engine Engine
        {
            get => EngineSlot.ExternalComponent as Engine;
        }

        public Thruster Thruster
        {
            get => ThrusterSlot.ExternalComponent as Thruster;
        }

        public ShipChassisType Type { get; set; }
    }
}