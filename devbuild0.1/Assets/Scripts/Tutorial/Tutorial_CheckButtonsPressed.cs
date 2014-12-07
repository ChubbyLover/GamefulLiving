using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tutorial_CheckButtonsPressed : MonoBehaviour {


	public GameObject TPStage1;
	public GameObject TPStage2;
	public GameObject TPStage3;

	public int iStage = 1;

	public bool Up = false;
	public bool Down = false;
	public bool Left = false;
	public bool Right = false;

	public bool Switch = false;
	public bool Shot=false;

	public bool Antigene= false;
	public bool Pathogen = false;

	public bool bWin=false;

	bool timer = false;

	float fTimerstart;
	public float fTimerlength = 45;



	// Use this for initialization
	void Start () 
	{

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
		if(iStage ==1)
		{
			if(timer)
			{
				if((Up&&Right&&Down&&Left) || Time.time > fTimerstart+fTimerlength )
				{
					Invoke("NextPanel",3);
					timer = false;
				}
				if(Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.UpArrow)) 		Up=true;
				if(Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.DownArrow))	Down=true;
				if(Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.LeftArrow)) 	Left=true;
				if(Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow))	Right=true;
			}

		}
		if(iStage ==2)
		{
			if(timer)
			{
				if((Switch&&Shot) || Time.time > fTimerstart+fTimerlength )
				{
					Invoke("Show",3);
					timer = false;
				}
				if(Input.GetKey(KeyCode.F))			Switch=true;
				if(Input.GetMouseButtonDown(0))	Shot=true;
			}
			else
			{
				if(Input.GetMouseButtonDown(0)) NextPanel();
			}
			
		}
		if(iStage ==3)
		{
			if(timer)
			{
				if((Antigene&&Pathogen) || Time.time > fTimerstart+fTimerlength )
				{
					Invoke("NextPanel",3);
					timer = false;
				}
			}			
		}
		if (iStage ==4)
		{
			if(bWin)
			{
				GameObject.Find("Canvas_Ingame_GUI_Tut").GetComponent<Canvas>().enabled=false;
				GameObject.Find("Canvas_Comic_Sieg").GetComponent<Canvas>().enabled=true;
				iStage=0;
			}
			Sieg();
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
		GameObject TargetPanel=TPStage1;
		if(iStage==1) TargetPanel = TPStage1;
		if(iStage==2) TargetPanel = TPStage2;
		if(iStage==3) TargetPanel = TPStage3;
		TargetPanel.SetActive(true);
		GameObject[] Buttons = GameObject.FindGameObjectsWithTag("GUI_Menu") as GameObject[];
		
		foreach(GameObject buton in Buttons)
		{
			buton.GetComponent<Button>().interactable=false;
		}
		Camera.main.GetComponent<Camera_Follow>().FreezeUnfreeze();
		CancelInvoke();
	}
	public void Show ()
	{
		Invoke("Freeze",1);
		Camera.main.GetComponent<Camera_Follow>().Follow(GameObject.FindGameObjectWithTag("Pathogen"));
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
}
