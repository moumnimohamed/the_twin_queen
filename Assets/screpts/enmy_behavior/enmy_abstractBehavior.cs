using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enmy_abstractBehavior : MonoBehaviour {


   
   public GameObject effet_pos;
   public GameObject dammage_effect;
   public  Color dammage_effectCOLOR;
    public GameObject debris;
   public  Color debrisCOLOR;
	
	public int totalDebris = 10;


//for applied damage flash
	 public Material white_material;
	public SpriteRenderer spriteRender;
	public Material default_material;
	
	
    public int health ;  
     protected Rigidbody2D body2d_enmy;
	 
	// Use this for initialization
	protected virtual void Awake () {
		//inherted by all enemies enmy_abstractBehavior   !!!!!!!!!!!!!!!!!!
		spriteRender= GetComponent<SpriteRenderer>();
		default_material = spriteRender.material;
		body2d_enmy=GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame




	
public virtual	void OnExplode(){
   //  dont forget the alpha of debris color  §§§§§§§§§§!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
		var t =effet_pos. transform;
    GameObject	Effect=	 Instantiate (dammage_effect,effet_pos. transform.position, Quaternion.identity);
		 SpriteRenderer EFFECTsprite = Effect.GetComponent<SpriteRenderer>();
			EFFECTsprite.color = dammage_effectCOLOR;
		for (int i = 0; i < totalDebris; i++) {

			t.TransformPoint (0, -100, 0);
			GameObject clone = Instantiate (debris, t.position, Quaternion.identity) as GameObject;
			SpriteRenderer sprite =clone.GetComponent<SpriteRenderer>();
			sprite.color=debrisCOLOR;
			var body2D = clone.GetComponent<Rigidbody2D> ();

			body2D.AddForce (Vector3.right * Random.Range (-3000, 3000));
			body2D.AddForce (Vector3.up * Random.Range (2000, 6000));
		}

		Destroy (gameObject);
	}



	
}
