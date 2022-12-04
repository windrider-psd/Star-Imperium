using UnityEngine;

namespace Assets.Source.Components
{
    public enum ThrusterType
    {
        GenericMk1
    }

    public static class ThrusterSolver
    {
        public static Thruster Resolve(ThrusterType type)
        {
            switch (type)
            {
                case ThrusterType.GenericMk1:
                    return new()
                    {
                        ThrusterData = new()
                        {
                            rotationSpeed = 180
                        }
                    };

                default:
                    return default;
            }
        }
    }

    public class Thruster : ExternalComponent
    {
        public ThrusterData ThrusterData { get; set; }

        public override MapEntityComponent Clone()
        {
            return new Thruster()
            {
                MapEntity = this.MapEntity,
                ExternalComponentSlot = ExternalComponentSlot,
                ScaleClassification = ScaleClassification,
                Type = Type,
                Weight = Weight,
                ThrusterData = new()
                {
                    rotationSpeed = ThrusterData.rotationSpeed
                }
            };
        }
    

        public void TurnLeft()
        {
            MapEntity.gameObject.transform.rotation *= Quaternion.AngleAxis(ThrusterData.rotationSpeed * Time.deltaTime, MapEntity.transform.forward);
        }

        public void TurnRight()
        {
            MapEntity.gameObject.transform.rotation *= Quaternion.AngleAxis(ThrusterData.rotationSpeed * Time.deltaTime, -MapEntity.transform.forward);
        }

        public void TurnTowards(Vector3 position)
        {
            var direction = (position - MapEntity.transform.position).normalized;
            float aangle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(aangle, -MapEntity.transform.forward);
            MapEntity.transform.rotation = Quaternion.RotateTowards(MapEntity.transform.rotation, q, ThrusterData.rotationSpeed * Time.deltaTime);
        }
    }

    public class ThrusterData
    {
        public float rotationSpeed;
    }
}