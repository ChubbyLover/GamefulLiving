using UnityEngine;
using System.Collections;

public class lookAround : MonoBehaviour {
	
	public Camera minimapCamera;
	public Transform mover;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if ( Input.GetMouseButtonDown(0)){
			mover.position = minimapCamera.ScreenToWorldPoint(Input.mousePosition);
			if(mover.position.x>0&&mover.position.x<90&&mover.position.y>0&&mover.position.y<290)Camera.main.GetComponent<Camera_Follow>().startFreeLook(mover);
		}
		if ( Input.GetMouseButton(0)){
			Vector2 goal = minimapCamera.ScreenToWorldPoint(Input.mousePosition);
			mover.position = goal;
		}
		if ( Input.GetMouseButtonUp(0)){
			Camera.main.GetComponent<Camera_Follow>().endFreeLook();
		}
		
	}
}
