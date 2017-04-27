using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transform : MonoBehaviour {

    public GameObject modelA;
    public GameObject modelB;

    public bool activeA;
    public bool activeB;

    public int modelNumber;

    void Start()
    {
        modelNumber = 1;
        activeA = true;
        modelB.SetActive(false);
    }

    void ModelSwitch()
    {
        modelNumber++;
        if (modelNumber == 1)
        {
            modelB.SetActive(false);
            activeA = true;
            this.transform.position = modelB.transform.position;
            modelA.transform.position = this.transform.position;
            modelA.SetActive(true);
        }
        else if (modelNumber == 2)
        {
            modelA.SetActive(false);
            activeA = true;
            this.transform.position = modelA.transform.position;
            modelB.transform.position = this.transform.position;
           // modelB.transform.rotation = this.transform.rotation;
            modelB.SetActive(true);
            modelNumber = 0;
        }
    }

    void Update()
    {

            if (Input.GetKeyDown(KeyCode.F))
        {
            ModelSwitch();
            print(modelNumber);
        }
    }
}
