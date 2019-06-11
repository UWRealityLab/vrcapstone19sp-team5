using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnMuffler : MonoBehaviour { 

    public GameObject rightWheel;
    public GameObject leftWheel;
	public float muffler;
    public bool track = false;
    public float right;
    public float left;
    public float average;

    HingeJoint leftHinge;
    JointMotor leftMotor;
    HingeJoint rightHinge;
    JointMotor rightMotor;

    Rigidbody rightBody;
    Rigidbody leftBody;

    private float prevVeloR;
    private float prevVeloL;

    // Start is called before the first frame update
    void Start()
    {
        leftHinge = leftWheel.GetComponent<HingeJoint>();
        leftMotor = leftHinge.motor;

        rightHinge = rightWheel.GetComponent<HingeJoint>();
        rightMotor = rightHinge.motor;

        rightBody = rightWheel.GetComponent<Rigidbody>();
        leftBody = leftWheel.GetComponent<Rigidbody>();

        prevVeloL = 0;
        prevVeloR = 0;

    }

    // Update is called once per frame
    void Update()
    {
        leftHinge = leftWheel.GetComponent<HingeJoint>();
        leftMotor = leftHinge.motor;

        rightHinge = rightWheel.GetComponent<HingeJoint>();
        rightMotor = rightHinge.motor;

        right = rightMotor.targetVelocity;
        left = leftMotor.targetVelocity;

        if(left > 400)
        {
            left = prevVeloL;
        }
        if(right > 400)
        {
            right = prevVeloR;
        }

        if (!sameSign(right, left)) //If the wheels are spinning in different directions (turning), cut down their speed.
        {
            track = true;
            leftMotor.targetVelocity = leftMotor.targetVelocity / muffler;
            rightMotor.targetVelocity = rightMotor.targetVelocity / muffler;
            leftHinge.motor = leftMotor;
            rightHinge.motor = rightMotor;
            leftHinge.useMotor = true;
            rightHinge.useMotor = true;
        }
		
		if (right != 0 && left == 0) {
			track = true;
			rightMotor.targetVelocity = rightMotor.targetVelocity / muffler;
		} else if (right == 0 && left != 0) {
			track = true;
			leftMotor.targetVelocity = leftMotor.targetVelocity / muffler;
		}
		
        prevVeloL = left;
        prevVeloR = right;
        /*
        else //wheels spin in the same direction
        {
            track = true;
            average = (leftMotor.targetVelocity + rightMotor.targetVelocity) / 2;

            leftMotor.targetVelocity = average;
            rightMotor.targetVelocity = average; //This ensures that the wheelchair isn't jerky, it's made to smooth the movement out.
        }
        if(Mathf.Abs(leftMotor.targetVelocity) < 15)
        {
            leftMotor.targetVelocity = 0;
        }
        if (Mathf.Abs(rightMotor.targetVelocity) < 15)
        {
            rightMotor.targetVelocity = 0;
        }
        right = rightMotor.targetVelocity;
        left = leftMotor.targetVelocity;
        
        rightHinge.motor = rightMotor;
        rightHinge.useMotor = true;
        leftHinge.motor = leftMotor;
        leftHinge.useMotor = true;
        */
    }

    bool sameSign(float f1, float f2)
    {
        bool returner = true;
        if((f1 > 0) && (f2 < 0))
        {
            returner = false;
        } else if((f1 < 0) && (f2 > 0))
        {
            returner = false;
        }
        return returner;
    }
}
