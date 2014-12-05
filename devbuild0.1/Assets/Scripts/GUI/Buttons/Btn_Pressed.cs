using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;


public class Btn_Pressed : MonoBehaviour 
{
	public string skey;
	Button targetButton;
	
	// Use this for initialization
	void Start () 
	{
		targetButton = gameObject.GetComponent<Button>();
	}

	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.W)&&skey=="W")Buttonpressed();
		if(Input.GetKeyDown(KeyCode.A)&&skey=="A")Buttonpressed();
		if(Input.GetKeyDown(KeyCode.S)&&skey=="S")Buttonpressed();
		if(Input.GetKeyDown(KeyCode.D)&&skey=="D")Buttonpressed();
		if(Input.GetKeyDown(KeyCode.F)&&skey=="F")Buttonpressed();
		if(Input.GetKeyDown(KeyCode.UpArrow)&&skey=="UP")Buttonpressed();
		if(Input.GetKeyDown(KeyCode.DownArrow)&&skey=="DOWN")Buttonpressed();
		if(Input.GetKeyDown(KeyCode.RightArrow)&&skey=="RIGHT")Buttonpressed();
		if(Input.GetKeyDown(KeyCode.LeftArrow)&&skey=="LEFT")Buttonpressed();
		if(Input.GetKeyDown(KeyCode.Space)&&skey=="SPACE")Buttonpressed();
		if(Input.GetMouseButtonDown(0)&&skey=="MOUSE")Buttonpressed();
	}
	void Buttonpressed ()
	{
		var pointer = new PointerEventData(EventSystem.current); 
		ExecuteEvents.Execute(targetButton.gameObject, pointer, ExecuteEvents.submitHandler);
	}
}
