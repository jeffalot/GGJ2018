using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottleBehavior : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log(other.tag);
		if (other.tag == "currentGoal") {
			GameController.Instance.triggerCheckpointDeliver();
		}
	}
	void onDisable(){
		Debug.Log("Disabled");
	}
}
