using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamilyMember : MonoBehaviour {

	bool reshape = false;
	Color color;
	Animator anim;

	void Start () {
		anim = this.GetComponent<Animator> ();
		// test initialize with a random color
		Color[] colors = new Color[]{ Color.red, Color.black, Color.blue, Color.cyan, Color.white, Color.green, Color.gray, Color.yellow, Color.magenta };
		color = colors[Random.Range(0, colors.Length)];
		this.GetComponent<MeshRenderer> ().material.color = color;
	}

	void Update() {
		if (Input.GetKeyUp (KeyCode.A)) {
			if (anim.GetBool ("changeShape")) {
				anim.SetBool ("changeShape", false);
			} else {
				anim.SetBool ("changeShape", true);
			}
		}
	}
}
