using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimator : MonoBehaviour
{
    public GameObject button;
	private IgnoreWallCollision wallScript;
	private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        wallScript = button.GetComponent<IgnoreWallCollision>();
		anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(wallScript.buttonPressed) {
			anim.SetBool("open", true);
		}
    }
}
