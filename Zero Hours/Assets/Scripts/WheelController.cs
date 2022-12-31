using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{

    [SerializeField] WheelCollider frontWheel; 
    [SerializeField] WheelCollider backWheel;

    //private Rigidbody bikeRB;
    
    public float acceleration = 500f;
    public float breakingForce = 300f;
    public float maxTurnAngle = 15f;

    private float currentAcceleration = 0f;
    private float currentBreakForce = 0f;
    private float currentTurnAngle = 0f;

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

        // Handl;es Steering
        currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
        frontWheel.steerAngle = currentTurnAngle;
        

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

/*         if (Rotation > 10)
        {
            GameObject.Rotate(0, 0 , -10);
        }
        else if(Rotation < -10)
        {
            GameObject.Rotate(0 , 0 , 10);
        } */
    }
}
