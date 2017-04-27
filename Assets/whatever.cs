using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whatever : MonoBehaviour {

	// Use this for initialization
	void Start () {
        int result = myMethod(25);
        print(result);
	}

    int myMethod(int myNumber){
        return myNumber * myNumber;
    }
	
	// Update is called once per frame
	void Update () {	
	}

    void doSomething()
    {
        print("done something");
    }
}
