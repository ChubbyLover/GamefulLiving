using UnityEngine;
using System.Collections;

public class Camera_ChangetoScreen : MonoBehaviour {

	public string sDestination;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	void OnMouseUp()
	{
		if(sDestination!="Exit")
		{
			GameObject.Find("GoCamSwitcher").GetComponent<Camera_Switcher>().EnableCamera(sDestination);
			this.enabled=false;
		}
		else
		{
			Application.Quit();
		}
	}
}
