using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeatFix : MonoBehaviour
{
    private Quaternion startRotation;
    // Start is called before the first frame update
    void Start()
    {
        startRotation = gameObject.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.rotation = startRotation;
    }
}
