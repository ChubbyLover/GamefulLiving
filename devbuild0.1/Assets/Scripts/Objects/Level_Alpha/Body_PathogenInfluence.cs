using UnityEngine;
using System.Collections;

public class Body_PathogenInfluence : MonoBehaviour {


	Body_Functions Body;
	public int iPathogens=0;
	public bool isEmpty=true;
	// Use this for initialization
	void Start () 
	{
		Body = GameObject.FindGameObjectWithTag("Body").GetComponent<Body_Functions>();
	}
	void FixedUpdate()
	{
		if(gameObject.name=="Herz") Body.HerzHealthy=true;
		if(gameObject.name=="Lunge") Body.LungeHealthy=true;
		if(gameObject.name=="Darm") Body.DarmHealthy=true;
	}
	// Update is called once per frame
	void Update () 
	{
		if(isEmpty)
		{
			if(gameObject.name=="Herz") Body.HerzHealthy=true;
			if(gameObject.name=="Lunge") Body.LungeHealthy=true;
			if(gameObject.name=="Darm") Body.DarmHealthy=true;
		}
	}
	void OnTriggerStay2D(Collider2D col) 
	{
		if(col.gameObject.tag=="Pathogen"||col.gameObject.tag=="Marked")
		{
			if(gameObject.name=="Herz")
			{
				Body.fHealthHerz-=1f*col.gameObject.GetComponent<Pathogen_Behaviour>().fHeart;
				Body.HerzHealthy=false;
			}
			if(gameObject.name=="Lunge")
			{
				Body.fHealthLunge-=1f*col.gameObject.GetComponent<Pathogen_Behaviour>().fLungs;
				Body.LungeHealthy=false;
			}
			if(gameObject.name=="Darm")
			{
				Body.fHealthDarm-=1f*col.gameObject.GetComponent<Pathogen_Behaviour>().fDarm;
				Body.DarmHealthy=false;
			}
			isEmpty = false;
		}
	}
}
