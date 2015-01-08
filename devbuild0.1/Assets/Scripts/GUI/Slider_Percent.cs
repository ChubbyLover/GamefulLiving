using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class Slider_Percent : MonoBehaviour {

	public Slider Targetslider;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Text text = GetComponent<Text>();
		text.text = Mathf.Round(Targetslider.GetComponent<Slider>().value*100)+"%";
	}
}
