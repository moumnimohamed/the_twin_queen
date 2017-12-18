using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;




public class enmy_health : enmy_abstractBehavior {

   public GameObject [] coins ;
	public Transform health_bar;

	//health bar shield
	private Image HLTbar_shild_1;
	private Image HLTbar_shild_2;
	
     private int curenthealth;
	protected override void Awake(){
		
		base.Awake();
				DOTween.Init();

		//rec transform for hltbar chield
		HLTbar_shild_2 = health_bar.GetChild(0).GetComponent<Image>();
		HLTbar_shild_1 = health_bar.GetChild(1).GetComponent<Image>();
		
		
		curenthealth=health;
	}
    private bool isColliding=true;	
	void Update()
	{
		isColliding=false;
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		/*for desable double detection for reduse health */
		if(isColliding) return;
     isColliding = true;
			if(other.tag =="bullet")
              {
			  curenthealth =curenthealth-1;
			  // helthbarr decrease
			  HLTbar_shild_1.DOFade(1,0.2f);
			  HLTbar_shild_2.DOFade(1,0.2f);
			  
			  
			  HLTbar_shild_1.fillAmount= (float)  curenthealth/  health;
			  spriteRender.material=white_material;
            StartCoroutine("damage_effect")	;
			   if(  curenthealth<=0 )
		           {
		             	OnExplode();
		            }	
			  				
		    }
	}
public 	IEnumerator  damage_effect(){
	yield return new WaitForSeconds (0.2f);
			spriteRender.material=default_material;	
	yield return new WaitForSeconds (2f);			
			  HLTbar_shild_1.DOFade(0,1f);
			  HLTbar_shild_2.DOFade(0,1f);
			  
								
}
	public  override 	void OnExplode(){
        base.OnExplode();
		int nbr =(int) Random.Range(0,coins.Length);
		for(int i=0;i<nbr;i++){
	GameObject	coin = Instantiate(coins[i],transform.position,Quaternion.identity);
		var coinbody = coin.GetComponent<Rigidbody2D> ();
			coinbody.AddForce (Vector3.right * Random.Range (-3000, 3000));
			coinbody.AddForce (Vector3.up * Random.Range (2000, 6000));
		}
	}



	
}
