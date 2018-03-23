using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodesManager : MonoBehaviour {

	// world member node objects
	Dictionary<string, GameObject> family;

	// sample data
	Dictionary<string, string> testTerms = new Dictionary<string, string> ();

	// map for relating same terms to same colors
	Dictionary<string, Color> assignedColors;
	List<Color> colors;

	void Awake () {
		// fill test data
		testTerms.Add ("ego", "you");
		testTerms.Add ("b", "brother");
		testTerms.Add ("z", "sister");
		testTerms.Add ("f", "father");
		testTerms.Add ("m", "mother");
		testTerms.Add ("mb", "uncle");
		testTerms.Add ("mz", "aunt");
		testTerms.Add ("fb", "uncle");
		testTerms.Add ("fz", "aunt");
		testTerms.Add ("mf", "grandfather");
		testTerms.Add ("mm", "grandmother");
		testTerms.Add ("ff", "grandfather");
		testTerms.Add ("fm", "grandmother");
		testTerms.Add ("fbs", "cousin");
		testTerms.Add ("fbd", "cousin");
		testTerms.Add ("fzs", "cousin");
		testTerms.Add ("fzd", "cousin");
		testTerms.Add ("mbs", "cousin");
		testTerms.Add ("mbd", "cousin");
		testTerms.Add ("mzs", "cousin");
		testTerms.Add ("mzd", "cousin");
	}

	public void SetFamily (Dictionary<string, GameObject> family) {
		this.family = family;

		foreach (KeyValuePair<string, GameObject> entry in family) {
			if (this.testTerms.ContainsKey (entry.Key)) {
				Debug.Log (this.testTerms [entry.Key]);
				this.LabelFamilyMembers (this.testTerms);
				//entry.Value.GetComponent <FamilyMember> ().SetLabel (this.testTerms [entry.Key]);
			}
		}
	}

	void LabelFamilyMembers (Dictionary <string, string> labels) {
		// track used colors for same labels
		this.assignedColors = new Dictionary<string, Color> ();

		// all possible colors
		this.colors = new List<Color> () { Color.white };
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

		FamilyMember currentMember;
		string currentLabel;
		Color newColor;

		// label and color family members
		foreach (KeyValuePair<string, GameObject> entry in this.family) {
			Debug.Log (entry.Key);
			currentMember = entry.Value.GetComponent<FamilyMember> ();
			currentLabel = labels [entry.Key];
			currentMember.SetLabel (currentLabel);
			// give same colors to same terms
			if (this.assignedColors.ContainsKey (currentLabel)) {
				newColor = this.assignedColors [currentLabel];
			} else {
				newColor = this.colors [0];
				this.colors.RemoveAt (0);
				this.assignedColors.Add (currentLabel, newColor);
			}
			currentMember.SetColor (newColor);
		}
	}

	public void AddFamilyMember (string primaryCompoundName, GameObject member) {
		this.family.Add (primaryCompoundName, member);
	}

}
