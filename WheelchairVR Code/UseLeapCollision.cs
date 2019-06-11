using UnityEngine;
using System.Collections;
using System;

public class UseLeapCollision : MonoBehaviour
{

    public bool lockX;
    public bool lockY;
    public bool lockZ;

    public float returnSpeed;
    public float activationDistance;

    private elevControl elevContrl;
    private elevHallFrameController hallFrameContrl;

    // This is the second part of the button which remains in static position but changes color according to press
    public GameObject IndicatorObject;

    protected bool pressed = false;
    protected bool released = false;
    protected Vector3 startPosition;

    void Start()
    {
        // Remember start position of button
        startPosition = transform.localPosition;

        hallFrameContrl = this.transform.parent.GetComponent<elevHallFrameController>();
        elevContrl = GameObject.FindGameObjectWithTag(hallFrameContrl.elevTag).transform.GetComponent<elevControl>();
    }

    void Update()
    {
        released = false;

        // Use local position instead of global, so button can be rotated in any direction
        Vector3 localPos = transform.localPosition;
        if (lockX) localPos.x = startPosition.x;
        if (lockY) localPos.y = startPosition.y;
        if (lockZ) localPos.z = startPosition.z;
        transform.localPosition = localPos;

        // Return button to startPosition
        transform.localPosition = Vector3.Lerp(transform.localPosition, startPosition, Time.deltaTime * returnSpeed);

        //Get distance of button press. Make sure to only have one moving axis.
        Vector3 allDistances = transform.localPosition - startPosition;
        float distance = 1;
        if (!lockX) distance = Math.Abs(allDistances.x);
        if (!lockY) distance = Math.Abs(allDistances.y);
        if (!lockZ) distance = Math.Abs(allDistances.z);
        float pressComplete = Mathf.Clamp(1 / activationDistance * distance, 0f, 1f);

        //Activate pressed button
        if (pressComplete >= 0.7f && !pressed)
        {
            pressed = true;
            if (!elevContrl.isElevMoving)
            {//&& elevContrl.curFloorLevel !=  hallFrameContrl.floor ){
                elevContrl.newFloor = hallFrameContrl.floor;
                elevContrl.useCallBtn = true;
                hallFrameContrl.callButtonLight.GetComponent<Renderer>().material = elevContrl.buttonSelectorMat;
            }
        }
        //Dectivate unpressed button
        else if (pressComplete <= 0.2f && pressed)
        {
            pressed = false;
            released = true;

            elevContrl.useCallBtn = false;
            if (!elevContrl.isElevMoving)
                hallFrameContrl.callButtonLight.GetComponent<Renderer>().material = elevContrl.buttonOffMat;
        }

    }
}
