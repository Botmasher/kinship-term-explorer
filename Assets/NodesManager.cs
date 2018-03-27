using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using System.IO;
using SimpleJSON;

public class NodesManager : MonoBehaviour {

	// world member node objects
	Dictionary<string, GameObject> family;

	// sample data
	Dictionary<string, string> testTerms = new Dictionary<string, string> ();

	// sample JSON serialization classes - used to test deserialization in Start()
	JSONNode labelsData;

	// map for relating same terms to same colors
	Dictionary<string, Color> assignedColors;
	List<Color> colors;

	void Start () {
		// sample JSON deserialization
		string path = Path.Combine("_data", "test");
		TextAsset jsonFile = Resources.Load<TextAsset> (path); 	// 	./Assets/Resources/_data/test.json
		labelsData = JSON.Parse(jsonFile.text);
	}

	// TEST CALLS to update labels - call from client instead
	void Update() {
		if (Input.GetKeyDown (KeyCode.E)) {
			this.LabelFamilyMembers ("English");
		}
		if (Input.GetKeyDown (KeyCode.P)) {
			this.LabelFamilyMembers ();
		}
	}

	public void SetFamily (Dictionary<string, GameObject> family) {
		this.family = family;
		// delay for JSON to finish parsing
		StartCoroutine ("DelayLabelFamilyWithData");
	}

	IEnumerator DelayLabelFamilyWithData () {
		yield return new WaitForSeconds(0.5f);
		this.LabelFamilyMembers();
		yield return null; 
	}

	public void LabelFamilyMembers (string languageName="Primary") {
		// track used colors for same labels
		this.assignedColors = new Dictionary<string, Color> ();

		// all possible colors
		this.colors = new List<Color> ();
		this.colors.Add (Color.white);
		this.colors.Add (new Color (1.0f, 0.6f, 0.0f)); 	// orange
		this.colors.Add (new Color (1.0f, 0.2f, 0.2f)); 	// light red
		this.colors.Add (Color.yellow);
		this.colors.Add (new Color (0.8f, 0.4f, 0.5f)); 	// muted red with some pink
		this.colors.Add (new Color (0.4f, 0.4f, 0.8f)); 	// purple
		this.colors.Add (new Color (1.0f, 0.4f, 0.7f)); 	// bubblegum
		this.colors.Add (new Color (0.7f, 0.8f, 0.9f)); 	// light bluish purple
		this.colors.Add (new Color (0.7f, 0.5f, 0.9f)); 	// light brown
		this.colors.Add (new Color (1.0f, 1.0f, 0.5f)); 	// light yellow
		this.colors.Add (new Color (0.2f, 0.4f, 1.0f)); 	// light blue with some green
		this.colors.Add (new Color (0.9f, 0.0f, 0.6f)); 	// pink
		this.colors.Add (new Color (0.8f, 1.0f, 0.3f)); 	// dull lime
		this.colors.Add (new Color (0.8f, 0.4f, 0.3f)); 	// brick meets young plumb
		this.colors.Add (new Color (0.6f, 0.2f, 0.9f)); 	// light purple
		this.colors.Add (new Color (1.0f, 0.8f, 0.6f)); 	// orange tan
		this.colors.Add (new Color (0.7f, 0.4f, 0.3f)); 	// brown
		this.colors.Add (new Color (1.0f, 0.7f, 1.0f)); 	// light pink
		this.colors.Add (new Color (0.6f, 1.0f, 0.9f)); 	// light blue
		this.colors.Add (new Color (0.0f, 1.0f, 0.2f)); 	// 
		this.colors.Add (new Color (0.6f, 0.8f, 0.1f)); 	// 
		this.colors.Add (new Color (0.5f, 0.3f, 0.9f)); 	// 
		this.colors.Add (new Color (0.9f, 0.0f, 0.3f)); 	// 

		FamilyMember currentMember;
		string currentLabel;
		Color newColor;

		// label and color family members
		foreach (KeyValuePair<string, GameObject> entry in this.family) {

			currentMember = entry.Value.GetComponent<FamilyMember> ();

			currentLabel = labelsData[entry.Key.ToUpper()][languageName].Value;

			if (currentLabel.Contains("_OLDER") || currentLabel.Contains("_YOUNGER")) {
				if (currentMember.ageMarking != "") {
					// check age marking and assign older or younger terms to the correct member
				}
			}

			if (currentLabel.Contains("_F") || currentLabel.Contains("_M")) {
				if (currentMember.sexMarking != "") {
					// check sex marking and assign m or f terms to the correct member
				}
			}

			// TODO handle cross-marked terms in Hawaiian type

			// ELSE no age marking or sex marking
			currentMember.SetLabel (currentLabel);

			// give same colors to same terms
			if (this.assignedColors.ContainsKey (currentLabel)) {
				newColor = this.assignedColors [currentLabel];
			} else {
				newColor = this.colors[0];
				this.colors.RemoveAt (0);
				this.assignedColors.Add (currentLabel, newColor);
			}
			currentMember.SetColor (newColor);
		}
	}

	void AddFamilyMember (string primaryCompoundName, GameObject member) {
		this.family.Add (primaryCompoundName, member);
	}

}
