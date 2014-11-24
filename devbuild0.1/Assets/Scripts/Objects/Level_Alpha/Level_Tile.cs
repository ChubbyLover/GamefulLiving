using UnityEngine;
using System.Collections;

public class Level_Tile : MonoBehaviour 
{
	public int iX;
	public int iY;

	GameObject[] Neighbours;
	// Use this for initialization
	void Start () 
	{
		Neighbours= new GameObject[8];

		Neighbours[0] = GameObject.Find("Tile"+(iX-1).ToString()+(iY-1).ToString());
		Neighbours[1] = GameObject.Find("Tile"+(iX).ToString()+(iY-1).ToString());
		Neighbours[2] = GameObject.Find("Tile"+(iX+1).ToString()+(iY-1).ToString());
		Neighbours[3] = GameObject.Find("Tile"+(iX-1).ToString()+(iY).ToString());
		Neighbours[4] = GameObject.Find("Tile"+(iX+1).ToString()+(iY).ToString());
		Neighbours[5] = GameObject.Find("Tile"+(iX-1).ToString()+(iY+1).ToString());
		Neighbours[6] = GameObject.Find("Tile"+(iX).ToString()+(iY+1).ToString());
		Neighbours[7] = GameObject.Find("Tile"+(iX+1).ToString()+(iY+1).ToString());
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
	public void Activate()
	{
		renderer.enabled=true;
		for(int i=0; i<Neighbours.Length; i++)
		{
			if(Neighbours[i]!=null&&!Neighbours[i].renderer.enabled) Neighbours[i].renderer.enabled=true;
		}
	}
	public void Deactivate()
	{
		renderer.enabled=false;
		for(int i=0; i<Neighbours.Length; i++)
		{
			if(Neighbours[i]!=null&&Neighbours[i].renderer.enabled) Neighbours[i].renderer.enabled=false;
		}
	}
}
