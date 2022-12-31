using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{

    [SerializeField] WheelCollider frontWheel; 
    [SerializeField] WheelCollider backWheel;

    private Rigidbody bikeRB;
    
    public float acceleration = 500f;
    public float breakingForce = 300f;
    public float maxTurnAngle = 25f;

    private float currentAcceleration = 0f;
    private float currentBreakForce = 0f;
    private float currentTurnAngle = 0f;

    public float leanStrength = 0.2f;

    public Transform GameObject;

    private void FixedUpdate() {

        currentAcceleration = acceleration * Input.GetAxis("Vertical");

        // Get Forward/ Reverse accleleration from the vertical axis 
        if (Input.GetKey(KeyCode.Space))
            currentBreakForce = breakingForce;
        else 
            currentBreakForce = 0f;

        //apply acceleration to front wheels
        backWheel.motorTorque  = currentAcceleration;

        frontWheel.brakeTorque = currentBreakForce;
        backWheel.brakeTorque = currentBreakForce;

        // Handles Steering
        currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
        frontWheel.steerAngle = currentTurnAngle;
        if (currentTurnAngle > 0.5f)
        {
            GameObject.Rotate(0 , 0 , leanStrength);
        }
        else if (currentTurnAngle < -0.5f)
        {
            GameObject.Rotate(0 , 0 , -leanStrength);
        }
        
        
        float Rotation;
        if(GameObject.eulerAngles.z <= 180f)
        {
            Rotation = GameObject.eulerAngles.z;
        }
        else
        {
            Rotation = GameObject.eulerAngles.z - 360f;
        }
        Debug.Log(Rotation);

          if ( (Rotation > 0) && (currentTurnAngle == 0) )
        {
            GameObject.Rotate(0, 0 , -leanStrength);
        }
        else if ( (Rotation < -0) && (currentTurnAngle == 0) )
        {
            GameObject.Rotate(0 , 0 , leanStrength);
        }  

    }
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //bikeRB = GetComponent<Rigidbody>();
        
        //transform.Rotate()

    }
}
