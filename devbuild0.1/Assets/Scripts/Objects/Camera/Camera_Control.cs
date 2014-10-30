using UnityEngine;
using System.Collections;

public class Camera_Control : MonoBehaviour {

	public float fCompensator=20;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Transform temp = transform;
		if (Input.GetKey(KeyCode.W))
		{
			temp.position += (transform.up*fCompensator);	
		}
		if (Input.GetKey(KeyCode.S))
		{
			temp.position += (transform.up*-1.0f*fCompensator);
		}
		if (Input.GetKey(KeyCode.A))
		{
			temp.position += (transform.right*-1.0f*fCompensator);	
		}
		if (Input.GetKey(KeyCode.D))
		{
			temp.position += (transform.right*fCompensator);	
		}
		
	}
}
