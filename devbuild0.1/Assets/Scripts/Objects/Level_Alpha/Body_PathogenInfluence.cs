using UnityEngine;
using System.Collections;

public class Body_PathogenInfluence : MonoBehaviour {


	Body_Functions Body;
	public int iPathogens=0;
	bool isEmpty=true;
	// Use this for initialization
	void Start () 
	{
		Body = GameObject.FindGameObjectWithTag("Body").GetComponent<Body_Functions>();
	}
	void FixedUpdate()
	{
		isEmpty = true;
	}
	// Update is called once per frame
	void Update () 
	{
		if(isEmpty) Body.healthy=true;
	}
	void OnTriggerStay2D(Collider2D col) 
	{
		if(col.gameObject.tag=="Pathogen")
		{
			if(gameObject.name=="Herz") Body.fHealthHerz-=1f*col.gameObject.GetComponent<Pathogen_Behaviour>().fHeart;
			if(gameObject.name=="Lunge") Body.fHealthLunge-=1*col.gameObject.GetComponent<Pathogen_Behaviour>().fLungs;
			if(gameObject.name=="Darm") Body.fHealthDarm-=1*col.gameObject.GetComponent<Pathogen_Behaviour>().fDarm;
			Body.healthy=false;
			isEmpty = false;
		}
	}
}
