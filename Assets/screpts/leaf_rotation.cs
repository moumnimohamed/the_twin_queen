using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leaf_rotation : MonoBehaviour {





public float rotate_speed;
	// Use this for initialization
	void Start () {
		rotate_speed=Random.Range(1,3)	;
		}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0,0,rotate_speed);
	
	}
}
