using Assets.Source.Entities.Construction;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Managers
{
    public static class RuntimeResourcesConstants
    {
        public static string ShipModelNova = "ShipModels/Nova";
    }

    public class ResourceManager : MonoBehaviour
    {
        private readonly Dictionary<ShipChassisType, GameObject> _defaultShipChassisModel = new();

        private readonly Dictionary<ShipChassisType, string> _defaultShipChassisResource = new()
        {
            {ShipChassisType.Nova, RuntimeResourcesConstants.ShipModelNova }
        };

        public void LoadDefaultResources()
        {
            foreach (ShipChassisType type in Enum.GetValues(typeof(ShipChassisType)))
            {
                var resource = Resources.Load<GameObject>(_defaultShipChassisResource[type]);
                _defaultShipChassisModel.Add(type, resource);
            }
        }

        public GameObject ShipChassis(ShipChassisType type)
        {
            return _defaultShipChassisModel[type];
        }

        private void Awake()
        {
            LoadDefaultResources();
        }
    }
}