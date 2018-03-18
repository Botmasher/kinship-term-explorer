using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSetup : MonoBehaviour {

	// basic node
	public GameObject member;
	// possible ties
	public GameObject relSpouse;
	public GameObject relHoriz;
	public GameObject relVert;

	// positioning
	public Vector2 origin; 					// ego
	[Range(0f,20f)]public float spacingX;
	[Range(0f,20f)]public float spacingY;

	void Awake () {
		this.placeNodes ();
	}

	// Handpicked placement of nodes and ties
	// TODO place and connect dynamically based on node properties
	void placeNodes() {
		// ego
		GameObject ego = GameObject.Instantiate (member, origin, Quaternion.identity) as GameObject;
		// ego's siblings
		Vector2 bPos = new Vector2(ego.transform.position.x + spacingX, ego.transform.position.y);
		GameObject b = GameObject.Instantiate (member, bPos, Quaternion.identity) as GameObject;
		Vector2 zPos = new Vector2(ego.transform.position.x - spacingX, ego.transform.position.y);
		GameObject z = GameObject.Instantiate (member, zPos, Quaternion.identity) as GameObject;
		// ego's parents
		Vector2 mPos = new Vector2(ego.transform.position.x - (spacingX * 0.5f), ego.transform.position.y + spacingY);
		GameObject m = GameObject.Instantiate (member, mPos, Quaternion.identity) as GameObject;
		Vector2 fPos = new Vector2(ego.transform.position.x + (spacingX * 0.5f), ego.transform.position.y + spacingY);
		GameObject f = GameObject.Instantiate (member, fPos, Quaternion.identity) as GameObject;
		// ego's grandparents
		Vector2 mmPos = new Vector2(m.transform.position.x - (spacingX * 0.5f), m.transform.position.y + spacingY);
		GameObject mm = GameObject.Instantiate (member, mmPos, Quaternion.identity) as GameObject;
		Vector2 mfPos = new Vector2(m.transform.position.x - (spacingX * 1.5f), m.transform.position.y + spacingY);
		GameObject mf = GameObject.Instantiate (member, mfPos, Quaternion.identity) as GameObject;
		Vector2 ffPos = new Vector2(f.transform.position.x + (spacingX * 0.5f), f.transform.position.y + spacingY);
		GameObject ff = GameObject.Instantiate (member, ffPos, Quaternion.identity) as GameObject;
		Vector2 fmPos = new Vector2(f.transform.position.x + (spacingX * 1.5f), f.transform.position.y + spacingY);
		GameObject fm = GameObject.Instantiate (member, fmPos, Quaternion.identity) as GameObject;
		// ego's father's siblings
		Vector2 fbPos = new Vector2(f.transform.position.x + spacingX, f.transform.position.y);
		GameObject fb = GameObject.Instantiate (member, fbPos, Quaternion.identity) as GameObject;
		Vector2 fzPos = new Vector2(f.transform.position.x + (spacingX * 2f), f.transform.position.y);
		GameObject fz = GameObject.Instantiate (member, fzPos, Quaternion.identity) as GameObject;
		// ego's mother's siblings
		Vector2 mbPos = new Vector2(m.transform.position.x - spacingX, m.transform.position.y);
		GameObject mb = GameObject.Instantiate (member, mbPos, Quaternion.identity) as GameObject;
		Vector2 mzPos = new Vector2(m.transform.position.x - (spacingX * 2f), m.transform.position.y);
		GameObject mz = GameObject.Instantiate (member, mzPos, Quaternion.identity) as GameObject;
		// ego's father's siblings' children
		// ego's mother's siblings' children
	}

}
