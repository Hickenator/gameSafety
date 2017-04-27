using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class damageScript : MonoBehaviour
{

    public int health;
    public Image heart1;
    public Image heart2;
    public Image heart3;

    public AudioClip damaged;

    public AudioClip destroyed;

    public AudioClip healed;

    public AudioSource damagedSource;

    public GameObject playerSwitcher;

    void Start()
    {
        health = 3;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            damagedSource.clip = damaged;
            damagedSource.loop = false;
            damagedSource.Play();
            health--;
            print(health);
            if (health == 1)
            {
                heart1.enabled = true;
                heart2.enabled = false;
                heart3.enabled = false;
            }
            if (health==2)
            {
                heart1.enabled = true;
                heart2.enabled = true;
                heart3.enabled = false;
            }
            if(health==3)
            {
                heart1.enabled = true;
                heart2.enabled = true;
                heart3.enabled = true;
            }
            if(health <= 0)
            {
                damagedSource.clip = destroyed;
                damagedSource.Play();
                Destroy(playerSwitcher);
            }
        }

        if(other.gameObject.tag == "Health")
        {
            damagedSource.clip = healed;
            damagedSource.loop = false;
            damagedSource.Play();
            health++;
            print(health);

            if (health == 1)
            {
                heart1.enabled = true;
                heart2.enabled = false;
                heart3.enabled = false;
            }
            if (health == 2)
            {
                heart1.enabled = true;
                heart2.enabled = true;
                heart3.enabled = false;
            }
            if (health == 3)
            {
                heart1.enabled = true;
                heart2.enabled = true;
                heart3.enabled = true;
            }
        }
    }
}