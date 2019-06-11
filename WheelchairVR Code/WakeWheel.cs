using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakeWheel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.WakeUp();
        rb.AddForce(new Vector3(0, 0, 0));
    }
}
