using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class queen_anim : behavioursP {

	// Use this for initialization
	public collision_state collision2d_state;
	public walk_jump Walk;
	
	/*attack script */
	attack attack_sc;
	public Animator anim;
	void Start () {
		collision2d_state=GetComponent<collision_state>();
		attack_sc=GetComponent<attack>();
		
		Walk=GetComponent<walk_jump>();
		
		anim=GetComponent<Animator>();
		
	}
	/*change to stay jump animation */
  public bool stay=false;
	public void stay_jumping(){
               stay=true;
	}
		private	float timer=0;
	// Update is called once per frame
	void FixedUpdate () {
	

     if( ! attack_sc.attackNow)  {
		
  /*jump animation just for the begin of anim*/        
     if (!collision2d_state.standing && stay==false   )
	     {
				animation_state(2);
		}
		/*for stay jumping in the sky */
if(!collision2d_state.standing && stay==true &&  body2d.velocity.y >0  ){
				animation_state(3);
}
/*down from jump */
if(!collision2d_state.standing  &&  body2d.velocity.y <0  ){
				animation_state(6);
}

		/*idle animation */                      /*for fix the porblem when colide with bridge 
											             , a have add the &&  absvlcY <=0 on the walk_jump script to */ 
			 if (collision2d_state.standing   &&  Walk.absvlcY <=0 ){
				animation_state(0);
				stay=false;
			}

			/*walk animation */
			 if (Walk.movement.x !=0f && collision2d_state.standing ){
				animation_state(1);
			}

	}
			/*attack animation */
	
	 if ( attack_sc.attackNow ){
				animation_state(4);
		timer+=Time.deltaTime;
				
			}
			/*attack animation in sky */
			
		if ( attack_sc.attack_insky ){
				animation_state(5);
		timer+=Time.deltaTime;				
			}
/*for colose attack anim */
			if(   attack_sc.attackNow && timer>=0.5f ){
			        attack_sc.attackNow=false;
					timer=0;
			}
		if(   attack_sc.attack_insky && timer>=0.5f ){
			        attack_sc.attack_insky=false;
					timer=0;
			
        	}
	}

/*funt to switch between animation */
	private void animation_state (int value){
        anim.SetInteger("AnimState",value);
	}
}
