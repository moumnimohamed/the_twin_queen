using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;

public class attack : behavioursP {
	public bool  fire;
	public bool attackNow =false ;
	public bool attack_insky ;
	
public GameObject bullet_prefeb;
public float bullet_speed=500f;

public GameObject shoot_pos;
	private  collision_state soll_state;
	void Start () {
		/*collision state */
		 soll_state=GetComponent<collision_state>();
	}
	
/* time betwenn attack*/
		private	float timer=0;
	void FixedUpdate()
	{
		timer+=Time.deltaTime;		
/*active this animation on animation script */
       fire=   CnInputManager.GetButtonDown("Fire1");
	if(fire && soll_state.standing && timer>=0.5f ){
		// if player standing
		body2d.velocity =new Vector2(0,body2d.velocity.y);
           attackNow=true;  
		   timer=0;  		                
		}
		else if (fire && !soll_state.standing && !attack_insky && timer>=0.5f ){
	//	if not standing
	       attack_insky=true;  
		   timer=0;  
		}
	}




	public void	shoot_now (){
		FindObjectOfType<audio_manager>().Play("arc");
           GameObject   bullet_shoted = Instantiate( bullet_prefeb,shoot_pos.transform.position,Quaternion.identity) as GameObject ;
              bullet_shoted.GetComponent<Rigidbody2D>().velocity = new Vector2 (bullet_speed*transform.localScale.x,0);
				  bullet_shoted.transform.localScale= new Vector3 ( transform.localScale.x*bullet_shoted.transform.localScale.x,1,1);
	}

	
}
