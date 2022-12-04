using Assets.Source.Components;
using Assets.Source.Entities.Construction;
using Assets.Source.UniverseGenerators;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Managers
{
    public enum ShipDefaultPreset
    {
        GenericNova
    }

    public static class ShipDefaultPresetSolver
    {
        public static ShipBuildConfigurationPreset Resolve(ShipDefaultPreset preset)
        {
            return preset switch
            {
                ShipDefaultPreset.GenericNova => new()
                {
                    BuildConfiguration = new()
                    {
                        ShipChassisType = ShipChassisType.Nova,
                        InternalComponents = new(),
                        ExternalComponents = new()
                        {
                            {0, EngineSolver.Resolve(EngineType.NovaMk1) },
                            {1, ThrusterSolver.Resolve(ThrusterType.GenericMk1) }
                        }
                    },
                    Id = ShipBuildConfigurationPreset.defaltIds[preset]
                },
                _ => default,
            };
        }
    }

    public class ShipBuildConfigurationPreset
    {
        public static Dictionary<ShipDefaultPreset, string> defaltIds = new()
        {
            { ShipDefaultPreset.GenericNova, "GenericNova" }
        };

        public ShipBuildConfiguration BuildConfiguration;
        public string Id;

        public override bool Equals(object obj)
        {
            return obj is ShipBuildConfigurationPreset preset &&
                   Id == preset.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }

    public class ShipPresetsManager : MonoBehaviour
    {
        public Dictionary<string, ShipBuildConfigurationPreset> presets = new();
        public Dictionary<ShipDefaultPreset, string> defaultPresetIds = new();


        public void Awake()
        {
            LoadDefault();
        }

        public void LoadDefault()
        {
            foreach (ShipDefaultPreset shipDefaultPreset in Enum.GetValues(typeof(ShipDefaultPreset)))
            {
                var preset = ShipDefaultPresetSolver.Resolve(shipDefaultPreset);
                presets.Add(preset.Id, ShipDefaultPresetSolver.Resolve(shipDefaultPreset));
                defaultPresetIds[shipDefaultPreset] = preset.Id;
            }
        }

        public ShipBuildConfigurationPreset GetPreset(string id)
        {
            return presets[id];
        }
    }
}