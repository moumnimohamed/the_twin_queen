using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour {



    // this bool just for metal ball to run it against the player
	public float speed = -20f;

	private Rigidbody2D body2D;
	

	// Use this for initialization
	void Start () {
		body2D = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		body2D.velocity = new Vector2 (transform.localScale.x * speed, 0) ;
	}
}
