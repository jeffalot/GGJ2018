using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFlap : MonoBehaviour {

        public float speed;
        public float lift;

        private Rigidbody2D rb2d;
        private GameObject leftBounds;
        private GameObject rightBounds;
        

        // Use this for initialization
        void Start () {
                rb2d = GetComponent<Rigidbody2D> ();
                leftBounds = GameObject.FindWithTag("LeftBounds");
                rightBounds = GameObject.FindWithTag("RightBounds");
        }

        // Update is called once per frame
        void FixedUpdate () {
                float moveHorizontal = Input.GetAxis ("Horizontal");

                Vector2 movement = new Vector2 (moveHorizontal, lift);

                if (Input.GetButtonDown ("Jump"))
                        rb2d.AddForce (movement * speed);

                if (moveHorizontal > 0) {
                        GetComponent<SpriteRenderer>().flipX = true;
                } else if (moveHorizontal < 0) {
                        GetComponent<SpriteRenderer>().flipX = false;
                }

                // Vector3 currentRotation = transform.localRotation.eulerAngles;
                // currentRotation.y = Mathf.Clamp(currentRotation.y, -30, 30);
                // transform.localRotation = Quaternion.Euler (currentRotation);
        }
}