using UnityEngine;
using System.Collections;

public class Camera_SetStart : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		GetComponent<Camera_Switcher>().EnableCamera("10");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
