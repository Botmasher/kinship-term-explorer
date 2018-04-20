using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebGLManager : MonoBehaviour {

	public bool captureAllPageInput = false;

	void Start () {
		// Set web player to grab all events when mouse is over it (true)
		// or allow other page events like scrolling (false)
		#if !UNITY_EDITOR && (UNITY_WEBGL || UNITY_WEBPLAYER)
		
			WebGLInput.captureAllKeyboardInput = captureAllPageInput;
		
		#endif
	}

}
