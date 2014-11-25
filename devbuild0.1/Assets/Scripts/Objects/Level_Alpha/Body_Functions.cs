using UnityEngine;
using System.Collections;

public class Body_Functions : MonoBehaviour 
{
	public int iRest=1;
	public float fHealthDarm=100;
	public float fHealthHerz=100;
	public float fHealthLunge=100;

	public float fTickSpeed=1;
	float fLastTick;

	void Start()
	{
		fLastTick=Time.time;
	}

	void Update()
	{
		RestBody();
	}

	private void RestBody ()
	{
		if(Time.time > fLastTick+fTickSpeed)
		{
			if(fHealthDarm<100)fHealthDarm+=iRest;
			if(fHealthHerz<100)fHealthHerz+=iRest;
			if(fHealthLunge<100)fHealthLunge+=iRest;
		}
	}
}
