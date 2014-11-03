using UnityEngine;
using System.Collections;

public class Camera_Switcher : MonoBehaviour {

	public string sCamera;
	GameObject[] Cameras;

	// Use this for initialization
	void Start () 
	{
		Cameras = GameObject.FindGameObjectsWithTag("Camera");
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	private void DisableAllCameras()
	{
		Cameras = Cameras = GameObject.FindGameObjectsWithTag("Camera");

		foreach (GameObject camera in Cameras)
		{
			camera.GetComponent<Camera>().enabled=false;
		}
	}
	public void EnableCamera(string sAdd)
	{
		DisableAllCameras();

		string sCamera = "Camera"+sAdd;
		if(GameObject.Find(sCamera)!=null)
		{
			GameObject.Find(sCamera).GetComponent<Camera>().enabled = true;
		}
	}
}
