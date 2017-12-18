using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sabar_attack : MonoBehaviour {



public GameObject sabar_prefeb;
public float sabarspeed;
public GameObject shoot_pos;
private bool collision_cercle;
	public float range=400f;
	public LayerMask player_layer;
	 public  Animator anim;
	  
	// Use this for initialization
	void Start () {
		anim=GetComponent<Animator>();
	}
	
	// Update is called once per frame
	float timer=0;
	void Update () {
	       timer+=Time.deltaTime;
          collision_cercle = Physics2D.OverlapCircle(transform.position,range ,player_layer);
		  if(collision_cercle ){
			  if( timer>1f){
		             anim.SetInteger("animstate",1);
					 
		       }
		        else{
		             anim.SetInteger("animstate",0);
	           }
	}else{
		             anim.SetInteger("animstate",0);
		
	}
}
public void rest_timer(){
	timer=0;
}

public void sabar_Ball_attack(){
	if(sabar_prefeb!=null){
           GameObject   sabar = Instantiate( sabar_prefeb,shoot_pos.transform.position,Quaternion.identity) as GameObject ;
         Rigidbody2D   sbr =  sabar.GetComponent<Rigidbody2D>();
			 sbr.velocity = new Vector2 (sabarspeed*-transform.localScale.x,0);
			// sbr.AddForce(Vector2.up*sabarspeed);
	}
	}

		void OnDrawGizmos()
	{
		Gizmos.color = Color.white;

		Gizmos.DrawWireSphere (transform.position, range);


		}
		public GameObject deadlyAttack;

		public void deadly_attack ()
	{
		if(deadlyAttack!=null){
		deadlyAttack.SetActive(false);      
               
		}
		}
		public void rest_deadly_attack ()
	{
		if(deadlyAttack!=null){
		deadlyAttack.SetActive(true);      
               
		}

}
}