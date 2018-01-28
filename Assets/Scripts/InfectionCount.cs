using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectionCount : MonoBehaviour {

    float timeWorkedOn = 0;
    int infectedThings = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Mathf.Floor(Time.time) > timeWorkedOn)
        {
            timeWorkedOn = Mathf.Floor(Time.time);
            Debug.Log("One second passed " + timeWorkedOn);
            Debug.Log(countInfected() + "infected objects");

        }
    }

    int countInfected()
    {

        infectedThings = GameObject.FindGameObjectsWithTag("Infected").Length;

        if (GameObject.FindGameObjectsWithTag("Infected").Length > 20)
        {
            destroyScenery();
        }

        
        return infectedThings;

    }

    void destroyScenery()
    {

        Component[] objects = Resources.FindObjectsOfTypeAll(typeof(SetPieceBehavior)) as Component[];

            foreach (Object o in objects)
        {
            Debug.Log(o.ToString());
            GameObject go = (GameObject)o;
            SetPieceBehavior spb = go.GetComponent<SetPieceBehavior>();
            spb.RandomizeDestruction(0);
        }

    }

}
