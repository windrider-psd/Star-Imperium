using Assets.Source.Components;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Source.Entities.Construction
{
    public class BaseChassis
    {
        public int BaseHp { get; set; }
        public int BaseWeight { get; set; }

        public List<ExternalComponentSlot> ExternalComponentSlots
        {
            get => Model.GetComponentsInChildren<ExternalComponentSlot>().ToList();
        }

        public List<InternalComponent> InternalComponents { get; set; } = new();
        public int InternalSpace { get; set; }
        public GameObject Model { get; set; }
        public string Name { get; set; }
    }
}