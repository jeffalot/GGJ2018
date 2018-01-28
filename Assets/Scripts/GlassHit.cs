using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassHit : MonoBehaviour {
    public AudioClip[] glassHit;
    public AudioSource glass_AudioSource;

    // Use this for initialization
    void Start()
    {
       glass_AudioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        int n = Random.Range(1, glassHit.Length);
        glass_AudioSource.clip = glassHit[n];
        glass_AudioSource.PlayOneShot(glass_AudioSource.clip);
        // move picked sound to index 0 so it's not picked next time
        glassHit[n] = glassHit[0];
        glassHit[0] = glass_AudioSource.clip;
    }
    }