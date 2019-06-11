using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorInternalButtonTrigger : MonoBehaviour
{
    public int goToFloor;
    public GameObject callBtnLight;
    private elevControl elevContrl;

    void Start()
    {
        elevContrl = transform.parent.parent.parent.GetComponent<elevControl>();
    }

    void OnTriggerEnter(Collider other)
    {
        //if (!elevContrl.isElevMoving)
        Debug.Log("other=" + other);
        if (other.name.Contains("Contact") && !elevContrl.isElevMoving)
        {//&& elevContrl.curFloorLevel !=  hallFrameContrl.floor ){
            //elevContrl.newFloor = goToFloor;
            Debug.Log("Pressed button " + goToFloor);
            elevContrl.useControls = true;
            elevContrl.ButtonSelect(goToFloor);
            elevContrl.PressButton(goToFloor);
            callBtnLight.GetComponent<Renderer>().material = elevContrl.buttonSelectorMat;
        }
    }

    void OnTriggerExit(Collider other)
    {
        //elevContrl.useControls = false;
        //if (!elevContrl.isElevMoving)
        if (other.name.Contains("Contact"))
        {
            Debug.Log("Pressed button " + goToFloor);
            callBtnLight.GetComponent<Renderer>().material = elevContrl.buttonOffMat;
        
        }
    }
}
