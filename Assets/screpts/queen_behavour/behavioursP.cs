using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class behavioursP : MonoBehaviour {

	public MonoBehaviour [] mono_script;
 protected Rigidbody2D  body2d ;

	void Awake()
	{
	
		     body2d= GetComponent<Rigidbody2D>();

	}
	
	public virtual void toogle_script(){
		foreach(MonoBehaviour sc in mono_script){
			sc.enabled=false;
		}
	}
	public virtual void Active_toogle_script(){
		foreach(MonoBehaviour sc in mono_script){
			sc.enabled=true;
		}
		}
	
}
