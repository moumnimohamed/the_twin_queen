using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tresure : MonoBehaviour {



public int resestance_amoung=0;
     public int coin_nbr;
   public GameObject [] coin;
   
    private Animator anim ;
	private BoxCollider2D boxColli;
	private Rigidbody2D  Rigidb;
	// Use this for initialization

/*for applied flash dammage */
   private SpriteRenderer spriteRender;
	  public Material white_material;
	private Material default_material;
	void Start()
	{

		spriteRender=GetComponent<SpriteRenderer>();
		anim=GetComponent<Animator>();
		boxColli=GetComponent<BoxCollider2D>();
		Rigidb=GetComponent<Rigidbody2D>();
				default_material=spriteRender.material;

	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag== "bullet") {
				spriteRender.material=white_material;
			 StartCoroutine("damage_effect");
			resestance_amoung=resestance_amoung-1;
				if (resestance_amoung <= 0) {
		          	anim.SetInteger("triso",1);
					  Rigidb.gravityScale=0;
					  boxColli.enabled=false;
				}
		        
		}

	}
	public void gave_coin(){
				for(int i=0;i<=coin_nbr;i++){
					int nbr =(int) Random.Range(0,coin.Length);
		GameObject co=		Instantiate (coin[nbr], transform.position, Quaternion.identity);
				co.GetComponent<Rigidbody2D>().AddForce( new Vector2 (Random.Range(-1000,1000),4000));		
				}	
			}
IEnumerator  damage_effect(){
	yield return new WaitForSeconds (0.1f);
			spriteRender.material=default_material;						
}
	}

