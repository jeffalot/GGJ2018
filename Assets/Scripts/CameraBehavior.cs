using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour {

	public GameObject cameraBoundsMin;
	public GameObject cameraBoundsMax;

	private GameObject player;

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		player = GameObject.FindWithTag("Player");	
	}
	
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
