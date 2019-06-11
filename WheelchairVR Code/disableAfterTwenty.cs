using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableAfterTwenty : MonoBehaviour
{
	int seconds = 20;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating ("Countdown", 1.0f, 1.0f);
    }

    
    void Countdown()
    {
        if(--seconds == 0) { 
			CancelInvoke ("Countdown");
			gameObject.SetActive(false);
		}
    }
}
