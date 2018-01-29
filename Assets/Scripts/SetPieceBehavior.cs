using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPieceBehavior : MonoBehaviour {

    private int currentDestructionLevel = 0;
    public Sprite[] sprites;

    //Function to set destruction level, baseDestructionLevel 

    //baseDestructionLevel - Is previous level
    //maxDestructionLevel - Is max destruction level you can achieve 
    public void RandomizeDestruction (int baseDestructionLevel, int maxDestructionLevel) {
        // Randomize Destruction
        SpriteRenderer spriteR = GetComponent<SpriteRenderer> ();

        if (maxDestructionLevel > sprites.Length) {
            maxDestructionLevel = sprites.Length;
        }

        int newDestructionLevel = Random.Range (Mathf.Max (currentDestructionLevel, baseDestructionLevel), maxDestructionLevel);
        currentDestructionLevel = newDestructionLevel;
        Sprite RandomSprite = sprites[newDestructionLevel];
        Debug.Log ("Setting Sprite to: " + newDestructionLevel);
        spriteR.sprite = RandomSprite;
    }

}