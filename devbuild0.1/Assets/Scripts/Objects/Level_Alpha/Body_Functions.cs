using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Body_Functions : MonoBehaviour 
{
	public int iRest;
	public float fHealthDarm=100;
	public float fHealthHerz=100;
	public float fHealthLunge=100;
	bool GameEnded = false;
	public bool healthy = true;

	string sCauseofDeath="";

	public Slider Herz;
	public Slider Darm;
	public Slider Lunge;

	public float fTickSpeed;
	float fLastTick;

	float fLastPopup;
	float fPopuptimer=20;

	void Start()
	{
		fLastTick=Time.time;
		fLastPopup=Time.time;
	}

	void Update()
	{
		if(healthy)RestBody();
		Herz.value=fHealthHerz/100;
		Darm.value=fHealthDarm/100;
		Lunge.value=fHealthLunge/100;

		if(fHealthHerz<=0) 
		{
			sCauseofDeath="Timmy musste aufgrund von Herzkreislaufproblemen ins Krankenhaus.";
			EndGame();
		}
		if(fHealthDarm<=0)
		{
			sCauseofDeath="Wegen starken Durchfalls und Darmproblemen musste Timmy ins Krankenhaus";
			EndGame();
		}
		if(fHealthLunge<=0)
		{
			sCauseofDeath="Das Atmen fiel Timmy so schwer das er ins Krankenhaus musste";
			EndGame();
		}
		if(Time.time>fLastPopup+fPopuptimer&&(fHealthHerz<=50||fHealthLunge<=50||fHealthDarm<=50))
		{
			GameObject.Find("Panel_Healthbars_Niedirg").GetComponent<Animator>().SetTrigger("Out");
			Camera.main.GetComponent<Tutorial_CheckButtonsPressed>().Panelout=true;
			GameObject.FindGameObjectWithTag("GUI_LowHpIndicator").GetComponent<Image>().enabled=true;
			fLastPopup = Time.time;
		}
		if(fHealthHerz>=50&&fHealthLunge>=50&&fHealthDarm>=50)
		{
			GameObject.FindGameObjectWithTag("GUI_LowHpIndicator").GetComponent<Image>().enabled=false;
		}
	}

	private void RestBody ()
	{
		if(Time.time > fLastTick+fTickSpeed)
		{
			if(fHealthDarm<100&&fHealthDarm>0)fHealthDarm+=iRest;
			if(fHealthHerz<100&&fHealthHerz>0)fHealthHerz+=iRest;
			if(fHealthLunge<100&&fHealthLunge>0)fHealthLunge+=iRest;
			fLastTick=Time.time;
		}
	}
	private void EndGame ()
	{
		if(!GameEnded)
		{
			GameObject.Find("Canvas_Comic_Niedrlage").GetComponent<Canvas>().enabled=true;
			GameObject.Find("Text_Fail").GetComponent<Text>().text=sCauseofDeath;
			GameObject.Find("Canvas_Ingame_GUI_Tut").GetComponent<Canvas>().enabled=false;
			GameEnded=true;
		}
	}
}
