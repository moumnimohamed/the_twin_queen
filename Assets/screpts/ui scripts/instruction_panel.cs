using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class instruction_panel : MonoBehaviour {

  
	// Use this for initialization
	  public   Image   instru_panel;
          private Text  text;
					public string message_text;
	void Start () {
		instru_panel = GameObject.Find("instruction panel").GetComponent<Image>();
		DOTween.Init();
		  text=	instru_panel.GetComponentInChildren<Text>();
		  
	}

	//just for make panel on stable posotion
	private bool restPos;
	void Update () {
		if(restPos)
		instru_panel.transform.position=transform.position+new Vector3(0,80,0);
	}
	void OnTriggerEnter2D(Collider2D other)
	{
        if (other.tag == "Player")
        {
					restPos=true;
			text.text=message_text;					
			instru_panel.DOFade(1,1f);
		  text.DOFade(1,1f);

        }
	}
	void OnTriggerExit2D(Collider2D other)
	{
        if (other.tag == "Player")
        {
					restPos=false;
			instru_panel.DOFade(0f,1f);
      text.DOFade(0f,1f);
        }
	}
}
