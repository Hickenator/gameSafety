using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class positionReset : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (this.transform.position.y < -1)
        {
            this.transform.position = new Vector3(transform.position.x, 1, transform.position.z);
        }
    }
}
