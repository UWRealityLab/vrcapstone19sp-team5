using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class AngleAxisCapture : MonoBehaviour
{
    [SerializeField]
    public Vector3 axis;
    public float degree;
    Quaternion orientation1;

    public Quaternion orientation2;


    private void Start()
    {
        orientation1 = gameObject.transform.rotation;
        orientation2 = gameObject.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        orientation1 = orientation2;
        orientation2 = gameObject.transform.rotation;

        //float f = Quaternion.Angle(orientation1, orientation2);

        Quaternion relative_rotation = Quaternion.Inverse(orientation1) * orientation2;
 
        relative_rotation.ToAngleAxis(out degree, out axis);

        //degree = f;

        if (axis.y < 0) //backwards rotation
        {
            degree *= -1; //will make degree appear backwards for force conversion
        }

        degree *= 2;
    }

}
