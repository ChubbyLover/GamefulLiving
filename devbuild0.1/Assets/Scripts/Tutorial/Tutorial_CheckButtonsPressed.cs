using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tutorial_CheckButtonsPressed : MonoBehaviour 
{


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
	public bool Neutrophile = false;
	public bool Bodymap = false;
	public bool Healthbar = false;
	public bool Items = false;
	public bool[] Item = new bool[4];

	public int iLevel=0;
	
	public int iTimeuntilPopup;

	float fTimerstart;
	public float fTimerlength = 45;

	Vector3 Mouseposition;
	AudioSource Asrc;

	// Use this for initialization
	void Start () 
	{
		Popups = GameObject.FindGameObjectsWithTag("GUI_Educational");
		Mouseposition=Input.mousePosition;

		if(Application.loadedLevelName=="Level_Tutorial")  iLevel=0;
		if(Application.loadedLevelName=="Level_Scharlach") iLevel=1;

		Asrc = GameObject.FindGameObjectWithTag("Audio_Sprecher").GetComponent<AudioSource>();

	}
	// Update is called once per frame
	void Update () 
	{
		GameObject[] Pathogens = GameObject.FindGameObjectsWithTag("Pathogen") as GameObject[];
		if(Pathogens.Length==0&&!bWin)
		{
			iStage=0;
			bWin=true;
		}

		if(iLevel==0)
		{
			if(!Panelout)
			{
				if(Mouseposition!=Input.mousePosition&&!MouseMoved&&iStage==1)
				{
					Panelout=true;
					Invoke("NextPanel",iTimeuntilPopup);
				}
				if(Antigene&&iStage==2)
				{
					Panelout=true;
					Invoke("NextPanel",iTimeuntilPopup);
				}
				if(Fress&&iStage==3)
				{
					Panelout=true;
					Invoke("NextPanel",iTimeuntilPopup);
				}
				if(Eat&&iStage==4)
				{
					Panelout=true;
					Invoke("NextPanel",iTimeuntilPopup);
				}
				if(Change&&iStage==5)
				{
					Panelout=true;
					Invoke("NextPanel",iTimeuntilPopup);
				}
				if(iStage==6&&Input.GetKeyDown(KeyCode.F)&&Markier)
				{
					Panelout=true;
					Invoke("NextPanel",iTimeuntilPopup);
				}
				if(iStage==7&&Neutrophile)
				{
					Panelout=true;
					Invoke("NextPanel",iTimeuntilPopup);
				}
			}
		}
		if(iLevel==1)
		{
			if(!Panelout)
			{
				if(iStage==1&&!Bodymap)
				{
					Panelout=true;
					Invoke("NextPanel",iTimeuntilPopup);
				}
				if(iStage==2&&Healthbar)
				{
					Panelout=true;
					Invoke("NextPanel",iTimeuntilPopup);
				}
				if(iStage==3&&Items)
				{
					Panelout=true;
					Invoke("NextPanel",iTimeuntilPopup);
				}
				if(iStage==4&&Item[0])
				{
					Panelout=true;
					Invoke("NextPanel",iTimeuntilPopup);
				}
				if(iStage==5&&Item[1])
				{
					Panelout=true;
					Invoke("NextPanel",iTimeuntilPopup);
				}
				if(iStage==6&&Item[2])
				{
					Panelout=true;
					Invoke("NextPanel",iTimeuntilPopup);
				}
				if(iStage==7&&Item[3])
				{
					Panelout=true;
					Invoke("NextPanel",iTimeuntilPopup);
				}
			}
		}

			if (iStage ==0)
			{
				if(bWin)
				{
					GameObject.Find("Canvas_Ingame_GUI_Tut").GetComponent<Canvas>().enabled=false;
					GameObject.Find("Canvas_Comic_Sieg").GetComponent<Canvas>().enabled=true;
					GameObject.Find("Navigational_Helper").GetComponent<Button_LevelAccessControl>().Levelfinished(Application.loadedLevel);
					GameObject.Find("Navigational_Helper").GetComponent<Button_LevelAccessControl>().bUpdated=false;
					iStage=1337;
				}
				Sieg();
			}
	}

	public void setStage(int iStage)
	{
		this.iStage=iStage;
	}
	public void NextPanel ()
	{
		foreach (GameObject Popup in Popups)
		{
			if(iLevel==0)
			{
				if(Popup.name=="Panel_Steuerung"&&iStage==1)
				{
					Popup.GetComponent<Animator>().SetTrigger("Out");
					Asrc.clip = Resources.Load("Sounds/Sprecher/Ingame/Steuerung/Steuerung1") as AudioClip;
					Asrc.Play();
					MouseMoved=true;
				}
				if(Popup.name=="Panel_Antigenspawner"&&iStage==2)
				{
					Popup.GetComponent<Animator>().SetTrigger("Out");
					Asrc.clip = Resources.Load("Sounds/Sprecher/Ingame/Antigene/Antigene") as AudioClip;
					Asrc.Play();
					Fress=true;
				}
				if(Popup.name=="Panel_Fresszelle"&&iStage==3)
				{
					Popup.GetComponent<Animator>().SetTrigger("Out");
					Asrc.clip = Resources.Load("Sounds/Sprecher/Ingame/Fresszelle/Fresszelle") as AudioClip;
					Asrc.Play();
				}
				if(Popup.name=="Panel_WrongAntigene"&&iStage==4&&Wrong)
				{
					Popup.GetComponent<Animator>().SetTrigger("Out");
					Asrc.clip = Resources.Load("Sounds/Sprecher/Ingame/Wrong/Wrong") as AudioClip;
					Asrc.Play();
					Eat=false;
					iStage--;
				}
				if(Popup.name=="Panel_RightAntigene"&&iStage==4&&!Wrong)
				{
					Popup.GetComponent<Animator>().SetTrigger("Out");
					Asrc.clip = Resources.Load("Sounds/Sprecher/Ingame/Right/Right") as AudioClip;
					Asrc.Play();
					Change=true;
				}
				if(Popup.name=="Panel_Wechsel"&&iStage==5)
				{
					Popup.GetComponent<Animator>().SetTrigger("Out");
					Asrc.clip = Resources.Load("Sounds/Sprecher/Ingame/Wechsel/Wechsel") as AudioClip;
					Asrc.Play();
					Markier=true;
				}
				if(Popup.name=="Panel_Markierzelle"&&iStage==6)
				{
					Popup.GetComponent<Animator>().SetTrigger("Out");
					Asrc.clip = Resources.Load("Sounds/Sprecher/Ingame/Markiererzelle/Markiererzelle") as AudioClip;
					Asrc.Play();
					Neutrophile=true;
				}
				if(Popup.name=="Panel_Neutrophile"&&iStage==7)
				{
					Popup.GetComponent<Animator>().SetTrigger("Out");
					Asrc.clip = Resources.Load("Sounds/Sprecher/Ingame/Neutrophile/Neutrophile") as AudioClip;
					Asrc.Play();
				}
			}
			if(iLevel==1)
			{
				if(Popup.name=="Panel_Bodymap"&&iStage==1)
				{
					Popup.GetComponent<Animator>().SetTrigger("Out");
					Asrc.clip = Resources.Load("Sounds/Sprecher/Ingame/Map/Map") as AudioClip;
					Asrc.Play();
					Bodymap=true;
					Healthbar=true;
				}
				if(Popup.name=="Panel_Healthbars"&&iStage==2)
				{
					Popup.GetComponent<Animator>().SetTrigger("Out");
					Asrc.clip = Resources.Load("Sounds/Sprecher/Ingame/Healthbar/Healthbar") as AudioClip;
					Asrc.Play();
					Items = true;
				}
				if(Popup.name=="Panel_Items"&&iStage==3)
				{
					Popup.GetComponent<Animator>().SetTrigger("Out");
					Asrc.clip = Resources.Load("Sounds/Sprecher/Ingame/Items/Items") as AudioClip;
					Asrc.Play();
					Item[0] = true;
				}
				if(Popup.name=="Panel_Pille"&&iStage==4)
				{
					Popup.GetComponent<Animator>().SetTrigger("Out");
					Asrc.clip = Resources.Load("Sounds/Sprecher/Ingame/Pille/Pille") as AudioClip;
					Asrc.Play();
					Item[1] = true;
				}
				if(Popup.name=="Panel_Wasser"&&iStage==5)
				{
					Popup.GetComponent<Animator>().SetTrigger("Out");
					Asrc.clip = Resources.Load("Sounds/Sprecher/Ingame/Wasser/Wasser") as AudioClip;
					Asrc.Play();
					Item[2] = true;
				}
				if(Popup.name=="Panel_Fieber"&&iStage==6)
				{
					Popup.GetComponent<Animator>().SetTrigger("Out");
					Asrc.clip = Resources.Load("Sounds/Sprecher/Ingame/Fieber/Fieber") as AudioClip;
					Asrc.Play();
					Item[3] = true;
				}
				if(Popup.name=="Panel_Obst"&&iStage==7)
				{
					Popup.GetComponent<Animator>().SetTrigger("Out");
					Asrc.clip = Resources.Load("Sounds/Sprecher/Ingame/Obst/Obst") as AudioClip;
					Asrc.Play();
				}	
			}
		}
		iStage++;
		CancelInvoke();
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
