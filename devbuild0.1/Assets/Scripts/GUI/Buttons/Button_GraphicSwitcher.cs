using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button_GraphicSwitcher : MonoBehaviour {

	public Sprite Play;
	public Sprite Pause;

	public bool bPause=true;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	public void SwitchGraphics()
	{
		if(bPause)
		{
			GetComponent<Image>().sprite=Play;
			bPause=false;
		}
		else
		{
			GetComponent<Image>().sprite=Pause;
			bPause=true;
		}
	}
}
