using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {

	private int buttonWidth = 200;
	private int buttonHeight = 50;

	// Use this for initialization
	void Start () {
	
	}
	
	void OnGUI() {
		if (GUI.Button (new Rect (280, 400, buttonWidth, buttonHeight), "Back to Mainmenu")) {
			Application.LoadLevel("Main_Menu");
		}
	}
}
