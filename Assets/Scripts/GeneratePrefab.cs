using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePrefab : MonoBehaviour {

	public GameObject prefab;
	public int prefabAmount;
	public GameObject ground;

	public Sprite[] sprites;

	void Awake()
	{
		float groundBoundsLeft = -ground.transform.localScale.x / 2;
		float groundBoundsRight = ground.transform.localScale.x / 2;
		for (int i = 0; i < prefabAmount; i++)
		{
			GameObject NewCitizen = Instantiate(prefab, new Vector3(
				Random.Range(
					groundBoundsLeft,
					groundBoundsRight
				),
				ground.transform.position.y,
				0
			),
			Quaternion.identity);
			NewCitizen.transform.parent = transform;
			RandomizeSprite(NewCitizen, "NPC");
		}
	}
	void RandomizeSprite(GameObject prefab, string spriteName){
		// Randomize Sprite
		SpriteRenderer spriteR = prefab.GetComponent<SpriteRenderer>();
		Sprite RandomSprite = sprites[Random.Range(0, sprites.Length)];
		Debug.Log(spriteName + Random.Range(0,10));
		spriteR.sprite = RandomSprite;
	}
}
