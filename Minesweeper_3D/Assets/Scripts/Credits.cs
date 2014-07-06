using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {

	private int buttonWidth = 200;
	private int buttonHeight = 50;

	// Use this for initialization
	void Start () {
	
	}
	
	void OnGUI() {
		if (GUI.Button (new Rect ((Screen.width / 2) - (buttonWidth / 2), (Screen.height / 2) + 100 , buttonWidth, buttonHeight), "Back to Mainmenu")) {
			Application.LoadLevel("Main_Menu");
		}
	}
}
