using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Slider_Timer : MonoBehaviour {

	public Slider TargetSlider;
	public Button TargetButton;
	
	bool StartTimer=false;
	float fLastTime;
	float fTimer=0.3f;
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
				TargetButton.interactable=false;
				if(gameObject.name=="Slider_Item1")
				{
					if(TargetSlider.value<=TargetSlider.maxValue/2)
					{
						Camera.main.GetComponent<Powers_Items>().Kill(50/TargetSlider.maxValue);
						Camera.main.GetComponent<Powers_Items>().DamageBodilyFunctions(60/TargetSlider.maxValue,"Herz");
						Camera.main.GetComponent<Powers_Items>().DamageBodilyFunctions(120/TargetSlider.maxValue,"Darm");
					}
					if(TargetSlider.value==1)GameObject.FindGameObjectWithTag("GUI_Pill").GetComponent<Animator>().SetTrigger("Used");
				}
				if(gameObject.name=="Slider_Item2")
				{

					if(TargetSlider.value<=TargetSlider.maxValue/2)
					{
						Camera.main.GetComponent<Powers_Items>().RestoreBodilyFunctions(50/TargetSlider.maxValue,"All");
						GameObject[] Bars = GameObject.FindGameObjectsWithTag("GUI_Healthbar");

						foreach (GameObject Bar in Bars)
						{
							Bar.GetComponent<Animator>().SetTrigger("Pulse");
						}
					}
				}
				if(gameObject.name=="Slider_Item3")
				{
					if(TargetSlider.value<=TargetSlider.maxValue/2)
					{
						Camera.main.GetComponent<Powers_Items>().ReduceMitosis(50/TargetSlider.maxValue);
						Camera.main.GetComponent<Powers_Items>().DamageBodilyFunctions(35/TargetSlider.maxValue,"Herz");
					}
				}
				if(gameObject.name=="Slider_Item4")
				{
					if(TargetSlider.value<=TargetSlider.maxValue/2)
					{
						Camera.main.GetComponent<Powers_Items>().EnhanceWhiteHepers(50/TargetSlider.maxValue);
						GameObject[] Helpers = GameObject.FindGameObjectsWithTag("Helper");
				
						foreach(GameObject Helper in Helpers)
						{
							Helper.GetComponent<Powers_HelperAI>().PoweredUp=true;
						}
					}
				}
			}
			else
			{
				TargetButton.interactable=true;
				StartTimer=false;
			}
		}
	}
	public void Starttimer(float fLength)
	{
		if(!StartTimer)
		{
			TargetSlider.value=0;
			TargetSlider.maxValue=fLength*Application.targetFrameRate;
			StartTimer=true;
			fLastTime=Time.time;
		}
	}

}
