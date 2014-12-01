using UnityEngine;
using System.Collections;

public class Camera_Follow : MonoBehaviour {

	// Use this for initialization
	public Transform target;
	public Transform freeMover;
	public LayerMask walls;
	bool bFrozen=false;

	void Start () {
		InvokeRepeating("BloodstreamIndicators", 0, 2);
		// Physics2D.DefaultRaycastLayers = 8;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 goal = new Vector3(target.position.x,target.position.y,-10f);
		camera.orthographicSize = 5+(goal - transform.position).magnitude;
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
	
	void BloodstreamIndicators()
	{
		Vector2 halfDiagonal = new Vector2(-camera.orthographicSize*8/4.5f, camera.orthographicSize);
		Vector2 upperLeftCorner = (Vector2)transform.position - halfDiagonal;
		Vector2 lowerRightCorner = (Vector2)transform.position + halfDiagonal;
		print (transform.position);
		// spwan above camera
		for(int i = 0; i<10; i++)
		{
			GameObject newRBC = (GameObject) Instantiate(Resources.Load("Prefabs/Objects/RBC/RBC"), new Vector3(upperLeftCorner.x+halfDiagonal.x/5*i,upperLeftCorner.y-1,0), transform.rotation);
			if(Physics2D.RaycastAll(newRBC.transform.position, (target.position-newRBC.transform.position), (target.position-newRBC.transform.position).magnitude, walls).Length%2 == 1) Destroy(newRBC);
			Debug.DrawLine(newRBC.transform.position, target.position, Color.red, 2);
		}
		// spwan below camera
		for(int i = 0; i<10; i++)
		{
			GameObject newRBC = (GameObject) Instantiate(Resources.Load("Prefabs/Objects/RBC/RBC"), new Vector3(lowerRightCorner.x-halfDiagonal.x/5*i,lowerRightCorner.y+1,0), transform.rotation);
			if(Physics2D.RaycastAll(newRBC.transform.position, (target.position-newRBC.transform.position), (target.position-newRBC.transform.position).magnitude, walls).Length%2 == 1) Destroy(newRBC);
			Debug.DrawLine(newRBC.transform.position, target.position, Color.red, 2);
		}
		
	}
}
