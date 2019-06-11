using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreWallCollision : MonoBehaviour
{
	public bool buttonPressed;
    public Material blue;
    public GameObject color;
	public GameObject creak;
	
    // Start is called before the first frame update
    void Start()
    {
		buttonPressed = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag != "IgnoreWall")
        {
            buttonPressed = true;
            Renderer rend = color.GetComponent<Renderer>();
            if (rend != null)
            {
                rend.material = blue;
            }
			creak.SetActive(true);
        }
    }
}
