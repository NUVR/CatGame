using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private static PlayerMovement instance;
    private Vector3 curVector;
    private CharacterController cc;

    public static void AddMovement(Vector3 dir)
    {
        instance.curVector += dir;
    }

    void Awake(){
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        cc.Move(curVector);
        curVector = Vector3.zero;
    }
}
