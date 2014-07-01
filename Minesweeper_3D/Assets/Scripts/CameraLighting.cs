using UnityEngine;
using System.Collections;

public class CameraLighting : MonoBehaviour {

	public Light minimapLighting;
	public Light flashlight;
	public Light charAmbientLight;

	void OnPreRender () {
		flashlight.enabled = false;
		charAmbientLight.enabled = false;
	}

	void OnPostRender () {
		minimapLighting.enabled = true;
	}
}
