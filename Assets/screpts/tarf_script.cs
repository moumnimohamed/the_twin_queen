using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tarf_script : MonoBehaviour {

	// Use this for initialization
	private Rigidbody2D thisRB;
	void Awake () {
		thisRB=GetComponent<Rigidbody2D>();
		Onexploid();
	}
	
	void Onexploid (){

			thisRB.AddForce ( Vector3.up*Random.Range(2500,4000));
			thisRB.AddForce (Vector3.right*Random.Range(-2000,1500));
            
		}
}
