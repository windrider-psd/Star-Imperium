
#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
namespace Assets.Source.UnityEditorScripts
{

    public static class UniverseCreationPreSpawn
    {
        [MenuItem("GameObject/Custom/ShipSpawn")]
        public static void ShipSpawn() => CreateUtility.CreatePrefab("UniverseGeneration/ShipSpawn");
    }
}

#endif