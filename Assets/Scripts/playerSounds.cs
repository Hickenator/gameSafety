using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class playerSounds : MonoBehaviour
{

    public AudioClip boink;
    public AudioClip activate;
    public AudioClip doing;
    public AudioClip rhino;
    public AudioClip suction;
    public AudioClip swirl;

    private AudioSource playerSource;

    public bool walkingPlay;

    // Use this for initialization
    void Start()
    {
        playerSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A))
        {
            playerSource.clip = suction;
            playerSource.loop = true;

            if (!walkingPlay) {
                playerSource.Play();
                walkingPlay = true;
            }

            if (Input.GetKey(KeyCode.LeftShift)){
                playerSource.pitch = 1.2f;
            }
            else{
                playerSource.pitch = 1f;
            }
        }
        else
        {
            playerSource.Stop();
            walkingPlay = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerSource.clip = boink;
            playerSource.loop = false;
            playerSource.Play();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            playerSource.Pause();
            playerSource.Stop();
            if (Input.GetKey(KeyCode.W))
            {
                playerSource.clip = suction;
                playerSource.Play();
            }
            else
            {
                playerSource.clip = suction;
                playerSource.Pause();
            }
        }
    }
}