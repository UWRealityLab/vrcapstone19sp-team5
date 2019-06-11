using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGoalOn : MonoBehaviour
{
	public GameObject exitGoal;
    int seconds = 1;
    bool played = false;
    public bool victory;
	
	void OnTriggerEnter(Collider other)
    {
        if(victory)
        {
            exitGoal = gameObject;
        }
		if (other.CompareTag ("Player") && !played) {
			exitGoal.SetActive(true);
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();  // plays sound when collided.
            played = true;
            if(victory) { seconds = 3; }
            InvokeRepeating("Countdown", 1.0f, 1.0f);
        }
    }
    void Countdown()
    {
        if (--seconds == 0)
        {
            CancelInvoke("Countdown");
            gameObject.SetActive(false);
        }
    }
}
