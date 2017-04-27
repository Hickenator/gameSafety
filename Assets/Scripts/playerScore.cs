﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class playerScore : MonoBehaviour {

    public int score = 0;

    public AudioClip collection;

    public AudioSource collectionSound;

    public AudioSource playerSource;

    void Start()
    {
        playerSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other) {     
        if (other.gameObject.tag == "Objective")
        {
            Destroy(other.gameObject);
            playerSource.clip = collection;
            collectionSound.loop = false;
            collectionSound.Play();
            score++;
            print(score);
        }
    }


}