using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour {

	public GameObject player;
	public GameObject cameraBoundsMin;
	public GameObject cameraBoundsMax;
	
	// Update is called once per frame
	void Update () {
		float horzExtent = Camera.main.orthographicSize * Screen.width / Screen.height;
		float newCameraPosX = Mathf.Clamp(
			player.transform.position.x, 
			cameraBoundsMin.transform.position.x,
			cameraBoundsMax.transform.position.x
		);

		Debug.Log(cameraBoundsMin.transform.position.x);
		Debug.Log(cameraBoundsMax.transform.position.x);

		transform.position = new Vector3(
			newCameraPosX, 
			transform.position.y,
			transform.position.z
		);
	}
}
