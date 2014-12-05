using UnityEngine;
using System.Collections;

public class Tutorial_Anitgene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(GetComponent<SpriteRenderer>().sprite!=null) Camera.main.GetComponent<Tutorial_CheckButtonsPressed>().Antigene=true;
	}
}
