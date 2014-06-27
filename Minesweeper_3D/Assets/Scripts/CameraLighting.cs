using UnityEngine;
using System.Collections;

public class CameraLighting : MonoBehaviour {

	public Light minimapLighting;
	public Light flashlight;

	void OnPreRender () {
		flashlight.enabled = false;
	}

	void OnPostRender () {
		minimapLighting.enabled = true;
	}
}
