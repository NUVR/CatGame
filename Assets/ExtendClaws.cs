using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

namespace UnityEngine.XR.Interaction.Toolkit
{
    public class ExtendClaws : XRBaseController
    {

        [SerializeField]
        [Tooltip("The Input System Action that will be used to perform grab movement while held. Must be a Button Control.")]
        InputActionProperty m_ExtendClawsAction;
        /// <summary>
        /// The Input System Action that Unity uses to perform grab movement while held. Must be a <see cref="ButtonControl"/> Control.
        /// </summary>
        public InputActionProperty extendClawsAction
        {
            get => m_ExtendClawsAction;
            set => SetInputActionProperty(ref m_ExtendClawsAction, value);
        }



        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (m_ExtendClawsAction.action.isPressed())
            {
                Console.Log("Trigger is pressed");
            }
        }

        void SetInputActionProperty(ref InputActionProperty property, InputActionProperty value)
        {
            if (Application.isPlaying)
                property.DisableDirectAction();

            property = value;

            if (Application.isPlaying && isActiveAndEnabled)
                property.EnableDirectAction();
        }
    }
}
