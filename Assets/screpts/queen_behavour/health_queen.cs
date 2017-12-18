using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health_queen : MonoBehaviour {

public static bool alive = true;
//this is the effect for helth (hampiognon)
public GameObject health_effect;
	public int health =3 ;
	private int damage=1;
	private float lastDamage;
	
	//for apllied damage flash
  
	private SpriteRenderer spriteRender;
public Material dead_material;
	
	void Start()
	{
		spriteRender=GetComponent<SpriteRenderer>();
	}
	void FixedUpdate()
	{
		//to play damage effect just on ontrigger stay   (i use courotine for on trigger enter)
		     if (lastDamage >= 2){
         lastDamage = 0;
			 }
     lastDamage += Time.fixedDeltaTime;
	}


	void OnTriggerStay2D(Collider2D other)
	{
		if(alive){
		if(other.tag=="deadly"  &&  lastDamage >= 2){
            StartCoroutine("flash_hit")	;		 							
			takeDammage(damage);
		}
	}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(alive){
		if(other.tag=="deadly"){
          
            StartCoroutine("flash_hit")	;		 
						takeDammage(damage);
		}
		if(other.tag=="health"){
             Destroy(other.gameObject);
			 health+=1;
			 Instantiate(health_effect,other.transform.position,Quaternion.identity);
		}
	}
	}
	/*for just the blue ball collider detection */
	void OnCollisionStay2D(Collision2D other)
	{
		if(alive){
		if(other.collider.tag=="deadly"  &&  lastDamage >= 2 ){
            StartCoroutine("flash_hit")	;		 
			takeDammage(damage);
		}
	}
		
	}

	public	 Color [] colors  = new Color[3];
  IEnumerator flash_hit() {
 spriteRender.material.color = colors[0];
 yield return new  WaitForSeconds(.1f);
 spriteRender.material.color = colors[2];
 yield return new  WaitForSeconds(.1f); 
 spriteRender.material.color = colors[0];
 yield return new  WaitForSeconds(.1f);
 spriteRender.material.color = colors[1];
 }
public void takeDammage(int d)
{
             health-=d;	       	
	  if(health<=0)
			 Dead();

}

void Dead (){
	alive=false; 
	        
}
}
