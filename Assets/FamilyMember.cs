using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamilyMember : MonoBehaviour {

	public string label = "";
	public int labelLineLength = 7;
	public TextMesh displayText;
	public string sexMarking; 		// "F" or "M" reference for sex-marked terms in systems that use them
	public string ageMarking; 		// "OLDER" or "YOUNGER" reference for relative age-marked terms in systems that use them

	bool reshape = false;
	Color color;
	bool recolor = false;
	Animator anim;
	Material primaryMaterial;
	RaycastHit hit;

	void Start () {
		this.anim = this.GetComponent<Animator> ();
		this.primaryMaterial = this.GetComponent<MeshRenderer> ().material;
	}

	void Update() {
		if (Input.GetKeyUp (KeyCode.A)) {
			if (this.anim.GetBool ("changeShape")) {
				this.anim.SetBool ("changeShape", false);
			} else {
				this.anim.SetBool ("changeShape", true);
			}
		}
		if (this.recolor) {
			if (this.primaryMaterial.color != this.color) {
				this.primaryMaterial.color = Color.Lerp (this.primaryMaterial.color, this.color, Time.deltaTime);
			} else {
				this.recolor = false;
			}
		}

		if (Input.GetButtonDown ("Fire1")) {
			if (Physics.Raycast (Camera.main.ScreenPointToRay(Input.mousePosition), out hit)) {
				if (hit.collider.gameObject.tag == "Node") {
					Debug.Log (hit.collider.transform.gameObject.name);
					hit.collider.gameObject.GetComponent <FamilyMember> ().ToggleSexMarking();
				}
			}
		}
	}

	public void ToggleSexMarking () {
		if (this.anim.GetBool ("changeShape")) {
			this.sexMarking = "M";
			this.anim.SetBool ("changeShape", false);
		} else {
			this.sexMarking = "F";
			this.anim.SetBool ("changeShape", true);
		}
	}

	public void SetColor (Color color) {
		this.color = color;
	}

	public void SetLabel (string label) {
		this.label = label;

		// TODO color text based on background

		StartCoroutine ("RandomizeRelabeling");

		// TODO split and wrap display text at whitespace or char count limit
	}

	IEnumerator RandomizeRelabeling () {
		this.displayText.text = "";
		yield return new WaitForSeconds (Random.Range(5f, 50f) * Time.deltaTime);
		string[] labelWords = this.label.Split ();
		string formattedLabel = "";
		int currentLineLength = 0;
		foreach (string word in labelWords) {
			// add either space or newline before all but first word
			if (formattedLabel != "") {
				if ((currentLineLength + word.Length) > labelLineLength) {
					formattedLabel += "\n";
					currentLineLength = 0;
				} else {
					formattedLabel += " ";
				}
			}
			formattedLabel += word;
			currentLineLength += word.Length;
		}
		this.displayText.text = formattedLabel;
		this.recolor = true;
		yield return null;
	}

}
