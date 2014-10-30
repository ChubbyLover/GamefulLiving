using UnityEngine;
using System.Collections;

public class cameraScript : MonoBehaviour {

	// Use this for initialization
	public Transform target;
	public Transform freeMover;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 goal = new Vector3(target.position.x,target.position.y,-10f);
		transform.position = transform.position + (goal - transform.position)*0.08f;
	}
	
	public void Follow(GameObject targetToFollow)
	{
		try{
			target.gameObject.GetComponent<cell>().selected = false;
		} catch {}
		freeMover.position = transform.position;
		target = targetToFollow.transform;
	}
}
