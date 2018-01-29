using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitizenBehavior : MonoBehaviour {

    public float speed;

    private Rigidbody2D rb2d;

    private int timeSinceLastMove = 0;

    public int timesToMoveInOneDirection = 5;

    public int direction = 1;

    private int timesMoved = 0;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D> ();
    }

    private void FixedUpdate () {
        //Wait every so often before giving character a bump
        if (timeSinceLastMove > 60)

        {
            if (Random.value >.9) {

                if (timesToMoveInOneDirection > timesMoved) {
                    direction = direction * -1;
                    timesMoved = 1;
                } else {
                    timesMoved += 1;
                }

                // Debug.Log("Moving character");
                timeSinceLastMove = 0;

                float moveHorizontal = 1;

                //Give character a bump to the right or left
                Vector2 movement = new Vector2 (moveHorizontal, 1);

                rb2d.AddForce (movement * speed);
            }

        } else {
            timeSinceLastMove += 1;
        }
    }

    private void Update () {

    }

}