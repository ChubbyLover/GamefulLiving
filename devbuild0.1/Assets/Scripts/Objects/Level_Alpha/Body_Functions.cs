using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Body_Functions : MonoBehaviour 
{
	public int iRest=1;
	public float fHealthDarm=100;
	public float fHealthHerz=100;
	public float fHealthLunge=100;

	public Slider Herz;
	public Slider Darm;
	public Slider Lunge;

	public float fTickSpeed;
	float fLastTick;

	void Start()
	{
		fLastTick=Time.time;
	}

	void Update()
	{
		RestBody();
		Herz.value=fHealthHerz/100;
		Darm.value=fHealthDarm/100;
		Lunge.value=fHealthLunge/100;
	}

	private void RestBody ()
	{
		if(Time.time > fLastTick+fTickSpeed)
		{
			if(fHealthDarm<100&&fHealthDarm<0)fHealthDarm+=iRest;
			if(fHealthHerz<100&&fHealthHerz<0)fHealthHerz+=iRest;
			if(fHealthLunge<100&&fHealthLunge<0)fHealthLunge+=iRest;
			fLastTick=Time.time;
		}
	}
}
