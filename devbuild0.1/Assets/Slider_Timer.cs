using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Slider_Timer : MonoBehaviour {

	public Slider TargetSlider;
	public Button TargetButton;

	bool StartTimer=false;
	float fLastTime;
	float fTimer=0.1f;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(StartTimer&&Time.time>fLastTime+fTimer)
		{
			if(TargetSlider.value!=TargetSlider.maxValue)
			{
				TargetSlider.value+=1;
				fLastTime=Time.time;
			}
			else
			{
				TargetButton.interactable=true;	
			}
		}
	}
	public void Starttimer(float fLength)
	{
		TargetSlider.value=0;
		TargetSlider.maxValue=fLength;
		StartTimer=true;
		fLastTime=Time.time;
	}

}
