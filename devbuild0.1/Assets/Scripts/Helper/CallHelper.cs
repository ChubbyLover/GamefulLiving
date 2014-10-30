using UnityEngine;
using System.Collections;

public class CallHelper : MonoBehaviour 
{

	public int iHelperNumber;
	private float fLastUsed;
	public float fTimer;
	
	GameObject Helper;
	cell CellScript;

	// Use this for initialization
	void Start () 
	{
		CellScript = gameObject.GetComponent<cell>();
		fLastUsed = Time.time;
		Helper = Resources.Load("Prefabs/Cells/White_helper") as GameObject;
	}
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyUp(KeyCode.Alpha1)&&Time.time>=fLastUsed+fTimer&&CellScript.selected)
		{
			int i=0;
			while (i<iHelperNumber)
			{
				GameObject clone = Instantiate(Helper, transform.position, Quaternion.identity) as GameObject;
				i++;
			}

		}
	}
}
