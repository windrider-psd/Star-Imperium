using Assets.Source.Miscellaneous;

namespace Assets.Source.Components
{
    public enum ExternalComponentType
    {
        Engine, Thruster, Turret, ShieldGenerator, Radar
    }

    public abstract class ExternalComponent : MapEntityComponent
    {
        public ExternalComponentSlot ExternalComponentSlot { get; set; }
        public ScaleClassification ScaleClassification { get; set; }
        public ExternalComponentType Type { get; set; }
        public int Weight { get; set; }
    }
}