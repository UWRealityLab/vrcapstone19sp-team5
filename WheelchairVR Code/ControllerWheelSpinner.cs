using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerWheelSpinner : MonoBehaviour
{
    public GameObject leftController;
    public GameObject rightController;

    public GameObject leftWheel;
    public GameObject rightWheel;

    public int threshhold;

    HingeJoint rightHinge;
    JointMotor rightMotor;

    AngleAxisCapture leftAngleScript;
    AngleAxisCapture rightAngleScript;

    HingeJoint leftHinge;
    JointMotor leftMotor;

    public float force;
    float leftDegree;
    float rightDegree;

    // Start is called before the first frame update
    void Start()
    {
        leftAngleScript = leftController.GetComponent<AngleAxisCapture>();
        leftHinge = leftWheel.GetComponent<HingeJoint>();
        leftMotor = leftHinge.motor;
        leftDegree = leftAngleScript.degree;

        rightAngleScript = rightController.GetComponent<AngleAxisCapture>();
        rightHinge = rightWheel.GetComponent<HingeJoint>();
        rightMotor = rightHinge.motor;
        rightDegree = rightAngleScript.degree;
    }

    // Update is called once per frame
    void Update()
    {
        leftDegree = leftAngleScript.degree * 0.3f;
        
        float leftValue = leftDegree / Time.fixedDeltaTime * -1;
        if(Mathf.Abs(leftValue) < threshhold)
        {
            leftValue = 0;
        }

        leftMotor.targetVelocity = leftValue;
        leftMotor.force = force;
        

        //LR divider
        rightDegree = rightAngleScript.degree * 0.3f;

        float rightValue = rightDegree / Time.fixedDeltaTime;
        if (Mathf.Abs(rightValue) < threshhold)
        {
            rightValue = 0;
        }

        rightMotor.targetVelocity = rightValue;
        rightMotor.force = force;
        
        if(sameSign(rightMotor.targetVelocity, leftMotor.targetVelocity) && rightMotor.targetVelocity != 0 && leftMotor.targetVelocity != 0)
        {
            rightMotor.targetVelocity = leftValue;

        }

        leftHinge.motor = leftMotor;
        leftHinge.useMotor = true;

        rightHinge.motor = rightMotor;
        rightHinge.useMotor = true;

    }

    bool sameSign(float f1, float f2)
    {
        bool returner = true;
        if ((f1 > 0) && (f2 < 0))
        {
            returner = false;
        }
        else if ((f1 < 0) && (f2 > 0))
        {
            returner = false;
        }
        return returner;
    }
}
