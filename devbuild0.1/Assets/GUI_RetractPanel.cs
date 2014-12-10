using UnityEngine;
using System.Collections;

public class GUI_RetractPanel : MonoBehaviour {

	public float time;
	public bool bStart=false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(bStart) Invoke("Retract",time);
	}
	void Retract ()
	{
		bStart=false;
		GetComponent<Animator>().SetTrigger("In");
		Camera.main.GetComponent<Tutorial_CheckButtonsPressed>().Panelout=false;
	}
}
