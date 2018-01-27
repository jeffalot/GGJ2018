using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HueChildren : MonoBehaviour {

	private SpriteRenderer[] spriteRs;
	public Color mColor;

	void Start() {
		HueEverything();
	}
	void onGUI () {
		HueEverything();
	}
	void HueEverything(){
		spriteRs = GetComponentsInChildren<SpriteRenderer>();
		foreach (SpriteRenderer spriteR in spriteRs)
		{
			spriteR.color = mColor;
		}
	}
}
