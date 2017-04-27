using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class gameMusicController : MonoBehaviour {

    public AudioMixerSnapshot outOfCombat;
    public AudioMixerSnapshot inCombat;
    public AudioClip[] stings;
    public AudioClip[] combatStings;
    public AudioSource stingSource;
    public float stingLength;
    public float musicDuration;
    public float bpm = 128;

    private float m_TransitionIn;
    private float m_TransitionOut;
    private float m_QuarterNote;

    // Use this for initialization
    void Start () {
        m_QuarterNote = 60 / bpm;
        m_TransitionIn = m_QuarterNote;
        m_TransitionOut = m_QuarterNote * 32;
        PlaySting();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CombatZone"))
        {
            inCombat.TransitionTo(m_TransitionIn);
            PlayCombatSting();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CombatZone"))
        {
            outOfCombat.TransitionTo(m_TransitionOut);
            PlaySting();
        }
    }

    void PlaySting()
    {
        int randClip = Random.Range(0, stings.Length);
        stingSource.clip = stings[randClip];
        stingSource.Play();
        musicDuration = 0;
        stingLength = stingSource.clip.length;
    }
    void PlayCombatSting()
    {
        int randClip = Random.Range(0, combatStings.Length);
        stingSource.clip = combatStings[randClip];
        stingSource.Play();
        musicDuration = 0;
        stingLength = stingSource.clip.length;
    }
    void Update()
    {
        if(musicDuration > (stingLength-5)) {
            PlaySting();
            musicDuration=0;
        }
        else
        {
            musicDuration += 0.02f;
        }
    }
}
