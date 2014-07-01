using UnityEngine;
using System.Collections;

public class MinimapLighting : MonoBehaviour {

	public Light minimapLighting;
	public Light flashlight;
	public Light charAmbientLight;
	
	void OnPreRender () {
		minimapLighting.enabled = false;
	}
	
	void OnPostRender () {
		flashlight.enabled = true;
		charAmbientLight.enabled = true;
	}
}
