using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFieldOfViewCubeFollow : MonoBehaviour
{
    public Camera trackedCamera;

    private float offset = 0.2f;

    void Start()
    {
        var frustrumHeight = 2.0f * offset * Mathf.Tan(trackedCamera.fieldOfView * 0.5f * Mathf.Deg2Rad);
        var frustrumWidth = frustrumHeight * trackedCamera.aspect;

        GameObject overlay = transform.Find("Overlay").gameObject;
        overlay.transform.localScale = new Vector3(frustrumWidth + 0.1f, frustrumHeight + 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (trackedCamera.transform.forward * offset) + trackedCamera.transform.position;
        transform.rotation = trackedCamera.transform.rotation;
    }
}
