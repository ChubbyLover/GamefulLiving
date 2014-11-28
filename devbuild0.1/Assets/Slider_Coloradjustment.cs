using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Slider_Coloradjustment : MonoBehaviour {

	public Slider Targetslider;
	public GameObject Targetcomponent;
	private Image img;

	// Use this for initialization
	void Start () {
		img = Targetcomponent.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		img.color= new Color(2.5f*(1-Targetslider.value),2.5f*Targetslider.value,0);
	}
}
