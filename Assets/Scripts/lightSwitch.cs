using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightSwitch: MonoBehaviour {

    public bool leftLight;

    public bool rightLight;

    public Light spotLight;

	// Use this for initialization
	void Start () {
        leftLight = true;
        rightLight = false;
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name != "Plane") {
            if (collision.gameObject.tag == "leftLight")
            {
                if (leftLight == false)
                {
                    leftLight = true;
                }
                else
                {
                    leftLight = false;
                }
            }
            if ((collision.gameObject.tag == "rightLight"))
            {
                if (rightLight == false)
                {
                    rightLight = true;
                }
                else
                {
                    rightLight = false;
                }
            }
            if (( (leftLight==true) && (rightLight==false)) || ((rightLight == true) && (leftLight == false)) )
            {
                spotLight.enabled = true;
            }
            else
            {
                spotLight.enabled = false;
            }
            print("leftLight: " + leftLight);
            print("rightLight: " + rightLight);
            print("spotLight: " + spotLight.enabled);
        }
    }
}