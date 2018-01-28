using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampBump : MonoBehaviour
{

    public AudioClip lampBump;
    public AudioSource lamp_AudioSource;
    // Use this for initialization
    void Start()
    {
        lamp_AudioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        lamp_AudioSource.PlayOneShot(lamp_AudioSource.clip);
    }
}