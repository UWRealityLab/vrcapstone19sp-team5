using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScene : MonoBehaviour
{
	bool loadingStarted = false;
    float secondsLeft = 0;
	
    void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Player")) {
			StartCoroutine(DelayLoadLevel(7));
		}
	}
	
	IEnumerator DelayLoadLevel(float seconds)
    {
        secondsLeft = seconds;
        loadingStarted = true;
        do
        {
            yield return new WaitForSeconds(1);
        } while (--secondsLeft > 0);

		SceneManager.LoadScene ("trans2");
    }
}
