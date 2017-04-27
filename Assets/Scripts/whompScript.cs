using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whompScript : MonoBehaviour {

    public GameObject intruder;
    public float lerpSpeedWhomp = 1;
    private float whompHeight = 3;
    private bool whompDrop = false;
    private Rigidbody rb;
    private bool activated = false;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        whompDrop = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            activated = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            activated = false;
        }
    }

    void FixedUpdate()
    {
            if (activated)
            {
                if (whompDrop == false)
                {
                    Vector3 up = transform.TransformDirection(Vector3.up * 1) * 10;
                    if (transform.position.y <= 60)
                    {
                        rb.isKinematic = false;
                        Vector3 intruderTarget = new Vector3(intruder.transform.position.x, whompHeight, intruder.transform.position.z);
                        transform.position = Vector3.Lerp(transform.position, intruderTarget, Time.deltaTime * lerpSpeedWhomp);
                    }
                    else
                    {
                        whompDrop = true;
                        rb.isKinematic = true;
                    }
                }
                if (whompDrop)
                {
                    whompDrop = false;
                    whompHeight = 10;
                }
            }
        }
    }