using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class jumpScript : MonoBehaviour
{
    private CharacterController characterController;
    private Vector3 playerVelocity = new Vector3(0.0f, 0.0f, 0.0f);
    public float gravityValue = 9.8f;
    public float jumpHeight = 2.0f;
    public InputActionReference jumpButton;


    private void OnEnable() => jumpButton.action.performed += Jumping;
    private void OnDisable() => jumpButton.action.performed -= Jumping;

    private void Jumping(InputAction.CallbackContext obj)
    {
        Debug.Log("pressed");
        if (!characterController.isGrounded)
        {

            return;
        }
        playerVelocity.y += Mathf.Sqrt(jumpHeight * 3.0f * gravityValue);
    }
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        if(characterController.isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0;
            
        }
        playerVelocity.y -= gravityValue * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime);
    }
}
