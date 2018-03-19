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
	[Range(0f,4f)]public float spacingX;
	[Range(0f,4f)]public float spacingY;

	void Awake () {
		this.placeMembers ();
	}

	// Handpicked placement of family members on "board"
	// TODO place and connect dynamically based on node properties
	void placeMembers() {
		// ego
		GameObject ego = GameObject.Instantiate (member, origin, Quaternion.identity) as GameObject;
		// ego's siblings
		Vector2 bPos = new Vector2(ego.transform.position.x + spacingX, ego.transform.position.y);
		GameObject b = GameObject.Instantiate (member, bPos, Quaternion.identity) as GameObject;
		Vector2 zPos = new Vector2(ego.transform.position.x - spacingX, ego.transform.position.y);
		GameObject z = GameObject.Instantiate (member, zPos, Quaternion.identity) as GameObject;
		// ego's parents
		Vector2 mPos = new Vector2(ego.transform.position.x - (spacingX * 0.75f), ego.transform.position.y + spacingY);
		GameObject m = GameObject.Instantiate (member, mPos, Quaternion.identity) as GameObject;
		Vector2 fPos = new Vector2(ego.transform.position.x + (spacingX * 0.75f), ego.transform.position.y + spacingY);
		GameObject f = GameObject.Instantiate (member, fPos, Quaternion.identity) as GameObject;
		// ego's grandparents
		Vector2 mmPos = new Vector2(m.transform.position.x - (spacingX * 0.5f), m.transform.position.y + spacingY);
		GameObject mm = GameObject.Instantiate (member, mmPos, Quaternion.identity) as GameObject;
		Vector2 mfPos = new Vector2(m.transform.position.x - (spacingX * 2f), m.transform.position.y + spacingY);
		GameObject mf = GameObject.Instantiate (member, mfPos, Quaternion.identity) as GameObject;
		Vector2 ffPos = new Vector2(f.transform.position.x + (spacingX * 0.5f), f.transform.position.y + spacingY);
		GameObject ff = GameObject.Instantiate (member, ffPos, Quaternion.identity) as GameObject;
		Vector2 fmPos = new Vector2(f.transform.position.x + (spacingX * 2f), f.transform.position.y + spacingY);
		GameObject fm = GameObject.Instantiate (member, fmPos, Quaternion.identity) as GameObject;
		// ego's father's siblings
		Vector2 fbPos = new Vector2(f.transform.position.x + (spacingX * 2f), f.transform.position.y);
		GameObject fb = GameObject.Instantiate (member, fbPos, Quaternion.identity) as GameObject;
		Vector2 fzPos = new Vector2(f.transform.position.x + (spacingX * 4f), f.transform.position.y);
		GameObject fz = GameObject.Instantiate (member, fzPos, Quaternion.identity) as GameObject;
		// ego's mother's siblings
		Vector2 mbPos = new Vector2(m.transform.position.x - (spacingX * 2f), m.transform.position.y);
		GameObject mb = GameObject.Instantiate (member, mbPos, Quaternion.identity) as GameObject;
		Vector2 mzPos = new Vector2(m.transform.position.x - (spacingX * 4f), m.transform.position.y);
		GameObject mz = GameObject.Instantiate (member, mzPos, Quaternion.identity) as GameObject;
		// ego's father's siblings' children
		Vector2 mbsPos = new Vector2(mb.transform.position.x - (spacingX * 0.5f), mb.transform.position.y - spacingY);
		GameObject mbs = GameObject.Instantiate (member, mbsPos, Quaternion.identity) as GameObject;
		Vector2 mbdPos = new Vector2(mb.transform.position.x + (spacingX * 0.5f), mb.transform.position.y - spacingY);
		GameObject mbd = GameObject.Instantiate (member, mbdPos, Quaternion.identity) as GameObject;
		Vector2 mzsPos = new Vector2(mz.transform.position.x - (spacingX * 0.5f), mz.transform.position.y - spacingY);
		GameObject mzs = GameObject.Instantiate (member, mzsPos, Quaternion.identity) as GameObject;
		Vector2 mzdPos = new Vector2(mz.transform.position.x + (spacingX * 0.5f), mz.transform.position.y - spacingY);
		GameObject mzd = GameObject.Instantiate (member, mzdPos, Quaternion.identity) as GameObject;
		// ego's mother's siblings' children
		Vector2 fbsPos = new Vector2(fb.transform.position.x - (spacingX * 0.5f), fb.transform.position.y - spacingY);
		GameObject fbs = GameObject.Instantiate (member, fbsPos, Quaternion.identity) as GameObject;
		Vector2 fbdPos = new Vector2(fb.transform.position.x + (spacingX * 0.5f), fb.transform.position.y - spacingY);
		GameObject fbd = GameObject.Instantiate (member, fbdPos, Quaternion.identity) as GameObject;
		Vector2 fzsPos = new Vector2(fz.transform.position.x - (spacingX * 0.5f), fz.transform.position.y - spacingY);
		GameObject fzs = GameObject.Instantiate (member, fzsPos, Quaternion.identity) as GameObject;
		Vector2 fzdPos = new Vector2(fz.transform.position.x + (spacingX * 0.5f), fz.transform.position.y - spacingY);
		GameObject fzd = GameObject.Instantiate (member, fzdPos, Quaternion.identity) as GameObject;
	}

}
