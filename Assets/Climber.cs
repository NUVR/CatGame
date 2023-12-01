using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
public class Climber : MonoBehaviour
{
    public CharacterController character;
    public static ActionBasedController climbingHand;
    private SwingingArmMotion continuousMovement;
    private jumpScript jump;

    private ActionBasedController previousHand;
    private Vector3 previousPos;
    private Vector3 currentVelocity;

    // Start is called before the first frame update
    void Start()
    {
        continuousMovement = GetComponent<SwingingArmMotion>();
        jump = GetComponent<jumpScript>();
    }

    void Update()
    {

        if (climbingHand)
        {
            Debug.Log("climbing hand");
            if (previousHand == null)
            {
                previousHand = climbingHand;
                previousPos = climbingHand.positionAction.action.ReadValue<Vector3>();
            }
            if (climbingHand.name != previousHand.name)
            {
                previousHand = climbingHand;
                previousPos = climbingHand.positionAction.action.ReadValue<Vector3>();
                //Debug.Log("DIFFERENT HAND NOW");
            }
            continuousMovement.enabled = false;
            jump.enabled = false;

            Climb();
        }
        else
        {
            //Debug.Log("not climbing hand");
            continuousMovement.enabled = true;
            jump.enabled = true;
        }
    }
    void Climb()
    {
        currentVelocity = (climbingHand.positionAction.action.ReadValue<Vector3>() - previousPos) / Time.deltaTime;
        character.Move(transform.rotation * -currentVelocity * Time.deltaTime);

        previousPos = climbingHand.positionAction.action.ReadValue<Vector3>();
    }
}
/*{
    private CharacterController character;
    public static Climber Instance;
    public XRController climbingHand;
    private SwingingArmMotion continuousMovement;
    private void Awake()
    {
        Instance = this;
    }

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
            Debug.Log("stop movement and climb");
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

        PlayerMovement.AddMovement(transform.rotation * -velocity * Time.fixedDeltaTime);
    }
}*/
