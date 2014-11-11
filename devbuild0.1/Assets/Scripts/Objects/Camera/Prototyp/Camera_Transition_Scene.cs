using UnityEngine;
using System.Collections;

public class Camera_Transition_Scene : MonoBehaviour {

	public int iNumber;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		iNumber=GameObject.FindGameObjectsWithTag("pathogen11").Length;
		if(iNumber==0)
		{
			Application.LoadLevel(1);
		}
	}
}
