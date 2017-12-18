using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectable_coin_diamond : MonoBehaviour {

	

public GameObject effect;

	/// <summary>
	/// Sent when another object enters a trigger collider attached to this
	/// object (2D physics only).
	/// </summary>
	/// <param name="other">The other Collider2D involved in this collision.</param>
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag=="Player") {
			Instantiate(effect,transform.position,Quaternion.identity);
			Destroy(this.gameObject);
		}
	}
	/// <summary>
	/// Sent when an incoming collider makes contact with this object's
	/// collider (2D physics only).
	/// </summary>
	/// <param name="other">The Collision2D data associated with this collision.</param>
void OnCollisionEnter2D(Collision2D other)
	{
		if(other.collider.tag=="Player") {
			Instantiate(effect,transform.position,Quaternion.identity);
			Destroy(this.gameObject);
		}
	}
}
