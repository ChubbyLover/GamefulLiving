using UnityEngine;
using System.Collections;

public class Reset : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (gameObject.transform.position.y <=-81)
		{
			Vector3 vect = new Vector3(-70,60,0);
			gameObject.transform.position=vect;
		}
	}
}
