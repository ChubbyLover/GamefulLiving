using UnityEngine;
using System.Collections;

public class FollowObject : MonoBehaviour 
{
	public GameObject Go;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 vect   = new Vector3(Go.transform.position.x,Go.transform.position.y,gameObject.transform.position.z);
		this.transform.position = vect;
	}
}
