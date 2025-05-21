using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelControl : MonoBehaviour
{
    // Start is called before the first frame update    
    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider backRight;
    [SerializeField] WheelCollider backLeft;

    [SerializeField] Transform frontRightTransform;
    [SerializeField] Transform frontLeftTransform;
    [SerializeField] Transform backRightTransform;
    [SerializeField] Transform backLeftTransform;

    Transform carBody;

    public float acceleration = 500f;
    public float breakingForce = 300f;
    public float maxTurnAngle = 15;


    private float currentAcceleration = 0f;
    private float currentBreakForce = 0f;
    private float currentTurnAngle = 0f;

    public float Speed;

    private void FixedUpdate()
    {

   
        currentAcceleration = acceleration * Input.GetAxis("Vertical") ;
        if (Input.GetKey(KeyCode.Space))
        {

  
        
            currentBreakForce = breakingForce;}
            else {

           
            currentBreakForce = 0f; }
              
        frontRight.motorTorque = currentAcceleration;
        frontLeft.motorTorque = currentAcceleration;
        //backRight.motorTorque = currentAcceleration;
        //backLeft.motorTorque = currentAcceleration;

        frontRight.brakeTorque = currentBreakForce;
        frontLeft.brakeTorque = currentBreakForce;
        backLeft.brakeTorque = currentBreakForce;
        backRight.brakeTorque = currentBreakForce;


        currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");

        frontLeft.steerAngle = currentTurnAngle;
        frontRight.steerAngle = currentTurnAngle;
         backLeft.steerAngle = currentTurnAngle;
         backRight.steerAngle = currentTurnAngle;

        UpdateWheel(frontLeft, frontLeftTransform);
        UpdateWheel(frontRight, frontRightTransform);
        UpdateWheel(backLeft, backLeftTransform);
        UpdateWheel(backRight, backRightTransform);

      

    }

    void UpdateWheel(WheelCollider col, Transform trans)
    {

        Vector3 position;
        Quaternion rotation;
        col.GetWorldPose(out position, out rotation);

        trans.position = position;
        trans.rotation = rotation;
    }

}
