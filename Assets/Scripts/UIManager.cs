using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Canvas introCanvas;
    public Canvas colosseumCanvas;
    public Canvas menuCanvas;

    public bool introReady;
    public bool colosseumReady;

	// Use this for initialization
	void Start () {
        introCanvas.enabled = false;
        colosseumCanvas.enabled = false;
        introReady = false;
        colosseumReady = false;
	}
	
    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "introSign")
        {
            introReady = true;
            print("introReady: " + introReady);
        }
        else if (other.name == "colosseumSign")
        {
            colosseumReady = true;
            print("colosseumReady: " + colosseumReady);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.name == "introSign")
        {
            introReady = false;
            if(introCanvas.enabled)
            {
                introCanvas.enabled = false;
            }
            print("introReady: " + introReady);
        }
        else if (other.name == "colosseumSign")
        {
            colosseumReady = false;
            if (colosseumCanvas.enabled)
            {
                colosseumCanvas.enabled = false;
            }
            print("colosseumReady: " + colosseumReady);
        }
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.E))
        {
            print("E key was pressed");
            if(introCanvas.enabled == false && introReady) {
                introCanvas.enabled = true;
                print("introCanvas");
            }
            else if(introCanvas.enabled)
            {
                introCanvas.enabled = false;
                print("introCanvas");
            }

            if (colosseumCanvas.enabled == false && colosseumReady)
            {
                colosseumCanvas.enabled = true;
                print("colosseumCanvas");
            }
            else if (colosseumCanvas.enabled)
            {
                colosseumCanvas.enabled = false;
                print("colosseumCanvas");
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!menuCanvas.enabled) { 
                menuCanvas.enabled = true;
            }
            if(menuCanvas.enabled)
            {
                menuCanvas.enabled = false;
            }
        }

    }
}
