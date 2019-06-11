using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Physics.IgnoreCollision(collision.collider, gameObject.GetComponent<Collider>());
        } else if (collision.gameObject.tag != "Floor") {
			AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
		}
    }
}
