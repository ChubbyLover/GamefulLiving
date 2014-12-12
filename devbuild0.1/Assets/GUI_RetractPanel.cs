using UnityEngine;
using System.Collections;

public class GUI_RetractPanel : MonoBehaviour {

	public float time;
	public bool bStart=false;
	private bool bIgnore=false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(bStart&&!bIgnore)
		{
			Invoke("Retract",time);
			bIgnore=true;
		}
	}
	void Retract ()
	{
		bStart=false;
		GetComponent<Animator>().SetTrigger("In");
		Invoke("EnabelNewPanel",2);
	}
	void EnabelNewPanel()
	{
		Camera.main.GetComponent<Tutorial_CheckButtonsPressed>().Panelout=false;
		bStart=false;
	}
}
