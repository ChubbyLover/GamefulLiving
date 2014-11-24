using UnityEngine;
using System.Collections;

public class Camera_Proceed : MonoBehaviour {
	
	public GameObject Player;
	public Camera miniMap;
	
	// Use this for initialization
	void Start () {
		Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseDown()
	{
		Camera.main.GetComponent<Camera_Follow>().Follow(Player);
		if(Player.name == "Play_AntibodyCannon" || Player.name == "Play_Fress") {
			
			Time.timeScale = 1;
			miniMap.enabled = true;
		}
		if(Player.name=="Screen2")
		{
			Application.LoadLevel(3);
		}
	}
}
