using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinDetection : MonoBehaviour
{
    // Start is called before the first frame update
    public Text winText;

    void Start()
    {
        winText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            print("Entered win area!");
            winText.text = "You got to the target!";
        }
    }
}
