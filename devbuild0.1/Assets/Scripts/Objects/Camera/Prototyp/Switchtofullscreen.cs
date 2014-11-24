using UnityEngine;
using System.Collections;

public class Switchtofullscreen : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
	void OnMouseUp()
	{
		Screen.fullScreen = !Screen.fullScreen;
	}
}
