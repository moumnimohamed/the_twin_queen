using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;
public class walk_jump : behavioursP {
public	float flaydelay=0.2f;	
	public		float tempFly =0f ;
		public float speed;
		public float jumpspeed;
		public Vector2 maxvelocity = new Vector2(60f,100f);

    ///*just to see velocity*/   public   float velocity_X;
 //   /*just to see velocity*/   public   float velocity_Y;
	
    /*contien les input */     public Vector2 movement ;
		/* script de colision (collision_state) */
		private collision_state collisionState;
		void Start () {
		collisionState=GetComponent<collision_state>();
		}
		

    

 /*jump puf prefeb and his position */
         public GameObject  jump_puf;
		 public Transform jump_puf_pos;


		// Update is called once per frame
		[HideInInspector]
	public	float absvlcX;
		[HideInInspector]	
	public	float absvlcY;
		void FixedUpdate () {
              
				  
			 movement =new Vector2 (CnInputManager.GetAxis("Horizontal"), CnInputManager.GetAxis("Vertical"));

		 absvlcX= Mathf.Abs(body2d.velocity.x);
		 absvlcY= Mathf.Abs(body2d.velocity.y);
			
			var  forceX =0f ;
			var  forceY =0f ;
			
			/* movement script */
	if (movement.x>0f)
	{
		if(absvlcX < maxvelocity.x){
		forceX=speed;
		transform.localScale = new Vector3(1,1,1);
		}
	}else if (movement.x<0)
	{
		if(absvlcX < maxvelocity.x){
			forceX=-speed;
		transform.localScale = new Vector3(-1,1,1);
			
		}
	}
	else 
	{

	forceX=0;
	if(collisionState.standing)
body2d.velocity =new Vector2(0,body2d.velocity.y);
	}
	/*jump script */
		
		if( tempFly<flaydelay ){
			if(movement.y>0  ){
							if (absvlcY > 40)
                            tempFly+=Time.deltaTime;

		/*tasaro3*/	if(absvlcY< maxvelocity.y)
				forceY=jumpspeed;
		
 
				}
	
		}
                                             /*for fix the porblem when colide with bridge 
											 , a have add the absvlcY <=0 on the jump anim to */
				if(collisionState.standing  &&  absvlcY <=0 ){
                         tempFly=0;

			}	
	body2d.AddForce(new Vector2( forceX,forceY));
		}

	/*	public void walk__puf() 
		{
        GameObject  puf=    Instantiate(walk_puf,pufwalk_pos.position,Quaternion.identity) as GameObject;
			  float	PUFnewscaleX=  puf.transform.localScale.x*transform.localScale.x;
		      puf.transform.localScale=new Vector3(PUFnewscaleX,1,1);
		}*/

public void jump__puf () 
		{
            Instantiate(jump_puf,jump_puf_pos.position,Quaternion.identity) ;
			 
		}
}

