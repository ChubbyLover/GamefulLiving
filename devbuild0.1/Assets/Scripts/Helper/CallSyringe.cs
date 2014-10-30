using UnityEngine;
using System.Collections;

public class CallSyringe : MonoBehaviour {

	GameObject ClosestWall;
	GameObject Syringe;
	float fDistance =2000;

	cell Cellscript;
	// Use this for initialization
	void Start () 
	{
		Cellscript = gameObject.GetComponent<cell>();
		Syringe = Resources.Load("Prefabs/Syringe") as GameObject;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyUp(KeyCode.Alpha2)&&Cellscript.selected)
		{
			GetClosestWall();
			Quaternion SyringeRotation = ClosestWall.transform.rotation; 
			SyringeRotation*=Quaternion.Euler(0,0,90);
			GameObject clone = Instantiate(Syringe, ClosestWall.transform.position,SyringeRotation) as GameObject;
			Syringe med = clone.GetComponent<Syringe>();
			med.iAntibodytype=Cellscript.antibodyType;
		}
	}
	void GetClosestWall()
	{
		GameObject[] Walls = GameObject.FindGameObjectsWithTag("Wall");
		foreach(GameObject Wall in Walls)
		{
			if (fDistance > Vector3.Distance(Wall.transform.position, gameObject.transform.position))
			{
				fDistance=Vector3.Distance(Wall.transform.position, gameObject.transform.position);
				ClosestWall=Wall;
			}
		}
	}
}
