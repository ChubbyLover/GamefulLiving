using UnityEngine;
using System.Collections;

public class Tutorial_Fresszelle : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Pathogen" || collision.gameObject.tag == "Marked")
		{	
				Camera.main.GetComponent<Tutorial_CheckButtonsPressed>().Antigene =true;
		}
	}
}
