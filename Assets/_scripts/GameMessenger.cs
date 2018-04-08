using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class GameMessenger : MonoBehaviour {

	[DllImport("__Internal")]
	private static extern void SetGameLoaded();

	void Start () {
		StartCoroutine ("SendLoadedMessage");
	}

	IEnumerator SendLoadedMessage () {
		yield return new WaitForSeconds (0.5f);
		SetGameLoaded ();
		yield return null;
	}
}
