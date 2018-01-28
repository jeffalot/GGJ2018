using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPieceBehavior : MonoBehaviour {

    private int currentDestructionLevel = 0;
    public Sprite[] sprites;


    //Function to set destruction level, baseDestructionLevel 
    public void RandomizeDestruction(int baseDestructionLevel)
    {
        // Randomize Destruction
        SpriteRenderer spriteR = GetComponent<SpriteRenderer>();
        Sprite RandomSprite = sprites[Random.Range(0, sprites.Length)];
        //Debug.Log(spriteName + Random.Range(0, 10));
        spriteR.sprite = RandomSprite;
    }



}
