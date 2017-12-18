using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missile : MonoBehaviour {

   
	public GameObject target;
	public float distance;
	private bool collision_cercle=false;
	public float range=200f;
	public LayerMask player_layer;
	public float folow_speed;
   private  bool  folow=false;
	// Use this for initialization
	void Start () {

	if (target == null)
						target = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
              
          
		  collision_cercle = Physics2D.OverlapCircle(transform.position,range ,player_layer);
		  if(collision_cercle ){
                  folow=true;
		  }

		  if(folow ){
	if (target != null)   {   
						transform.position = Vector3.MoveTowards (transform.position, 
						target.transform.position, folow_speed);
						 distance = transform.position.x -target.transform.position.x;
						if(distance>0){
							transform.localScale=new Vector3(-1,1,1);									
						}else
							{
							transform.localScale=new Vector3(1,1,1);
							}
						
		  }
		  }
				}
	

	void OnDrawGizmos()
	{
		Gizmos.color = Color.white;

		Gizmos.DrawWireSphere (transform.position, range);


		}
	}
