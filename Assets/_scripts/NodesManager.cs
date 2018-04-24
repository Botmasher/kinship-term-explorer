using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using System.IO;
using SimpleJSON;

public class NodesManager : MonoBehaviour {

	// world member node objects
	Dictionary<string, GameObject> family;

	Dictionary<string, string> labels = new Dictionary<string, string> ();

	// parsed JSON data mapping kin types to terms (labels in languages)
	JSONNode labelsData;

	// map for relating same terms to same colors
	Dictionary<string, Color> assignedColors;
	List<Color> colors;

	public void SetFamily (Dictionary<string, GameObject> family) {
		this.family = family;
		this.family ["ego"].GetComponent<FamilyMember> ().isEgo = true;
		// sub and listen for changes in ego marking
		this.family ["ego"].GetComponent<FamilyMember> ().OnSexMarking += NodeChangeHandler;
		// delay labeling so JSON can finish parsing first
		StartCoroutine ("DelayLabelFamilyWithData");
	}

	// TODO use labels
	public bool SetMemberLabel (string[] typeTermPair) {
		if (typeTermPair.Length != 2 || !labels.ContainsKey(typeTermPair[0])) {
			return false;
		}
		string type = typeTermPair [0];
		string term = typeTermPair [1];
		this.labels [type] = term;
		return true;
	}

	// initially wait for loaded data and all instantiated members
	IEnumerator DelayLabelFamilyWithData () {
		yield return new WaitForSeconds(0.5f);
		this.LabelFamilyMembers();
		yield return null; 
	}

	// handle relabeling based on node state (principally ego) changes
	private void NodeChangeHandler () {
		this.LabelFamilyMembers ();
	}

	public void LabelFamilyMembers () {

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

		// storage for labeling and coloring members
		FamilyMember currentMember;
		string currentLabel;
		JSONNode currentData;
		Color newColor;

		// label and color family members
		foreach (KeyValuePair<string, GameObject> entry in this.family) {

			currentMember = entry.Value.GetComponent<FamilyMember> ();

			currentData = this.labels [entry.Key];

			// set terms marked relative to ego if they exist in this language
			// principally to correctly display cross-marked terms in Hawaiian type
			if (currentData ["M"] != null && currentData ["F"] != null) {
				currentLabel = currentData[this.family["ego"].GetComponent<FamilyMember>().SexMarking].Value;
			} else {
				// set all other labels
				currentLabel = currentData.Value;
			}

			// TODO handle older vs younger same-generation marking
			if (currentLabel.Contains("_OLDER") || currentLabel.Contains("_YOUNGER")) {
				if (currentMember.AgeMarking != "") {
					// check age marking and assign older or younger terms to the correct member
				}
			}

			// give same colors to same-termed members
			if (this.assignedColors.ContainsKey (currentLabel)) {
				newColor = this.assignedColors [currentLabel];
			} else {
				newColor = this.colors[0];
				this.colors.RemoveAt (0);
				this.assignedColors.Add (currentLabel, newColor);
			}
			currentMember.SetColor (newColor);

			// give text to family member
			if (currentMember.isEgo) {
				currentMember.LabelAsEgo ();
			} else {
				currentMember.SetLabel (currentLabel);
			}

		}
	}

	void AddFamilyMember (string primaryCompoundName, GameObject member) {
		this.family.Add (primaryCompoundName, member);
	}

}
