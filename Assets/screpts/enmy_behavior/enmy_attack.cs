using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enmy_attack : MonoBehaviour {


/* for detect collision with player (layerdetection) */
public Transform sightStart, sightEnd;
	public string layer = "player";
	public bool needsCollision = true;

	public bool metal_ball= false;
	private bool collision_line;
	

public GameObject deadlyAttack;
	    public  Animator anim;
		public MoveForward moveforward;
		private float move_speed;
 Vector2 default_vilocity ;
	public  void Start()
	{
		/*must to by may transform */
		sightStart=this.transform;
		sightEnd=transform.GetChild(2);
		//moveforward script
		moveforward =GetComponent<MoveForward>();
	/*speed from moveforward*/	move_speed =moveforward.speed;
		/*my child (attack place)  place 2 */
		anim= GetComponent<Animator>();
		 
	}
	void Update () {


       
		collision_line = Physics2D.Linecast (sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer (layer));
		Debug.DrawLine (sightStart.position, sightEnd.position, Color.blue);
	   

    
          if(collision_line){ 
			   
			  /*attack anim */
		anim.SetInteger("state",2);
		if(metal_ball!=true){
			moveforward.speed=0;
		}else{
			moveforward.speed=-70;
		}
		  }else{
		anim.SetInteger("state",3);
		moveforward.speed= move_speed;
			  
		  }
	}
	
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

	/*for red ball that shoot fire (call on animation event) */
	public float fire_spped;
	public GameObject red_fire;
	public GameObject fire_pos;
	public void shoot_red_fire(){
	if(red_fire!=null){
           GameObject   f = Instantiate( red_fire,fire_pos.transform.position,Quaternion.identity) as GameObject ;
         Rigidbody2D   ff =  f.GetComponent<Rigidbody2D>();
			 ff.velocity = new Vector2 (fire_spped*-transform.localScale.x,0);
			  ff.transform.localScale= new Vector3 ( transform.localScale.x ==2 ? ff.transform.localScale.x : -ff.transform.localScale.x*1,0.1f,1);
	}
}


public void shoot_red_ball(){
/*ball prefeb*/	if(red_fire!=null){
           GameObject   f = Instantiate( red_fire,fire_pos.transform.position,Quaternion.identity) as GameObject ;
         Rigidbody2D   ff =  f.GetComponent<Rigidbody2D>();
			 ff.velocity = new Vector2 (fire_spped*-transform.localScale.x,0);
                      
	}

}

	/*this methode for metal ball that double the move speed */



}



