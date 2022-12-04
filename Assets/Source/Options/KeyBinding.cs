using UnityEngine;

namespace Assets.Source.Options
{
    public class KeyBinding
    {
        public KeyBindingCode code;
        public KeyCode key;
        public KeyBindingTriggerCondition triggerCondition;

        public KeyBinding(KeyBindingCode code, KeyCode key, KeyBindingTriggerCondition triggerCondition)
        {
            this.code = code;
            this.key = key;
            this.triggerCondition = triggerCondition;
        }
    }
}