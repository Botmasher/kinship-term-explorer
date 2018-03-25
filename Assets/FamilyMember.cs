using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamilyMember : MonoBehaviour {

	public string label = "";
	public TextMesh displayText;

	bool reshape = false;
	Color color;
	bool recolor = false;
	Animator anim;
	Material primaryMaterial;

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
		this.displayText.text = this.label;
		this.recolor = true;
		yield return null;
	}

}
