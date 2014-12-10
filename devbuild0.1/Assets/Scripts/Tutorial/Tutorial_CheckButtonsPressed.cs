using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tutorial_CheckButtonsPressed : MonoBehaviour {


	GameObject[] Popups;

	public int iStage = 1;
	public bool bWin=false;

	public bool Panelout=false;

	public bool MouseMoved=false;
	public bool Pathogen=false;
	public bool Antigene=false;
	public bool Fress = false;
	public bool Eat = false;
	public bool Wrong = false;
	public bool Change = false;
	public bool Markier = false;

	bool timer = false;

	float fTimerstart;
	public float fTimerlength = 45;

	Vector3 Mouseposition;

	// Use this for initialization
	void Start () 
	{
		Popups = GameObject.FindGameObjectsWithTag("GUI_Educational");
		Mouseposition=Input.mousePosition;
	}
	// Update is called once per frame
	void Update () 
	{
		GameObject[] Pathogens = GameObject.FindGameObjectsWithTag("Pathogen") as GameObject[];
		if(Pathogens.Length==0&&!bWin)
		{
			iStage=4;
			bWin=true;
		}
		if(!Panelout)
		{
			if(Mouseposition!=Input.mousePosition&&!MouseMoved&&iStage==1)
			{
				Panelout=true;
				Invoke("NextPanel",3);
			}
			if(Antigene&&iStage==2)
			{
				Panelout=true;
				Invoke("NextPanel",3);
			}
			if(Fress&&iStage==3)
			{
				Panelout=true;
				Invoke("NextPanel",3);
			}
			if(Eat&&iStage==4)
			{
				Panelout=true;
				Invoke("NextPanel",3);
			}
			if(Change&&iStage==5)
			{
				Panelout=true;
				Invoke("NextPanel",3);
			}
			if(iStage==6&&Input.GetKeyDown(KeyCode.F)&&!Markier)
			{
				Panelout=true;
				Invoke("NextPanel",3);
			}
			if (iStage ==4)
			{
				if(bWin)
				{
					GameObject.Find("Canvas_Ingame_GUI_Tut").GetComponent<Canvas>().enabled=false;
					GameObject.Find("Canvas_Comic_Sieg").GetComponent<Canvas>().enabled=true;
					GameObject.Find("Navigational_Helper").GetComponent<Button_LevelAccessControl>().Levelfinished(Application.loadedLevel+1);
					iStage=0;
				}
				Sieg();
			}
		}
	}
	public void StartTimer ()
	{
		timer=true;
		fTimerstart= Time.time;
	}
	public void setStage(int iStage)
	{
		this.iStage=iStage;
	}
	public void NextPanel ()
	{
		foreach (GameObject Popup in Popups)
		{
			if(Popup.name=="Panel_Steuerung"&&iStage==1)
			{
				Popup.GetComponent<Animator>().SetTrigger("Out");
				MouseMoved=true;
			}
			if(Popup.name=="Panel_Antigenspawner"&&iStage==2)
			{
				Popup.GetComponent<Animator>().SetTrigger("Out");
				Fress=true;
			}
			if(Popup.name=="Panel_Fresszelle"&&iStage==3)
			{
				Popup.GetComponent<Animator>().SetTrigger("Out");
			}
			if(Popup.name=="Panel_WrongAntigene"&&iStage==4&&Wrong)
			{
					Popup.GetComponent<Animator>().SetTrigger("Out");
					Eat=false;
					iStage--;
			}
			if(Popup.name=="Panel_RightAntigene"&&iStage==4&&!Wrong)
			{
				Popup.GetComponent<Animator>().SetTrigger("Out");
				Change=true;
			}
			if(Popup.name=="Panel_Wechsel"&&iStage==5)
			{
				Popup.GetComponent<Animator>().SetTrigger("Out");
			}
			if(Popup.name=="Panel_Markierzelle"&&iStage==6)
			{
				Popup.GetComponent<Animator>().SetTrigger("Out");
				Markier=true;
			}
		}
		iStage++;
		CancelInvoke();
	}
	void Freeze ()
	{
		timer = false;
		Time.timeScale=0;

	}
	public void Unfreeze()
	{
		Time.timeScale=1;
		Camera.main.GetComponent<Camera_Follow>().Follow(GameObject.Find("Play_Fress"));
	}
	public void Sieg ()
	{
		GameObject[] Pathogens = GameObject.FindGameObjectsWithTag("Pathogen") as GameObject[];
		if(Pathogens.Length==0&&!bWin) bWin = true;
	}
	void lockButtons ()
	{
		GameObject[] Items = GameObject.FindGameObjectsWithTag("GUI_Items");
		foreach(GameObject Item in Items)
		{
			Item.GetComponent<Button>().interactable=false;
		}
		Camera.main.GetComponent<Powers_Items>().setItemsEnabled(false);
	}
}
