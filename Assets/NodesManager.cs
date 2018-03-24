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
	RootObject labelsData;
	[System.Serializable]
	public class CompoundTerm {
//		public object this[string propertyName] {
//			get{                  
//				PropertyInfo propInfo = typeof(CompoundTerm).GetProperty(propertyName);
//				return propInfo.GetValue(this, null);
//			}
//			set{                  
//				PropertyInfo propInfo = typeof(CompoundTerm).GetProperty(propertyName);
//				propInfo.SetValue(this, value, null);
//			}
//		}
		public string English;
		public string Japanese;
	}
	[System.Serializable]
	public class RootObject {
//		public object this[string propertyName] {
//			get{                  
//				PropertyInfo propertyInfo = typeof(RootObject).GetProperty(propertyName);
//				return propertyInfo.GetValue(this, null);
//			}
//			set{                  
//				PropertyInfo propertyInfo = typeof(RootObject).GetProperty(propertyName);
//				propertyInfo.SetValue(this, value, null);
//			}
//		}
		public CompoundTerm M;
		public CompoundTerm F;
		public CompoundTerm Z;
		public CompoundTerm B;
		public CompoundTerm MB;
		public CompoundTerm MZ;
		public CompoundTerm FB;
		public CompoundTerm FZ;
		public CompoundTerm MF;
		public CompoundTerm MM;
		public CompoundTerm FF;
		public CompoundTerm FM;
		public CompoundTerm FBS;
		public CompoundTerm FBD;
		public CompoundTerm FZS;
		public CompoundTerm FZD;
		public CompoundTerm MBS;
		public CompoundTerm MBD;
		public CompoundTerm MZS;
		public CompoundTerm MZD;
	}

	// map for relating same terms to same colors
	Dictionary<string, Color> assignedColors;
	List<Color> colors;

	void Start () {
		// fill test data
//		testTerms.Add ("ego", "you");
//		testTerms.Add ("b", "brother");
//		testTerms.Add ("z", "sister");
//		testTerms.Add ("f", "father");
//		testTerms.Add ("m", "mother");
//		testTerms.Add ("mb", "uncle");
//		testTerms.Add ("mz", "aunt");
//		testTerms.Add ("fb", "uncle");
//		testTerms.Add ("fz", "aunt");
//		testTerms.Add ("mf", "grandfather");
//		testTerms.Add ("mm", "grandmother");
//		testTerms.Add ("ff", "grandfather");
//		testTerms.Add ("fm", "grandmother");
//		testTerms.Add ("fbs", "cousin");
//		testTerms.Add ("fbd", "cousin");
//		testTerms.Add ("fzs", "cousin");
//		testTerms.Add ("fzd", "cousin");
//		testTerms.Add ("mbs", "cousin");
//		testTerms.Add ("mbd", "cousin");
//		testTerms.Add ("mzs", "cousin");
//		testTerms.Add ("mzd", "cousin");

		// sample JSON deserialization
		string path = Path.Combine("_data", "test");
		TextAsset jsonFile = Resources.Load<TextAsset> (path); 	// 	./Assets/Resources/_data/test.json
		this.labelsData = JsonUtility.FromJson <RootObject> (jsonFile.text);

		Debug.Log(labelsData.Z.English);
		Debug.Log(labelsData.B.English);

		// test using SimpleJSON instead
		var parsedJSONForBracketing = JSON.Parse(jsonFile.text);
		Debug.Log (parsedJSONForBracketing["M"]["English"].Value);

	}

	public void SetFamily (Dictionary<string, GameObject> family) {
		this.family = family;

		foreach (KeyValuePair<string, GameObject> entry in family) {
			if (this.testTerms.ContainsKey (entry.Key)) {
				//Debug.Log (this.testTerms [entry.Key]);
				this.LabelFamilyMembers(); // (this.testTerms);
				//entry.Value.GetComponent <FamilyMember> ().SetLabel (this.testTerms [entry.Key]);
			}
		}
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.D)) {
			this.LabelFamilyMembers();
		}
	}

	void LabelFamilyMembers () { // (Dictionary <string, string> labels) {
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

			//var currentTerm = labelsData["M"] as RootObject;
			//currentLabel = currentTerm[currentLanguage];

			//CompoundTerm currentTerm = typeof(RootObject).GetProperty("M").GetValue(labelsData, null) as CompoundTerm;

			currentLabel = labelsData.M.English;
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
