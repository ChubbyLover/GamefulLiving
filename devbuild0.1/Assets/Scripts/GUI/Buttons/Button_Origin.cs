using UnityEngine;
using System.Collections;

public class Button_Origin : MonoBehaviour 
{

	string Origin;

	public void setOrigin(string Origin)
	{
		this.Origin = Origin;
	}
	public void GotoOrigin()
	{
		GameObject.Find(Origin).GetComponent<Canvas>().enabled=true;
		GetComponent<Canvas>().enabled=false;
	}
}
