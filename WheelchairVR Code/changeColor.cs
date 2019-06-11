using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColor : MonoBehaviour
{
	public Material blue;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Button")
        {
            Physics.IgnoreCollision(other, gameObject.GetComponent<Collider>());

        }
        else
        {
            Renderer rend = GetComponent<Renderer>();
            if (rend != null)
            {
                rend.material = blue;
            }
        }
	}
}
