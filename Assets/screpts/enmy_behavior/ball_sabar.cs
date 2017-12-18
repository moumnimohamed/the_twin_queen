using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_sabar : enmy_abstractBehavior {

private float timer ;

void Update()
{
	timer += Time.deltaTime;
	if(timer>=5){
           OnExplode();		
		Destroy(this.gameObject);
	}
}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag=="bullet" || other.tag=="solid"|| other.tag=="Player"){
           OnExplode();
		}
		
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.collider.tag=="bullet" || other.collider.tag=="Player"){
           OnExplode();
		   // on exploid destroy this game object
		}
		
	}

	public  override 	void OnExplode(){
			
        base.OnExplode();
	}
}
