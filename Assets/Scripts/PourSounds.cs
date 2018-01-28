using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourSounds : MonoBehaviour {

    public AudioClip[] pourPoison;
    public AudioSource poison_AudioSource;

    // Use this for initialization
    void Start () {
        poison_AudioSource = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        int n = Random.Range(1, pourPoison.Length);
        poison_AudioSource.clip = pourPoison[n];
        poison_AudioSource.PlayOneShot(poison_AudioSource.clip);
        // move picked sound to index 0 so it's not picked next time
        pourPoison[n] = pourPoison[0];
        pourPoison[0] = poison_AudioSource.clip;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
