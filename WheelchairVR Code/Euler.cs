using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Euler : MonoBehaviour
{


    [SerializeField]
    public float eulerAngX;
    [SerializeField]
    public float eulerAngY;
    [SerializeField]
    public float eulerAngZ;


    void Update()
    {

        eulerAngX = transform.eulerAngles.x;
        eulerAngY = transform.eulerAngles.y;
        eulerAngZ = transform.eulerAngles.z;

    }
}