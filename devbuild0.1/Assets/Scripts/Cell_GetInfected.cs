using UnityEngine;
using System.Collections;

public class Cell_GetInfected : MonoBehaviour {

	bool Infected=false;
	float fTimer=10;
	float fTimeInfected;

	GameObject Pathogen;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Infected && fTimeInfected+fTimer>Time.time)
		{
			GameObject Clone = Instantiate(Pathogen,transform.position,transform.rotation) as GameObject;
			Destroy(gameObject);
		}
	}
	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.gameObject.tag == "Pathogen")
		{
			Infected=true;
			Pathogen=coll.gameObject;
			gameObject.tag="Pathogen";
			gameObject.renderer.material.color=Color.green;
			fTimeInfected=Time.time;
		}
	}
}
