using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leaf_disable : MonoBehaviour {

public float activeTime;
private float timeDelay;


/// <summary>
/// Update is called every frame, if the MonoBehaviour is enabled.
/// </summary>
void Update()
{
	timeDelay+= Time.deltaTime;

	if (timeDelay>activeTime){
		timeDelay=0;
	    this.gameObject.SetActive(false);
		
	}
}





}