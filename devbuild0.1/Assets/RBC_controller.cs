using UnityEngine;
using System.Collections;

public class RBC_controller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		InvokeRepeating("CheckDistance", 2, 2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void CheckDistance()
	{
		
		if(Vector2.Distance(transform.position, Camera.main.transform.position)>10) 
		{
			Destroy(gameObject);
		}
		
	}
}
