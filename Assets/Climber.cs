using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
public class Climber : MonoBehaviour
{
    private CharacterController character;
    public static XRController climbingHand;
    private SwingingArmMotion continuousMovement;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        continuousMovement = GetComponent<SwingingArmMotion>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(climbingHand)
        {
            continuousMovement.enabled = false;
            Climb();
        }
        else
        {
            continuousMovement.enabled = true;
        }
    }
    void Climb()
    {
        InputDevices.GetDeviceAtXRNode(climbingHand.controllerNode).TryGetFeatureValue(CommonUsages.deviceAngularVelocity, out Vector3 velocity);

        character.Move(transform.rotation * -velocity * Time.fixedDeltaTime);
    }
}
