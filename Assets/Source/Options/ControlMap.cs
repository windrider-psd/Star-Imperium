using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Options
{
    public class ControlMap : HashSet<KeyBinding>
    {
        public void AssignBinding(KeyBindingCode code, KeyCode key, KeyBindingTriggerCondition triggerCondition)
        {
            this.Add(new(code, key, triggerCondition));
        }
    }
}