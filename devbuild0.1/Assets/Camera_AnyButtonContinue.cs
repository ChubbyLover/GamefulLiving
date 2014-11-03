using UnityEngine;
using System.Collections;

public class Camera_AnyButtonContinue : MonoBehaviour {


	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.anyKeyDown)
		{
			GameObject.Find("GoCamSwitcher").GetComponent<Camera_Switcher>().EnableCamera("1.1");
			this.enabled=false;
		}
	}
}
