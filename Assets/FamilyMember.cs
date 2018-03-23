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
		// test initialize with a random color
		//Color[] colors = new Color[]{ Color.red, Color.black, Color.blue, Color.cyan, Color.white, Color.green, Color.gray, Color.yellow, Color.magenta };
		//color = colors[Random.Range(0, colors.Length)];
		//this.GetComponent<MeshRenderer> ().material.color = color;
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
		this.recolor = true;
	}

	public void SetLabel (string label) {
		this.label = label;
		this.displayText.text = label;
		// TODO split and wrap display text at whitespace or char count limit
	}
}
