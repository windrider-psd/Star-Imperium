using Assets.Source.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Source.Localization
{
    [CreateAssetMenu(fileName = "library", menuName = "LocalizationLibrary", order = 0)]
    public class LocalizationLibrary : ScriptableObject
    {
        public string prefix;
        public List<UnityTuple<string, List<string>>> keyValues;
    }
}