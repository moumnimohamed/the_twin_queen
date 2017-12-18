using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakable_items : MonoBehaviour {



	public GameObject break_effect;
	public int resestance_amoung=0;
     public int coin_nbr;
   public GameObject coin;
   
    private Animator anim ;

			public SpriteRenderer spriteRender;
				private Material default_material;
 	         public Material white_material;


	void Start()
	{
				spriteRender=GetComponent<SpriteRenderer>();
		default_material=spriteRender.material;
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		
		if (other.tag== "bullet") {
			Destroy(other.gameObject);
			
		gave_coin();
		}

	}

	public void gave_coin(){
			resestance_amoung-=1;
		if(spriteRender!=null && white_material!=null)			
			 spriteRender.material=white_material;
            StartCoroutine("damage_effect")	;
			if (resestance_amoung <= 0) {
               //  (trofa)
            var trofa_PRF = Instantiate(break_effect, transform.position, Quaternion.identity) as GameObject;
				for(int i=0;i<=coin_nbr;i++){
		GameObject co=		Instantiate (coin, transform.position, Quaternion.identity);
				co.GetComponent<Rigidbody2D>().AddForce( new Vector2 (Random.Range(-2000f,2000f),4000));		
				}
				Destroy(trofa_PRF,1f);
				Destroy (this.gameObject);
				
			}
	}
public 	IEnumerator  damage_effect(){
	yield return new WaitForSeconds (0.2f);
			spriteRender.material=default_material;	
			}
	
}
