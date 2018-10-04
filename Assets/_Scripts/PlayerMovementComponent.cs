using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementComponent : MonoBehaviour {

    public float Acceleration = 1000; //Variable to determine Acceleration of the 
    public float CurrentMaxMovementSpeed = 10;

    public float MaxWalkSpeed = 5;
    public float MaxSprintSpeed = 15;

    public bool isSprinting;

    private Rigidbody RB; // Unity physics component
    private Vector3 IPDirection; // Input direction in world space

    private float DT;
   
    // Use this for initialization
    void Start () {
        RB = GetComponent<Rigidbody>();
	}
	
    void UpdateInput()
    {
        IPDirection.x = Input.GetAxisRaw("Horizontal");
        IPDirection.z = Input.GetAxisRaw("Vertical");

        isSprinting = Input.GetKey(KeyCode.LeftShift);

    }


    public Vector3 VectorClamp(Vector3 CurrentVector, float XMax, float YMax, float ZMax)
    {
        Vector3 VecClamp;

        VecClamp.x = Mathf.Clamp(CurrentVector.x, -XMax, XMax);
        VecClamp.y = Mathf.Clamp(CurrentVector.y, -YMax, YMax);
        VecClamp.z = Mathf.Clamp(CurrentVector.z, -ZMax, ZMax);

        return VecClamp;

        // Clamp for single variable assign
        /*
        return new Vector3(Mathf.Clamp( Mathf.Clamp(CurrentVector.x, -XMax, XMax), //X
                                           Mathf.Clamp(CurrentVector.y, -YMax, YMax), // Y
                                           Mathf.Clamp(CurrentVector.z, -ZMax, ZMax)); //Z
       */
    }
    // Move a rigidbody in a direction by a Acceleration * deltaTime
    public void DoMovement(Rigidbody rigidbody, Vector3 Input, 
                                  float Acceleration, float DeltaTime, float MaxAcceleration)
    {
        
        CurrentMaxMovementSpeed = (isSprinting == true) ? MaxSprintSpeed : MaxWalkSpeed;
        rigidbody.AddForce(Input * Acceleration * DeltaTime);
        rigidbody.velocity = VectorClamp(rigidbody.velocity, CurrentMaxMovementSpeed, CurrentMaxMovementSpeed, CurrentMaxMovementSpeed);

    }



    // Update is called once per frame
    void Update () {
        DT = Time.deltaTime;

        UpdateInput();
        DoMovement(RB, IPDirection, Acceleration, DT, CurrentMaxMovementSpeed);
	}
}
