using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerHider : MonoBehaviour
{
    private GameObject controllerModel;
    public string objectName;

    void Update()
    {
		Transform tmp = gameObject.transform.Find(objectName);
		if(tmp != null) {
			controllerModel = tmp.gameObject;
			controllerModel.SetActive(false);
		}
    }

}
