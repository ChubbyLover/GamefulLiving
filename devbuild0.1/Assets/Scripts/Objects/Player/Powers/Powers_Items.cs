using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Powers_Items : MonoBehaviour {

	Body_Functions functionsBody;

	public Slider Item1;
	public Slider Item2;
	public Slider Item3;
	public Slider Item4;
	
	// Use this for initialization
	void Start () 
	{
		functionsBody = GameObject.FindGameObjectWithTag("Body").GetComponent<Body_Functions>();
		GameObject[] PathogensMarked = GameObject.FindGameObjectsWithTag("Pathogen");
		GameObject[] PathogensUnmarked = GameObject.FindGameObjectsWithTag("Marked");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			Item1.GetComponent<Slider_Timer>().Starttimer(60);
		}
		if(Input.GetKeyDown(KeyCode.Alpha2))
		{
			Item2.GetComponent<Slider_Timer>().Starttimer(60);

		}
		if(Input.GetKeyDown(KeyCode.Alpha3))
		{
			Item3.GetComponent<Slider_Timer>().Starttimer(60);

		}
		if(Input.GetKeyDown(KeyCode.Alpha4))
		{
			Item4.GetComponent<Slider_Timer>().Starttimer(60);
		}
	}
	public void ReduceMitosis(float fPercent)
	{
		GameObject[] PathogensMarked = GameObject.FindGameObjectsWithTag("Pathogen");
		GameObject[] PathogensUnmarked = GameObject.FindGameObjectsWithTag("Marked");

		foreach(GameObject Pathogen in PathogensMarked)
		{
			Pathogen.GetComponent<Pathogen_Behaviour>().timeUntilMitosis+= Pathogen.GetComponent<Pathogen_Behaviour>().timeUntilMitosis*(int)fPercent;
		}
		foreach(GameObject Pathogen in PathogensUnmarked)
		{
			Pathogen.GetComponent<Pathogen_Behaviour>().timeUntilMitosis+= Pathogen.GetComponent<Pathogen_Behaviour>().timeUntilMitosis*(int)fPercent;
		}
	}
	public void Kill(float fPercent)
	{
		GameObject[] PathogensMarked = GameObject.FindGameObjectsWithTag("Pathogen");
		GameObject[] PathogensUnmarked = GameObject.FindGameObjectsWithTag("Marked");

		foreach(GameObject Pathogen in PathogensMarked)
		{
			if(Random.Range(0,100)<fPercent)
			{
				if(Pathogen!=null) Pathogen.GetComponent<Pathogen_Behaviour>().Die();
			}
		}
		foreach(GameObject Pathogen in PathogensUnmarked)
		{
			if(Random.Range(0,100)<fPercent)
			{
				if(Pathogen!=null)Pathogen.GetComponent<Pathogen_Behaviour>().Die();
			}
		}

	}
	public void RestoreBodilyFunctions(float fAmmount, string sArea)
	{
		if(sArea=="All")
		{
			functionsBody.fHealthDarm+= fAmmount;
			functionsBody.fHealthHerz+= fAmmount;
			functionsBody.fHealthLunge+= fAmmount;
		}
		if(sArea=="Darm")
		{
			functionsBody.fHealthDarm+= fAmmount;
		}
		if(sArea=="Herz")
		{
			functionsBody.fHealthHerz+= fAmmount;
		}
		if(sArea=="Lunge")
		{
			functionsBody.fHealthLunge+= fAmmount;
		}
		else
		{
		
		}
	}
	public void EnhanceWhiteHepers (float fAmmount)
	{
		GameObject[] Helpers = GameObject.FindGameObjectsWithTag("Helper");

		foreach(GameObject Helper in Helpers)
		{
			Helper.GetComponent<Powers_HelperAI>().fSpeedMaximum+=fAmmount;
		}
	}
}
