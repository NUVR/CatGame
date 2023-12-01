using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
using UnityEngine.Events;

[System.Serializable]
public class TriggerEvent : UnityEvent<float> { }

namespace UnityEngine.XR.Interaction.Toolkit
{
    public class ExtendClaws : XRBaseController
    {

        public TriggerEvent triggerPress;

        private float lastTriggerState = 0.0f;
        private List<InputDevice> devicesWithTrigger;

        private void Awake()
        {
            if (triggerPress == null)
            {
                triggerPress = new TriggerEvent();
            }

            devicesWithTrigger = new List<InputDevice>();
        }

        void OnEnable()
        {
            List<InputDevice> allDevices = new List<InputDevice>();
            InputDevices.GetDevices(allDevices);
            foreach (InputDevice device in allDevices)
                InputDevices_deviceConnected(device);

            InputDevices.deviceConnected += InputDevices_deviceConnected;
            InputDevices.deviceDisconnected += InputDevices_deviceDisconnected;
            
        }

        private void OnDisable()
        {
            InputDevices.deviceConnected -= InputDevices_deviceConnected;
            InputDevices.deviceDisconnected -= InputDevices_deviceDisconnected;
            devicesWithTrigger.Clear();
        }

        private void InputDevices_deviceConnected(InputDevice device)
        {
            float discardedValue;
            if (device.TryGetFeatureValue(CommonUsages.trigger, out discardedValue))
            {
                Debug.Log(device.name);
                devicesWithTrigger.Add(device); // Add any devices that have a primary button.
            }
            
        }

        private void InputDevices_deviceDisconnected(InputDevice device)
        {
            if (devicesWithTrigger.Contains(device))
                devicesWithTrigger.Remove(device);
        }

        void Update()
        {
            float tempState = 0.0f;
            foreach (var device in devicesWithTrigger)
            {
                float triggerState = 0.0f;
                if (device.TryGetFeatureValue(CommonUsages.trigger, out triggerState))
                {
                    // Debug.Log(triggerState);
                    if (triggerState > tempState)
                    {
                        tempState = triggerState;
                        
                    }
                }
            }

            if (tempState != lastTriggerState) // Button state changed since last frame
            {
                triggerPress.Invoke(tempState);
                lastTriggerState = tempState;
            }

            
        }

    }
}
