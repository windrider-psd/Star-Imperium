using UnityEngine;

namespace Assets.Source.Components
{
    public enum EngineType
    {
        NovaMk1
    }

    public static class EngineSolver
    {
        public static Engine Resolve(EngineType type)
        {
            switch (type)
            {
                case EngineType.NovaMk1:
                    return new()
                    {
                        EngineData = new()
                        {
                            breakAcceleration = 3,
                            deaccelerationSpeed = 1,
                            forwardAcceleration = 10,
                            forwardMaxSpeed = 20,
                            reverseMaxSpeed = 10
                        }
                    };

                default:
                    return default;
            }
        }
    }
    public class Engine : ExternalComponent
    {
        private bool breaking;
        private bool reversing;
        private bool accelerating;
        private float currenetSpeed;

        public bool Accelerating
        {
            get => accelerating;
            set
            {
                accelerating = value;
                if (value)
                {
                    breaking = false;
                    reversing = false;
                }
            }
        }
        public bool Reversing
        {
            get => reversing;
            set
            {
                reversing = value;
                if (value)
                {
                    breaking = false;
                    accelerating = false;
                }
            }
        }
        public bool Breaking
        {
            get => breaking;
            set
            {
                breaking = value;
                if (value)
                {
                    reversing = false;
                    accelerating = false;
                }
                else
                {
                    Debug.Log("Wah");
                }
            }
        }


        public float CurrenetSpeed { get => currenetSpeed; set => currenetSpeed = value; }
        public EngineData EngineData { get; set; }


        public override MapEntityComponent Clone()
        {
            return new Engine()
            {
                MapEntity = this.MapEntity,
                ExternalComponentSlot = ExternalComponentSlot,
                ScaleClassification = ScaleClassification,
                Type = Type,
                Weight = Weight,
                Accelerating = Accelerating,
                CurrenetSpeed = CurrenetSpeed,
                EngineData = EngineData,
                Reversing = Reversing,
                Breaking = Breaking
            };
        }

        public override void Update()
        {
            if (Accelerating)
            {
                CurrenetSpeed += EngineData.forwardAcceleration * Time.deltaTime;
                if (CurrenetSpeed > EngineData.forwardMaxSpeed)
                {
                    CurrenetSpeed = EngineData.forwardMaxSpeed;
                }
            }

            else if (Reversing)
            {
                CurrenetSpeed -= (EngineData.deaccelerationSpeed + EngineData.breakAcceleration) * Time.deltaTime;
                if (CurrenetSpeed < -EngineData.reverseMaxSpeed)
                {
                    CurrenetSpeed = -EngineData.reverseMaxSpeed;
                }

                Debug.Log(CurrenetSpeed);

            }

            else if (Breaking)
            {
                var previousSpeed = CurrenetSpeed;

                if (CurrenetSpeed > 0)
                {
                    CurrenetSpeed -= (EngineData.deaccelerationSpeed + EngineData.breakAcceleration) * Time.deltaTime;

                    if (CurrenetSpeed < -EngineData.reverseMaxSpeed)
                    {
                        CurrenetSpeed = -EngineData.reverseMaxSpeed;
                    }
                }

                if (CurrenetSpeed < 0)
                {
                    CurrenetSpeed += EngineData.forwardAcceleration * Time.deltaTime;
                    if (CurrenetSpeed > EngineData.forwardMaxSpeed)
                    {
                        CurrenetSpeed = EngineData.forwardMaxSpeed;
                    }
                }

                if ((previousSpeed <= 0 && CurrenetSpeed > 0) || (previousSpeed >= 0 && CurrenetSpeed < 0))
                {
                    CurrenetSpeed = 0;
                }
            }



            /*
            if (!Accelerating && !Reversing)
            {
                var previousSpeed = CurrenetSpeed;

                if (CurrenetSpeed < 0)
                {
                    CurrenetSpeed += (EngineData.deaccelerationSpeed) * Time.deltaTime;
                }
                else if (CurrenetSpeed > 0)
                {
                    CurrenetSpeed -= (EngineData.deaccelerationSpeed) * Time.deltaTime;
                }

                if ((previousSpeed <= 0 && CurrenetSpeed > 0) || (previousSpeed >= 0 && CurrenetSpeed < 0))
                {
                    CurrenetSpeed = 0;
                }
            }*/

            if (CurrenetSpeed != 0)
                MapEntity.transform.position += MapEntity.transform.up * CurrenetSpeed * Time.deltaTime;
        }
    }

    public struct EngineData
    {
        public float breakAcceleration;
        public float deaccelerationSpeed;
        public float forwardAcceleration;
        public float forwardMaxSpeed;
        public float reverseMaxSpeed;
    }
}