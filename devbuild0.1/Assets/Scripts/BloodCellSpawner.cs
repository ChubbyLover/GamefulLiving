using UnityEngine;
using System.Collections;

public class BloodCellSpawner : MonoBehaviour {

	float fTimer=2;
	float fTimeLastSpawned;
	public float fMaximumSpawned=100;
	float fSpawned=0;

	public GameObject Spawn;
	GameObject RedBloodCell;
	// Use this for initialization
	void Start () 
	{
		RedBloodCell = Resources.Load("Prefabs/Cells/Red") as GameObject;
		fTimeLastSpawned=Time.time;
	}
	// Update is called once per frame
	void Update () 
	{
		if(fTimeLastSpawned+fTimer<Time.time&&fSpawned<fMaximumSpawned)
		{
			fTimeLastSpawned=Time.time;
			GameObject clone = Instantiate(RedBloodCell, Spawn.transform.position, Spawn.transform.rotation) as GameObject;
			fSpawned++;
		}
	}
}
