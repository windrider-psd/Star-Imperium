using Assets.Source.Options;
using Assets.Source.Utilities;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Managers
{
    public class ControlMapManager : MonoBehaviourSingleton<ControlMapManager>
    {
        public Dictionary<KeyBindingCode, bool> activationCache = new();
        private ConditionalEventSystem<KeyBindingCode> onBindingActivated = new();
        private ConditionalEventSystem<KeyBindingCode> onBindingDeactivated = new();
        private ConditionalEventSystem<KeyBindingCode, bool> onBindingStateChanged = new();
        public ControlMap ActiveControlMap { get; private set; }
        public ConditionalEventSystem<KeyBindingCode> OnBindingActivated { get => onBindingActivated; private set => onBindingActivated = value; }
        public ConditionalEventSystem<KeyBindingCode> OnBindingDeactivated { get => onBindingDeactivated; private set => onBindingDeactivated = value; }
        public ConditionalEventSystem<KeyBindingCode, bool> OnBindingStateChanged { get => onBindingStateChanged; private set => onBindingStateChanged = value; }

        public void Awake()
        {
            LoadDefault();
        }

        public void LoadDefault()
        {
            ActiveControlMap = new();

            ActiveControlMap.AssignBinding(KeyBindingCode.Accelerate, KeyCode.X, KeyBindingTriggerCondition.Continuous);
            ActiveControlMap.AssignBinding(KeyBindingCode.Reverse, KeyCode.C, KeyBindingTriggerCondition.Continuous);
            ActiveControlMap.AssignBinding(KeyBindingCode.Break, KeyCode.B, KeyBindingTriggerCondition.Down);
            
            ActiveControlMap.AssignBinding(KeyBindingCode.TurnLeft, KeyCode.A, KeyBindingTriggerCondition.Continuous);
            ActiveControlMap.AssignBinding(KeyBindingCode.TurnRight, KeyCode.D, KeyBindingTriggerCondition.Continuous);
            

            foreach (KeyBindingCode code in Enum.GetValues(typeof(KeyBindingCode)))
            {
                activationCache.Add(code, false);
            }
        }

        public void Update()
        {
            foreach (var kb in ActiveControlMap)
            {
                var check = false;

                if (kb.triggerCondition == KeyBindingTriggerCondition.Down)
                {
                    check = Input.GetKeyDown(kb.key);
                }
                else if (kb.triggerCondition == KeyBindingTriggerCondition.Up)
                {
                    check = Input.GetKeyUp(kb.key);
                }
                else
                {
                    check = Input.GetKey(kb.key);
                }

                var checkaux = activationCache[kb.code];

                var changed = checkaux != check;

                activationCache[kb.code] = check;

                if (check)
                {
                    OnBindingActivated.TriggerListeners(kb.code);
                }
                else if (checkaux && !check)
                {
                    OnBindingDeactivated.TriggerListeners(kb.code);
                }

                if (changed)
                {
                    OnBindingStateChanged.TriggerListeners(kb.code, check);
                }
            }
        }
    }
}