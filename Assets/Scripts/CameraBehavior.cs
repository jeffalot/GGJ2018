using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour {

	public GameObject cameraBoundsMin;
	public GameObject cameraBoundsMax;

	private bool start;

	private GameObject player;

	public float transitionDuration = 0;
	public Vector3 StartTarget;

	IEnumerator Transition()
	{
		float t = 0.0f;
		Vector3 startingPos = transform.position;
		while (t < 1.0f)
		{
			t += Time.deltaTime * (Time.timeScale/transitionDuration);
			transform.position = Vector3.Lerp(startingPos, StartTarget, t);
			yield return 0;
		}
	}

	void Start () {
		player = GameObject.FindWithTag ("Player");
		start = false;
	}

	// Update is called once per frame
	void Update () {



		if (start){
			
			float newCameraPosX = Mathf.Clamp (
				player.transform.position.x,
				cameraBoundsMin.transform.position.x,
				cameraBoundsMax.transform.position.x
			);

			transform.position = new Vector3 (
				newCameraPosX,
				transform.position.y,
				transform.position.z
			);
		} else {
			if (Input.GetButtonDown ("Jump")) {
				start = true;
				// StartCoroutine(Transition());
				transform.position = StartTarget;
			}
		}


		// Current Goal Pointer

	}
}