using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{

    public GameObject target;
    public float xCorrection = 0;
    public float zCorrection = -3;
    public float lerpSpeed = 2;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 moveTarget = new Vector3(target.transform.position.x + xCorrection, transform.position.y, target.transform.position.z + zCorrection);
        transform.position = Vector3.Lerp(transform.position, moveTarget, Time.deltaTime * lerpSpeed);

    }
}