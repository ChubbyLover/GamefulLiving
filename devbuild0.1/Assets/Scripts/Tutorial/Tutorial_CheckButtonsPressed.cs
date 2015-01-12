using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tutorial_CheckButtonsPressed : MonoBehaviour 
{


	GameObject[] Popups;
	Canvas IngameUI;
	Canvas Sieg;
	Button_LevelAccessControl Navigation;

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

	public int iLevel=6;
	
	public int iTimeuntilPopup;

	float fTimerstart;
	public float fTimerlength = 45;

	Vector3 Mouseposition;
	AudioSource Asrc;
	AudioSource AsrcMusic;
	float fLowerMusiclevel=0.4f;

	// Use this for initialization
	void Start () 
	{
		IngameUI= GameObject.Find("Canvas_Ingame_GUI_Tut").GetComponent<Canvas>();
		Sieg = GameObject.Find("Canvas_Comic_Sieg").GetComponent<Canvas>();
		Navigation = GameObject.Find("Navigational_Helper").GetComponent<Button_LevelAccessControl>();

		Popups = GameObject.FindGameObjectsWithTag("GUI_Educational");
		Mouseposition=Input.mousePosition;

		if(Application.loadedLevelName=="Level_Tutorial_1")  iLevel=0;
		if(Application.loadedLevelName=="Level_Tutorial_2")  iLevel=1;
		if(Application.loadedLevelName=="Level_Tutorial_3")  iLevel=2;
		if(Application.loadedLevelName=="Level_Tutorial_4")  iLevel=3;
		if(Application.loadedLevelName=="Level_Tutorial_5")  iLevel=4;
		
		if(Application.loadedLevelName!="Level_endless") {
			InvokeRepeating("CheckForPathogens", 0f,0.5f);
		}
			
		Asrc = GameObject.FindGameObjectWithTag("Audio_Sprecher").GetComponent<AudioSource>();
		AsrcMusic= GameObject.FindGameObjectWithTag("Audio_Music").GetComponent<AudioSource>();;
	}
	// Update is called once per frame
	void Update () 
	{
		if(bWin&&iStage==0)
		{
			IngameUI.enabled=false;
			Sieg.enabled=true;
			Navigation.Levelfinished(Application.loadedLevel);
			Navigation.bUpdated=false;
			Asrc.Stop();
			Time.timeScale=0;
			iStage=1337;
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
				if(Fress&&iStage==2)
				{
					Panelout=true;
					Invoke("NextPanel",iTimeuntilPopup);
				}
				if(iStage==3&&!Bodymap)
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
				if(Mouseposition!=Input.mousePosition&&!MouseMoved&&iStage==1)
				{
					Panelout=true;
					Invoke("NextPanel",iTimeuntilPopup);

				}
				if(iStage==2&&Healthbar)
				{
					Panelout=true;
					Invoke("NextPanel",iTimeuntilPopup);
				}
				
			}
		}
		if(iLevel==2)
		{
			if(!Panelout)
			{
				if(iStage==1&&Mouseposition!=Input.mousePosition&&!MouseMoved)
				{
					Panelout=true;
					Invoke("NextPanel",iTimeuntilPopup);
				}
				if(iStage==2&&Neutrophile)
				{
					Panelout=true;
					Invoke("NextPanel",iTimeuntilPopup);
				}
			}
		}
		if(iLevel==3)
		{
			if(!Panelout)
			{
				if(Antigene&&iStage==1)
				{
					Panelout=true;
					Invoke("NextPanel",0);
				}
				if(!Change&&iStage==2)
				{
					Panelout=true;
					Invoke("NextPanel",iTimeuntilPopup);
				}
			}
		}
		if(iLevel==4)
		{
			if(!Panelout)
			{
				if(iStage==1&&Mouseposition!=Input.mousePosition&&!MouseMoved)
				{
					Panelout=true;
					Invoke("NextPanel",iTimeuntilPopup);
				}
				if(iStage==2&&Item[0])
				{
					Panelout=true;
					Invoke("NextPanel",iTimeuntilPopup);
				}
				if(iStage==3&Item[1])
				{
					Panelout=true;
					Invoke("NextPanel",iTimeuntilPopup);
				}
				if(iStage==4&&Item[2])
				{
					Panelout=true;
					Invoke("NextPanel",iTimeuntilPopup);
				}
				if(iStage==5&&Item[3])
				{
					Panelout=true;
					Invoke("NextPanel",iTimeuntilPopup);
				}
			}
		}
	}

	public void setStage(int iStage)
	{
		this.iStage=iStage;
	}
	public void CheckForPathogens()

	{
		GameObject[] Pathogens = GameObject.FindGameObjectsWithTag("Pathogen") as GameObject[];
		GameObject[] PathogensMarked = GameObject.FindGameObjectsWithTag("Marked") as GameObject[];
		if(Pathogens.Length==0&&PathogensMarked.Length==0&&!bWin)
		{
			iStage=0;
			bWin=true;
		}
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
					Asrc.clip = Resources.Load("Sounds/Sprecher/Ingame/Steuerung/Steuerung") as AudioClip;
					Asrc.Play();
					AsrcMusic.volume=fLowerMusiclevel;
					MouseMoved=true;
					Fress=true;
				}
				if(Popup.name=="Panel_Fresszelle"&&iStage==2)
				{
					Popup.GetComponent<Animator>().SetTrigger("Out");
					Asrc.clip = Resources.Load("Sounds/Sprecher/Ingame/Fresszelle/Fresszelle") as AudioClip;
					Asrc.Play();
					AsrcMusic.volume=fLowerMusiclevel;
				}
				if(Popup.name=="Panel_Bodymap"&&iStage==3)
				{
					Popup.GetComponent<Animator>().SetTrigger("Out");
					Asrc.clip = Resources.Load("Sounds/Sprecher/Ingame/Map/Map") as AudioClip;
					Asrc.Play();
					AsrcMusic.volume=fLowerMusiclevel;
					Bodymap=true;
					Healthbar=true;
				}
			}
			if(iLevel==1)
			{
				if(Popup.name=="Panel_Steuerung"&&iStage==1)
				{
					Popup.GetComponent<Animator>().SetTrigger("Out");
					Asrc.clip = Resources.Load("Sounds/Sprecher/Ingame/Steuerung/Steuerung") as AudioClip;
					Asrc.Play();
					AsrcMusic.volume=fLowerMusiclevel;
					MouseMoved=true;
					Healthbar=true;
				}
				if(Popup.name=="Panel_Healthbars"&&iStage==2)
				{
					Popup.GetComponent<Animator>().SetTrigger("Out");
					Asrc.clip = Resources.Load("Sounds/Sprecher/Ingame/Healthbar/Healthbar") as AudioClip;
					Asrc.Play();
					AsrcMusic.volume=fLowerMusiclevel;
				}
			}
			if(iLevel==2)
			{
				if(Popup.name=="Panel_Markierzelle"&&iStage==1)
				{
					Popup.GetComponent<Animator>().SetTrigger("Out");
					Asrc.clip = Resources.Load("Sounds/Sprecher/Ingame/Markiererzelle/Markiererzelle") as AudioClip;
					Asrc.Play();
					AsrcMusic.volume=fLowerMusiclevel;
					MouseMoved=true;
					Neutrophile=true;
				}
				if(Popup.name=="Panel_Neutrophile"&&iStage==2)
				{
					Popup.GetComponent<Animator>().SetTrigger("Out");
					Asrc.clip = Resources.Load("Sounds/Sprecher/Ingame/Neutrophile/Neutrophile") as AudioClip;
					Asrc.Play();
					AsrcMusic.volume=fLowerMusiclevel;
				}
			}
			if(iLevel==3)
			{
				if(Popup.name=="Panel_Antigenspawner"&&iStage==1)
				{
					Popup.GetComponent<Animator>().SetTrigger("Out");
					Asrc.clip = Resources.Load("Sounds/Sprecher/Ingame/Antigene/Antigene") as AudioClip;
					Asrc.Play();
					AsrcMusic.volume=fLowerMusiclevel;
					MouseMoved=true;
				}
				if(Popup.name=="Panel_Wechsel"&&iStage==2)
				{
					Popup.GetComponent<Animator>().SetTrigger("Out");
					Asrc.clip = Resources.Load("Sounds/Sprecher/Ingame/Wechsel/Wechsel") as AudioClip;
					Asrc.Play();
					AsrcMusic.volume=fLowerMusiclevel;
					Change =true;
				}

			}
			if(iLevel==4)
			{
				if(Popup.name=="Panel_Items"&&iStage==1)
				{
					Popup.GetComponent<Animator>().SetTrigger("Out");
					Asrc.clip = Resources.Load("Sounds/Sprecher/Ingame/Items/Items") as AudioClip;
					Asrc.Play();
					AsrcMusic.volume=fLowerMusiclevel;
					MouseMoved= true;
					Item[0] = true;
				}
				if(Popup.name=="Panel_Pille"&&iStage==2)
				{
					Popup.GetComponent<Animator>().SetTrigger("Out");
					Asrc.clip = Resources.Load("Sounds/Sprecher/Ingame/Pille/Pille") as AudioClip;
					Asrc.Play();
					AsrcMusic.volume=fLowerMusiclevel;
					Item[1] = true;
				}
				if(Popup.name=="Panel_Wasser"&&iStage==3)
				{
					Popup.GetComponent<Animator>().SetTrigger("Out");
					Asrc.clip = Resources.Load("Sounds/Sprecher/Ingame/Wasser/Wasser") as AudioClip;
					Asrc.Play();
					AsrcMusic.volume=fLowerMusiclevel;
					Item[2] = true;
				}
				if(Popup.name=="Panel_Fieber"&&iStage==4)
				{
					Popup.GetComponent<Animator>().SetTrigger("Out");
					Asrc.clip = Resources.Load("Sounds/Sprecher/Ingame/Fieber/Fieber") as AudioClip;
					Asrc.Play();
					AsrcMusic.volume=fLowerMusiclevel;
					Item[3] = true;
				}
				if(Popup.name=="Panel_Obst"&&iStage==5)
				{
					Popup.GetComponent<Animator>().SetTrigger("Out");
					Asrc.clip = Resources.Load("Sounds/Sprecher/Ingame/Obst/Obst") as AudioClip;
					Asrc.Play();
					AsrcMusic.volume=fLowerMusiclevel;
				}	
			}
		}
		iStage++;
		CancelInvoke();
		if(Application.loadedLevelName!="Level_endless") {InvokeRepeating("CheckForPathogens", 0f,0.5f);}
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
