using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swip_platform : MonoBehaviour {

public Collider2D  map_tileCollider;
public float maxTime;
public float minswipedistance;

float starttime;
float endtime;

Vector3 startpos;
Vector3 endpos;
 float swipedistance;
 float swipeTime;
	// Use this for initialization
	void Start () {
map_tileCollider=GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.touchCount>0 ){
			Touch toush= Input.GetTouch(0);

			if(toush.phase== TouchPhase.Began){
                       starttime=Time.time;
					   startpos=toush.position;
			}
			else if(toush.phase== TouchPhase.Ended){
                       endtime=Time.time;
					   endpos=toush.position;

					   swipedistance = (endpos-startpos).magnitude;
                           swipeTime=endtime-starttime;
						   if(swipeTime< maxTime && swipedistance> minswipedistance)
						   {
                                   swipe();
								   StartCoroutine("activeTileCollider");
						   }
                        
			}
		}
	}

	void swipe(){
                       Vector2 distance =endpos - startpos;
                        if( Mathf.Abs(distance.x)  <  Mathf.Abs (distance.y))
						{
							if(distance.y<0){
                         map_tileCollider.enabled=false;
							}
						}
	}

	IEnumerator   activeTileCollider (){
		yield return new WaitForSeconds(1f);
                                       map_tileCollider.enabled=true;
		
	}
}
