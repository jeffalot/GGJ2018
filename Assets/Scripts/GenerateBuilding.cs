using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBuilding : MonoBehaviour {

		public GameObject prefab;
	public int prefabAmount;
	public GameObject container;

	public Sprite[] sprites;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		float containerBoundsLeft = -container.transform.localScale.x / 2;
		float containerBoundsRight = container.transform.localScale.x / 2;
		for (int i = 0; i < prefabAmount; i++)
		{
			GameObject NewCitizen = Instantiate(prefab, new Vector3(
				Random.Range(
					containerBoundsLeft,
					containerBoundsRight
				),
				0,
				0
			),
			Quaternion.identity);
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
