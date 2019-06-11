using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionEmpty : MonoBehaviour
{
    bool loadingStarted = false;
	public string nextSceneName;
    float secondsLeft = 0;

    void Start()
    {
        StartCoroutine(DelayLoadLevel(15));
    }

    IEnumerator DelayLoadLevel(float seconds)
    {
        secondsLeft = seconds;
        loadingStarted = true;
        do
        {
            yield return new WaitForSeconds(1);
        } while (--secondsLeft > 0);

		SceneManager.LoadScene (nextSceneName);
    }

}