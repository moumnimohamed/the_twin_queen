using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random_leaf_generateur : MonoBehaviour {

	// Use this for initialization
	public int leam_amount;
	public GameObject[]  leaf_prefeb ;
	public List<GameObject> leaf_list = new List<GameObject>();
	void Start () {
     for(int i=0;i<leam_amount;i++)
	 {
             GameObject leaf = Instantiate(leaf_prefeb[0]) as  GameObject ;
                leaf.SetActive(false);
               leaf_list.Add(leaf);

			     leaf = Instantiate(leaf_prefeb[1])  as  GameObject ;
				 leaf.SetActive(false);
               leaf_list.Add(leaf);

			     leaf = Instantiate(leaf_prefeb[2]) as  GameObject ;
				 leaf.SetActive(false);				 
               leaf_list.Add(leaf);

			     leaf = Instantiate(leaf_prefeb[3])  as  GameObject ;
				 leaf.SetActive(false);				 
               leaf_list.Add(leaf);
	 }
	 
   StartCoroutine("random_leaf");

	}
	
IEnumerator  random_leaf () 
{
       foreach(GameObject leafo in leaf_list ){
	   if (! leafo.activeInHierarchy){
	          Vector3    mypos =transform.position;
	Vector3	 newpos =new Vector3 ( Random.Range(mypos.x-300,mypos.x+500),mypos.y,mypos.z);
				  leafo.transform.position=newpos;
				  leafo.transform.rotation=transform.rotation;
                  leafo.SetActive(true);
				  break;
           }
		
	   }
yield return new WaitForSeconds (0.3f);
	    StartCoroutine("random_leaf");

}


}
