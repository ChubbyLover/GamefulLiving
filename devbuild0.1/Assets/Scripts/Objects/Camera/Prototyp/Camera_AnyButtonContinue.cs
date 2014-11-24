using UnityEngine;
using System.Collections;

public class Camera_AnyButtonContinue : MonoBehaviour {

	public string sDestination;
	public string CurrentCamera;
	
	GameObject[] CurrentCameras;
	// Use this for initialization
	void Start () 
	{
		CurrentCameras = GameObject.FindGameObjectsWithTag("Camera");
	}
	
	// Update is called once per frame
	void Update () 
	{
		foreach(GameObject Camerar in CurrentCameras)
		{
			if(Camerar.GetComponent<Camera>().enabled)
			{
				CurrentCamera = Camerar.name;
				break;
			}
		}
		if(Input.anyKeyDown&&gameObject.GetComponent<Canvas>().worldCamera.camera.name == CurrentCamera)
		{
			Debug.Log(gameObject.name);
			Debug.Log(gameObject.GetComponent<Canvas>().worldCamera.camera.name);
				if(sDestination!="Prototyp_Leve11")
				{
					GameObject.Find("GoCamSwitcher").GetComponent<Camera_Switcher>().EnableCamera(sDestination);
				}
				else
				{
					Application.LoadLevel(1);
				}
			//Timer=Time.time;
		}
	}
}

