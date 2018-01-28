using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehavior : MonoBehaviour {


    public float speed = 100f;
    public float freq = .5f;
    public float amp = .5f;

    public float seed = 0f;

	// Use this for initialization
	void Start () {

        seed = Random.Range(0f, 1000f);

	}
	
	// Update is called once per frame
	void FixedUpdate () {


        var pos = transform.position;
        pos.x += Mathf.Sin(freq * (Time.time + seed) ) * amp;  //speed* Time.deltaTime;
        
        transform.position = pos;

        

    }
}
