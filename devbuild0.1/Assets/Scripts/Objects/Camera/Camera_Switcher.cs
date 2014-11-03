using UnityEngine;
using System.Collections;

public class Camera_Switcher : MonoBehaviour {
	
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
		Cameras = GameObject.FindGameObjectsWithTag("Camera");

		foreach (GameObject camera in Cameras)
		{
			camera.GetComponent<Camera>().enabled=false;
			camera.GetComponent<AudioListener>().enabled=false;
		}
	}
	public void EnableCamera(string sAdd)
	{
		DisableAllCameras();

		string sCamera = "Camera"+sAdd;
		if(GameObject.Find(sCamera)!=null)
		{
			Debug.Log(sCamera);
			GameObject.Find(sCamera).GetComponent<Camera>().enabled = true;
			GameObject.Find(sCamera).GetComponent<AudioListener>().enabled = true;
		}
	}
}
