using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button_GraphicSwitcher : MonoBehaviour {

	public Sprite Play;
	public Sprite Pause;

	public GameObject PanelMenu;

	bool bPressed=false;

	public bool bPause=true;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyUp(KeyCode.P))
		{
			if(!bPressed)
			{
				SwitchGraphics();
				Camera.main.GetComponent<Camera_Follow>().FreezeUnfreeze();
				PanelMenu.SetActive(true);
				gameObject.GetComponent<Button>().interactable=false;
				bPressed=true;
			}
			else
			{
				SwitchGraphics();
				Camera.main.GetComponent<Camera_Follow>().FreezeUnfreeze();
				PanelMenu.SetActive(false);
				gameObject.GetComponent<Button>().interactable=true;
				bPressed=false;
			}
		}

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
