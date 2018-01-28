using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour {

	public GameObject player;
	// Transform tempT;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(
			player.transform.position.x, 
			transform.position.y,
			transform.position.z
		);
	}
}
