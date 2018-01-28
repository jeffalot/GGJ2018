using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFlap : MonoBehaviour
{

    public float speed;
    public AudioClip[] bird_Hit;
    public AudioClip wingFlap;
    public AudioSource bird_AudioSource;

    private Rigidbody2D rb2d;
    private GameObject leftBounds;
    private GameObject rightBounds;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        bird_AudioSource = GetComponent<AudioSource>();
        leftBounds = GameObject.FindWithTag("LeftBounds");
        rightBounds = GameObject.FindWithTag("RightBounds");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int n = Random.Range(1, bird_Hit.Length);
        bird_AudioSource.clip = bird_Hit[n];
        bird_AudioSource.PlayOneShot(bird_AudioSource.clip);
        // move picked sound to index 0 so it's not picked next time
        bird_Hit[n] = bird_Hit[0];
        bird_Hit[0] = bird_AudioSource.clip;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal, 5);

        if (Input.GetButtonDown("Jump"))
            rb2d.AddForce(movement * speed);
        //bird_AudioSource.PlayOneShot(bird_AudioSource.clip);

        if (moveHorizontal > 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (moveHorizontal < 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}

        // if (transform.position.x > rightBounds.transform.position.x + 1){
        //         transform.position = new Vector3(
        //                 rightBounds.transform.position.x,
        //                 transform.position.y,
        //                 transform.position.z
        //         );
        // }
        // if (transform.position.x < leftBounds.transform.position.x - 1){
        //         transform.position = new Vector3(
        //                 leftBounds.transform.position.x,
        //                 transform.position.y,
        //                 transform.position.z
        //         );
        // }
    