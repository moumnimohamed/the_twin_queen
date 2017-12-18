using UnityEngine;
using System.Collections;

public class LookForward : MonoBehaviour {


     //the scale for this game obecjt on multiplucation operan on local scal x
	 public float scale=2f ;
	public Transform sightStart, sightEnd;
	public string layer = "solid";
	public bool needsCollision = true;

	private bool collision;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		collision = Physics2D.Linecast (sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer (layer));

		Debug.DrawLine (sightStart.position, sightEnd.position, Color.green);

		if (collision == needsCollision) {
			transform.localScale = new Vector3 (transform.localScale.x == scale ? -scale : scale, scale, scale);
		}

	}
}
