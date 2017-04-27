using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rhinoScript : MonoBehaviour
{

    public GameObject intruder;
    public Transform intruderLocation;
    public int MaxDist = 80;
    public float lerpSpeedRhino = 20f;
    private bool activated = false;

    private AudioSource rhinoSource;

    // Use this for initialization
    void Start()
    {
        rhinoSource = GetComponent<AudioSource>();
        intruderLocation = intruder.transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            activated = true;
            rhinoSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            activated = false;
            rhinoSource.Pause();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, intruderLocation.position) <= MaxDist)
        {
            transform.LookAt(intruderLocation);
        }
        if(activated) {
            Vector3 intruderTarget = new Vector3(intruder.transform.position.x + .2f, transform.position.y, intruder.transform.position.z + .2f);
            transform.position = Vector3.MoveTowards(transform.position, intruderTarget, Time.deltaTime * lerpSpeedRhino);
        }

    }
}