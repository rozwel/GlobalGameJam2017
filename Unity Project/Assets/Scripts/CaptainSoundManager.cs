using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class CaptainSoundManager : MonoBehaviour {
    public AudioClip[] hitAsteroid, missAsteroid, orders, outOfFuel, planetFormed, refuelAtPlanet, selfCompliment, stayingStillToLong, streamHop;

    public static CaptainSoundManager instance;

    public static float lastPlayed;

    void Start()
    {
        CaptainSoundManager.instance = this;
        PlayRandomSound(selfCompliment);
    }

    public float PlayRandomSound(AudioClip[] sounds)
    {
        AudioClip clip = sounds[Random.Range(0, sounds.Length)];
        GetComponent<AudioSource>().PlayOneShot(clip);
        return clip.length;
    }
}
