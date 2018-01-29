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
        if (Mathf.Floor (Time.time) > timeWorkedOn + 2) {
            timeWorkedOn = Mathf.Floor (Time.time);
            Debug.Log ("Three seconds passed " + timeWorkedOn);
            Debug.Log (countInfected () + "infected objects");
        }
    }

    int countInfected () {

        infectedThings = GameObject.FindGameObjectsWithTag ("Infected").Length;

        if (infectedThings > 20) {
            destroyScenery (3);
        }

        return infectedThings;

    }

    void destroyScenery (int Base) {

        Component[] objects = Resources.FindObjectsOfTypeAll (typeof (SetPieceBehavior)) as Component[];

        foreach (Component c in objects) {
            Debug.Log (c.ToString ());
            SetPieceBehavior spb = (SetPieceBehavior) c;
            spb.RandomizeDestruction (Base, Base + 1);
        }

    }

}