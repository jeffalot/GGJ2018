using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infect : MonoBehaviour 
{
	void OnCollisionEnter2D (Collision2D collision)
	{
		if (collision.gameObject.tag == "Infected"){
			this.gameObject.tag = "Infected";
		}
	}
}