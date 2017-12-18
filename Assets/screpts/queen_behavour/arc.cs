using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arc : MonoBehaviour {

	public GameObject Effect;
	private Rigidbody2D Rigidb;
	private Debris debris;

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag =="hidenTile"){
			return;
		}
		else{
                                                /*break tag for breakable object */
						if(other.tag =="enmy" || other.tag =="break" || other.tag =="deadly" ){
					GameObject efc= Instantiate(Effect ,transform.position,Quaternion.identity) as GameObject;
								efc.transform.localScale=new Vector3(1*transform.localScale.x ,1,1);
						Destroy(this.gameObject);
						}
						else if(other.tag =="solid")
						{
							Rigidb=GetComponent<Rigidbody2D>();
							//debris le cvript qui me permet detre insparant
							debris=GetComponent<Debris>();
							Rigidb.velocity= new Vector2(0,0);
							debris.enabled=true;
						}
					}
}
}
