using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using DG.Tweening;


public class hieden_tile_fading  :MonoBehaviour {
     
  public   Tilemap   this_hiedenTile;
	//public TilemapRenderer2D renderer2D;
	private Color start;
	private Color end;
	public float t = 0f;
	void Start()
	{
	   this_hiedenTile = GetComponent<Tilemap> ();
        start =this_hiedenTile.color;
	end = new Color (start.r, start.g, start.b, 0f);
	}
    public bool fadeIN;
    public bool fadeOUT;
	
/// <summary>
/// Update is called every frame, if the MonoBehaviour is enabled.
/// </summary>
void Update()
{
	if(fadeIN){
	t += Time.deltaTime;
	this_hiedenTile.color = Color.Lerp (start, end, t*4);
	if(this_hiedenTile.color == end )
	fadeIN=false;
	}

	if(fadeOUT){

			t += Time.deltaTime;		
this_hiedenTile.color = Color.Lerp ( this_hiedenTile.color ,start , t*4);
         	if(this_hiedenTile.color == start )
	fadeOUT=false;
	}
}


  
	void OnTriggerEnter2D(Collider2D other)
	{
  
        if (other.tag == "Player")
        {
            t = 0;
            fadeIN = true;
        }
		return;
	}

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag =="Player")
        {
            t = 0;
            fadeOUT = true;
        }
    }


	}
