using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infect : MonoBehaviour 
{

    bool infected;


    //Higher toxicity means more likely to imediately infect
    public float toxicity = 10f;
   

    ParticleSystem ps;

    private void Start()
    {
        // ps = GetComponentInChildren<ParticleSystem>();
        //ps = (ParticleSystem) transform.gameObject.GetComponent("Particle System");
        // ps.Stop();
    }

    void OnCollisionEnter2D (Collision2D collision)
	{
        float collisionToxicity = (Infect) collision.gameObject.GetComponent<Infect>()).toxicity;
        Debug.Log(collisionToxicity);
		if (collision.gameObject.tag == "Infected" && (Random.Range(0, 100) < collisionToxicity) {
			this.gameObject.tag = "Infected";
            // ps.Play();
		}
	}
}