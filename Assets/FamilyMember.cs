using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamilyMember : MonoBehaviour {

	public TextMesh displayText; 	// mesh for label text
	public Transform displayShape; 	// mesh for animating color and shape
	public string label = "";
	public int labelLineLength = 7;
	public bool isEgo = false;
	bool markingEgo = false;

	// TODO "older" or "younger" reference for relative age-marked terms in systems that use them
	string _AgeMarking;
	public string AgeMarking {
		get { return this._AgeMarking; }
		set { this._AgeMarking = value; }
	}

	// "F" or "M" reference for sex-marked terms in systems that use them
	string _SexMarking = "";
	public string SexMarking {
		get { return this._SexMarking; }
		set {
			this._SexMarking = value;
			// call any subscriber methods listening for change on ego
			if (OnSexMarking != null && this.isEgo) {
				OnSexMarking ();
			}
		}
	}
	// allow listening to change in marking
	public delegate void OnSexMarkingDelegate ();
	public event OnSexMarkingDelegate OnSexMarking;

	Color color;
	bool recolor = false;
	Animator anim;
	Material primaryMaterial;
	RaycastHit hit;

	// store text mesh child rotation to keep it from rotating
	Quaternion fixedDisplayTextRotation;

	void Awake () {
		this.fixedDisplayTextRotation = this.displayText.transform.rotation;
	}

	void Start () {
		this.anim = displayShape.GetComponent<Animator> ();
		this.primaryMaterial = displayShape.GetComponent<MeshRenderer> ().material;
	}

	void Update() {
		if (this.recolor) {
			if (this.primaryMaterial.color != this.color) {
				this.primaryMaterial.color = Color.Lerp (this.primaryMaterial.color, this.color, Time.deltaTime);
			} else {
				this.recolor = false;
			}
		}

		// change ego on click
		if (this.isEgo && Input.GetButtonDown ("Fire1")) {
			if (Physics.Raycast (Camera.main.ScreenPointToRay(Input.mousePosition), out hit)) {
				if (hit.collider.gameObject == this.displayShape.gameObject) {
					this.ToggleSexMarking();
				}
			}
		}

		// change ego every so often
		//if (this.isEgo && !this.markingEgo) {
		//	StartCoroutine ("CycleEgoMarking");
		//}
	}

	// keep text mesh from rotating if parent does
	void LateUpdate() {
		this.displayText.transform.rotation = this.fixedDisplayTextRotation;
	}

	public void ToggleSexMarking (string initialSetting="") {
		// member setting when first loaded
		if (initialSetting != "" && this.SexMarking == "") {
			this.SexMarking = initialSetting;
			if (initialSetting == "M") {
				return;
			}
		}
		// give time for animator to load before changing shape
		StartCoroutine ("WaitThenToggleSexMarking");
	}
	IEnumerator WaitThenToggleSexMarking () {
		yield return new WaitForSeconds (0.1f);
		if (this.anim.GetBool ("changeShape")) {
			this.SexMarking = "M";
			this.anim.SetBool ("changeShape", false);
		} else {
			this.SexMarking = "F";
			this.anim.SetBool ("changeShape", true);
		}
		yield return null;
	}

	IEnumerator CycleEgoMarking () {
		this.markingEgo = true;
		this.ToggleSexMarking ();
		yield return new WaitForSeconds (6f);
		this.markingEgo = false;
	}

	public void SetColor (Color color) {
		this.color = color;
	}

	public void SetLabel (string label) {
		this.label = label;

		// TODO color text based on member color

		StartCoroutine ("RandomizeRelabeling");
	}

	public void LabelAsEgo (string egoName="(you)") {
		this.label = egoName;
		this.displayText.text = egoName;
		this.displayText.color = Color.gray;
		this.displayText.fontStyle = FontStyle.Italic;
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
