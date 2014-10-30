using UnityEngine;
using System.Collections;

public class control : MonoBehaviour {

	public float fSizeCompensator=5.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.UpArrow))
		{
			rigidbody2D.AddForce(Vector2.up*fSizeCompensator);	
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			rigidbody2D.AddForce(Vector2.up*-1.0f*fSizeCompensator);
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			rigidbody2D.AddForce(Vector2.right*-1.0f*fSizeCompensator);	
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			rigidbody2D.AddForce(Vector2.right*fSizeCompensator);	
		}
	}
}
