using UnityEngine;
using System.Collections;

public class Change_Cursor : MonoBehaviour {

	public Texture2D CursorIMGHover;
	public Texture2D CursorIMGNormal;
	public Texture2D CursorIMGClick;
	bool bCursorChanged=false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void ChangeButton()
	{
		if(!bCursorChanged)
		{
			Cursor.SetCursor(CursorIMGHover,Vector2.zero,CursorMode.Auto);
			bCursorChanged=true;
		}

		else
		{
			Cursor.SetCursor(CursorIMGNormal,Vector2.zero,CursorMode.Auto);
			bCursorChanged=false;
		}
	}
	public void CursorHover()
	{
		Cursor.SetCursor(CursorIMGHover,Vector2.zero,CursorMode.Auto);
	}
	public void CrusorClick()
	{
		Cursor.SetCursor(CursorIMGClick,Vector2.zero,CursorMode.Auto);
	}
	public void Cursorleave()
	{
		Cursor.SetCursor(CursorIMGNormal,Vector2.zero,CursorMode.Auto);
	}
}