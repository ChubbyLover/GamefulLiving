using UnityEngine;
using System.Collections;

public class Camera_GUI : MonoBehaviour {



	public Texture2D CursorIMGNormal;
	
	void Start () 
	{
		Cursor.SetCursor(CursorIMGNormal,Vector2.zero,CursorMode.Auto); 
	}
	// Update is called once per frame
	void Update () {
	
	}
	public void ToggleFullscreen()
	{
		if(Screen.fullScreen) Screen.fullScreen=false;
		else Screen.fullScreen=true;
	}
	public void StartGame()
	{
		Application.LoadLevel(1);
	}
	public void EndGame()
	{
		Application.Quit();
	}
}
