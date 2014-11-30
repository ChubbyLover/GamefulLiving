using UnityEngine;
using System.Collections;

public class Camera_Follow : MonoBehaviour {

	// Use this for initialization
	public Transform target;
	public Transform freeMover;

	bool bFrozen=false;

	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 goal = new Vector3(target.position.x,target.position.y,-10f);
		transform.position = transform.position + (goal - transform.position)*0.08f;
	}
	
	public void Follow(GameObject targetToFollow)
	{
		target = targetToFollow.transform;
		print(targetToFollow);
	}
	public void FreezeUnfreeze ()
	{
		if(bFrozen)
		{
			bFrozen=false;
			Time.timeScale	=1;
		}
		else
		{
			bFrozen=true;
			Time.timeScale	=0;
		}
	}
}
