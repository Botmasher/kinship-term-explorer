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

	void LabelFamilyMembers () {
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
		string currentLanguage = "English";
		string currentLabel;
		Color newColor;

		// label and color family members
		foreach (KeyValuePair<string, GameObject> entry in this.family) {
			currentMember = entry.Value.GetComponent<FamilyMember> ();
			currentLabel = labelsData[entry.Key.ToUpper()][currentLanguage].Value;
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
