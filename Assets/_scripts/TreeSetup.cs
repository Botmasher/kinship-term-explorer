using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSetup : MonoBehaviour {

	// basic node
	public GameObject member;

	// ties between nodes
	public GameObject tieNarrow3;	// designed for ego and ego's siblings
	public GameObject tieNarrow2; 	// designed for cousins
	public GameObject tieWide3; 	// designed for one generation up
	public GameObject tieSpouse; 	// designed for ego's parents
	public GameObject tieEquals; 	// alternative design for parents or grandparents

	// family nodes manager
	public NodesManager nodesManager;

	// positioning
	public Vector2 origin;
	[Range(0f,4f)]public float spacingX;
	[Range(0f,4f)]public float spacingY;

	void Start () {
		Dictionary<string, GameObject> fam = this.PlaceMembers ();
		this.placeTies (fam);
		nodesManager.SetFamily (fam);
	}

	// Handpicked placement of family ties
	// TODO connect dynamically based on node properties
	void placeTies(Dictionary<string, GameObject> family) {

		// TODO or more advanced: flip an elbow connector for L/R siblings

		// tie ego to siblings
		GameObject.Instantiate (tieNarrow3, new Vector2(family ["ego"].transform.position.x, family["ego"].transform.position.y + spacingY * 0.5f), tieNarrow3.transform.rotation);

		// tie ego's parents
		GameObject.Instantiate (tieSpouse, new Vector2(family ["ego"].transform.position.x, family["ego"].transform.position.y + spacingY), tieSpouse.transform.rotation);

		// tie ego's aunts and uncles
		GameObject.Instantiate (tieWide3, new Vector2(family ["mz"].transform.position.x * 0.98f, family["mz"].transform.position.y + spacingY * 0.5f), tieWide3.transform.rotation);
		GameObject fbTie = GameObject.Instantiate (tieWide3, new Vector2(family ["fb"].transform.position.x * 0.98f, family["fb"].transform.position.y + spacingY * 0.5f), tieWide3.transform.rotation) as GameObject;
		fbTie.GetComponent<SpriteRenderer> ().flipX = true;

		// tie ego's grandparents
		GameObject.Instantiate (tieEquals, new Vector2(family ["mf"].transform.position.x + spacingX * 0.75f, family["mf"].transform.position.y), tieEquals.transform.rotation);
		GameObject.Instantiate (tieEquals, new Vector2(family ["fm"].transform.position.x - spacingX * 0.81f, family["fm"].transform.position.y), tieEquals.transform.rotation);

		// tie ego's cousins
		GameObject.Instantiate (tieNarrow2, new Vector2(family ["mb"].transform.position.x, family["mb"].transform.position.y - spacingY * 0.5f), tieNarrow2.transform.rotation);
		GameObject.Instantiate (tieNarrow2, new Vector2(family ["mz"].transform.position.x, family["mz"].transform.position.y - spacingY * 0.5f), tieNarrow2.transform.rotation);
		GameObject.Instantiate (tieNarrow2, new Vector2(family ["fb"].transform.position.x, family["fb"].transform.position.y - spacingY * 0.5f), tieNarrow2.transform.rotation);
		GameObject.Instantiate (tieNarrow2, new Vector2(family ["fz"].transform.position.x, family["fz"].transform.position.y - spacingY * 0.5f), tieNarrow2.transform.rotation);
	}

	// Handpicked placement of family members on "board"
	// TODO place dynamically based on node properties
	Dictionary<string, GameObject> PlaceMembers() {
		// ego
		GameObject ego = GameObject.Instantiate (member, origin, Quaternion.identity) as GameObject;
		ego.GetComponent<FamilyMember> ().ToggleSexMarking ("F");
		// TODO handle ego setting for age-marked and sex-marked terms

		// ego's siblings
		Vector2 bPos = new Vector2(ego.transform.position.x + spacingX, ego.transform.position.y);
		GameObject b = GameObject.Instantiate (member, bPos, Quaternion.identity) as GameObject;
		b.GetComponent<FamilyMember> ().ToggleSexMarking ("M");
		Vector2 zPos = new Vector2(ego.transform.position.x - spacingX, ego.transform.position.y);
		GameObject z = GameObject.Instantiate (member, zPos, Quaternion.identity) as GameObject;
		z.GetComponent<FamilyMember> ().ToggleSexMarking ("F");

		// ego's parents
		Vector2 mPos = new Vector2(ego.transform.position.x - (spacingX * 0.75f), ego.transform.position.y + spacingY);
		GameObject m = GameObject.Instantiate (member, mPos, Quaternion.identity) as GameObject;
		m.GetComponent<FamilyMember> ().ToggleSexMarking ("F");
		Vector2 fPos = new Vector2(ego.transform.position.x + (spacingX * 0.75f), ego.transform.position.y + spacingY);
		GameObject f = GameObject.Instantiate (member, fPos, Quaternion.identity) as GameObject;
		f.GetComponent<FamilyMember> ().ToggleSexMarking ("M");

		// ego's grandparents
		Vector2 mmPos = new Vector2(m.transform.position.x - (spacingX * 0.5f), m.transform.position.y + spacingY);
		GameObject mm = GameObject.Instantiate (member, mmPos, Quaternion.identity) as GameObject;
		mm.GetComponent<FamilyMember> ().ToggleSexMarking ("F");
		Vector2 mfPos = new Vector2(m.transform.position.x - (spacingX * 2.1f), m.transform.position.y + spacingY);
		GameObject mf = GameObject.Instantiate (member, mfPos, Quaternion.identity) as GameObject;
		mf.GetComponent<FamilyMember> ().ToggleSexMarking ("M");
		Vector2 ffPos = new Vector2(f.transform.position.x + (spacingX * 0.5f), f.transform.position.y + spacingY);
		GameObject ff = GameObject.Instantiate (member, ffPos, Quaternion.identity) as GameObject;
		ff.GetComponent<FamilyMember> ().ToggleSexMarking ("M");
		Vector2 fmPos = new Vector2(f.transform.position.x + (spacingX * 2.1f), f.transform.position.y + spacingY);
		GameObject fm = GameObject.Instantiate (member, fmPos, Quaternion.identity) as GameObject;
		fm.GetComponent<FamilyMember> ().ToggleSexMarking ("F");

		// ego's father's siblings
		Vector2 fbPos = new Vector2(f.transform.position.x + (spacingX * 2f), f.transform.position.y);
		GameObject fb = GameObject.Instantiate (member, fbPos, Quaternion.identity) as GameObject;
		fb.GetComponent<FamilyMember> ().ToggleSexMarking ("M");
		Vector2 fzPos = new Vector2(f.transform.position.x + (spacingX * 4f), f.transform.position.y);
		GameObject fz = GameObject.Instantiate (member, fzPos, Quaternion.identity) as GameObject;
		fz.GetComponent<FamilyMember> ().ToggleSexMarking ("F");

		// ego's mother's siblings
		Vector2 mbPos = new Vector2(m.transform.position.x - (spacingX * 4f), m.transform.position.y);
		GameObject mb = GameObject.Instantiate (member, mbPos, Quaternion.identity) as GameObject;
		mb.GetComponent<FamilyMember> ().ToggleSexMarking ("M");
		Vector2 mzPos = new Vector2(m.transform.position.x - (spacingX * 2f), m.transform.position.y);
		GameObject mz = GameObject.Instantiate (member, mzPos, Quaternion.identity) as GameObject;
		mz.GetComponent<FamilyMember> ().ToggleSexMarking ("F");

		// ego's father's siblings' children
		Vector2 mbsPos = new Vector2(mb.transform.position.x - (spacingX * 0.5f), mb.transform.position.y - spacingY);
		GameObject mbs = GameObject.Instantiate (member, mbsPos, Quaternion.identity) as GameObject;
		mbs.GetComponent<FamilyMember> ().ToggleSexMarking ("M");
		Vector2 mbdPos = new Vector2(mb.transform.position.x + (spacingX * 0.5f), mb.transform.position.y - spacingY);
		GameObject mbd = GameObject.Instantiate (member, mbdPos, Quaternion.identity) as GameObject;
		mbd.GetComponent<FamilyMember> ().ToggleSexMarking ("F");
		Vector2 mzsPos = new Vector2(mz.transform.position.x - (spacingX * 0.5f), mz.transform.position.y - spacingY);
		GameObject mzs = GameObject.Instantiate (member, mzsPos, Quaternion.identity) as GameObject;
		mzs.GetComponent<FamilyMember> ().ToggleSexMarking ("M");
		Vector2 mzdPos = new Vector2(mz.transform.position.x + (spacingX * 0.5f), mz.transform.position.y - spacingY);
		GameObject mzd = GameObject.Instantiate (member, mzdPos, Quaternion.identity) as GameObject;
		mzd.GetComponent<FamilyMember> ().ToggleSexMarking ("F");

		// ego's mother's siblings' children
		Vector2 fbsPos = new Vector2(fb.transform.position.x - (spacingX * 0.5f), fb.transform.position.y - spacingY);
		GameObject fbs = GameObject.Instantiate (member, fbsPos, Quaternion.identity) as GameObject;
		fbs.GetComponent<FamilyMember> ().ToggleSexMarking ("M");
		Vector2 fbdPos = new Vector2(fb.transform.position.x + (spacingX * 0.5f), fb.transform.position.y - spacingY);
		GameObject fbd = GameObject.Instantiate (member, fbdPos, Quaternion.identity) as GameObject;
		fbd.GetComponent<FamilyMember> ().ToggleSexMarking ("F");
		Vector2 fzsPos = new Vector2(fz.transform.position.x - (spacingX * 0.5f), fz.transform.position.y - spacingY);
		GameObject fzs = GameObject.Instantiate (member, fzsPos, Quaternion.identity) as GameObject;
		fzs.GetComponent<FamilyMember> ().ToggleSexMarking ("M");
		Vector2 fzdPos = new Vector2(fz.transform.position.x + (spacingX * 0.5f), fz.transform.position.y - spacingY);
		GameObject fzd = GameObject.Instantiate (member, fzdPos, Quaternion.identity) as GameObject;
		fzd.GetComponent<FamilyMember> ().ToggleSexMarking ("F");

		Dictionary<string, GameObject> familyMembers = new Dictionary<string, GameObject> ();
		familyMembers.Add ("ego", ego);
		familyMembers.Add ("b", b);
		familyMembers.Add ("z", z);
		familyMembers.Add ("f", f);
		familyMembers.Add ("m", m);
		familyMembers.Add ("mm", mm);
		familyMembers.Add ("mf", mf);
		familyMembers.Add ("ff", ff);
		familyMembers.Add ("fm", fm);
		familyMembers.Add ("mb", mb);
		familyMembers.Add ("mz", mz);
		familyMembers.Add ("fb", fb);
		familyMembers.Add ("fz", fz);
		familyMembers.Add ("mbs", mbs);
		familyMembers.Add ("mbd", mbd);
		familyMembers.Add ("mzs", mzs);
		familyMembers.Add ("mzd", mzd);
		familyMembers.Add ("fbs", fbs);
		familyMembers.Add ("fbd", fbd);
		familyMembers.Add ("fzs", fzs);
		familyMembers.Add ("fzd", fzd);
		return familyMembers;
	}

}
