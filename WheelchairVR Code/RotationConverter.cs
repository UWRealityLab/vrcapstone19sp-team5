using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationConverter : MonoBehaviour
{
    //Tracks the rotation of the controller.
    public GameObject controller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newRotation = new Vector3(controller.transform.eulerAngles.x, controller.transform.eulerAngles.x, controller.transform.eulerAngles.z);
        gameObject.transform.eulerAngles = newRotation;
    }
}
