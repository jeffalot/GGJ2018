using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infect : MonoBehaviour 
{

    ParticleSystem ps;

    private void Start()
    {
        ps = GetComponentInChildren<ParticleSystem>();
        //ps = (ParticleSystem) transform.gameObject.GetComponent("Particle System");
        ps.Stop();
    }

    void OnCollisionEnter2D (Collision2D collision)
	{
		if (collision.gameObject.tag == "Infected"){
			this.gameObject.tag = "Infected";
            ps.Play();
		}
	}
}