using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;
public class boster_move : behavioursP {


// make an effect with quenn color sprites
 public GameObject [] color_flash_queen ;
 private List<GameObject> List_queen_flash = new List<GameObject>();
 private bool flash_now;
private float default_gra;
		private  collision_state soll_state;
		public bool just2=true;
		public int step =2;
		public float power;

    [Space]
	public Transform posEffect;

		
	void Start () {
		/*add sprite to list */
		for(int i=0; i<9;i++){
         GameObject flash =  Instantiate(color_flash_queen[i]);
		 flash.SetActive(false);
		 List_queen_flash.Add(flash);
		}
		/*collision state */
		 soll_state=GetComponent<collision_state>();
		 default_gra=body2d.gravityScale;
	}
	
	
	private	float timer=0;
	void FixedUpdate()
	{
		/* time betwenn button tap (bosster) */
	
		timer+=Time.deltaTime;
	bool	 bosster=CnInputManager.GetButtonDown("Fire2");
	if(bosster && !soll_state.standing && just2 ==false  && timer>0.5f ){
		timer=0;
	/*how many time play dust */	
	step=step-1;
		 if(step==0){
		just2=true;
		  }
	/*stop gravity*/	  body2d.gravityScale=0;
  	/*stop velocity*/	  body2d.velocity=new Vector2(0, 0);
		// if player standing
		float	power_derction;
		if (transform.localScale.x ==1){
                  power_derction=power;
		}else{
                  power_derction=-power;
		}
		body2d.AddForce(Vector2.right*power_derction );
		StartCoroutine("rest_gravity");
          
		 
		/*play flash loop  */
		flash_now=true;
		
		//desactiver des script
		toogle_script();
		}

if(soll_state.standing){
		just2=false;  
		step=2;
}
		
		if(flash_now){
		//gave flash sprite queen (eefect)
		StartCoroutine("play_flash_quenn");
		}
	}
     
	 public override void toogle_script(){
		 base.toogle_script();
	 }
	 public override void Active_toogle_script(){
		 base.Active_toogle_script();
	 }
	//return the default gravity
	IEnumerator rest_gravity(){
          yield return new WaitForSeconds(0.5f);
		  body2d.gravityScale=default_gra;
		//  body2d.velocity=default_velocity;
	/*stop velocity*/	  body2d.velocity=new Vector2(0, body2d.velocity.y); 
	}
   


	IEnumerator  play_flash_quenn(){
		foreach( GameObject f in List_queen_flash){
			if(!f.activeInHierarchy){
				f.transform.position=posEffect.position;
				f.transform.localScale =new Vector3(transform.localScale.x,transform.localScale.y,transform.localScale.z);
				f.SetActive(true);
          yield return new WaitForSeconds(0.1f);								
			}			
		}
               flash_now=false;
  /* hied active sprite effct flash */
	foreach( GameObject f in List_queen_flash){
			if(f.activeInHierarchy){
				f.SetActive(false);
			}
		}
		Active_toogle_script();
	}
}
