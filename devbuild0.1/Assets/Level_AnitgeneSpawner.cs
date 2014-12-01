using UnityEngine;
using System.Collections;

public class Level_AnitgeneSpawner : MonoBehaviour {

	public float Tickspeed=1;
	float LastTick;

	// Use this for initialization
	void Start () 
	{
		LastTick=Time.time;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Time.time>LastTick+Tickspeed)
		{
			GameObject Anitgene = Instantiate (Resources.Load("Prefabs/Objects/Player/Antigene/Antigene"),transform.position, transform.rotation) as GameObject;
			Anitgene.GetComponent<Level_Anitgene>().TimeStamp=Time.time;
			LastTick=Time.time;
		}
	}
}
