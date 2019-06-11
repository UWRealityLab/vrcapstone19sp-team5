using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientationReset : MonoBehaviour
{
    public GameObject point1;
    public GameObject point2;
    Vector3 center;
    Vector3 direction;


    // Update is called once per frame

    void Update()
    {


        center = (point1.transform.position + point2.transform.position) / 2;
        center.y = center.y + 0.173f;
        gameObject.transform.position = center; //Get a vector pointing between the center of the two wheels, then get their midpoint, and set the chair's pos 0.173 above that point.

        
        direction = point1.transform.position - point2.transform.position;
        direction = Quaternion.AngleAxis(90, Vector3.up) * direction;
        gameObject.transform.rotation = Quaternion.LookRotation(direction); //Get that same previous vector, turn it 90 degrees, and make the seat look in that direction
        Vector3 rot = transform.eulerAngles;
        rot.x = 0;
        rot.z = 0;
        transform.eulerAngles = rot; //Make sure the seat stays upright and not tilting back and forth

    }
}
