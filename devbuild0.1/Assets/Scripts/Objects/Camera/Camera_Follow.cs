using UnityEngine;
using System.Collections;

public class Camera_Follow : MonoBehaviour {

	// Use this for initialization
	public Transform target;
	public Transform freeMover;
	public LayerMask walls;
	bool bFrozen=false;

	void Start () {
		InvokeRepeating("BloodstreamIndicators", 0, 1);
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
	
	public bool pointInBloodStream(Vector2 test)
	{
		bool stillToCheck = true;
		bool inside = false;
		Vector2 toTest = test;
		while(stillToCheck)
		{
			toTest = Physics2D.Raycast(toTest, Vector2.zero-toTest, 1000, walls).point;
			if(toTest == Vector2.zero) stillToCheck = false;
			else {
				inside = !inside;
				toTest += (Vector2.zero-toTest).normalized/10;
			}
		}
		return inside;
		
	}
	
	void BloodstreamIndicators()
	{
		Vector2 halfDiagonal = new Vector2(-camera.orthographicSize*8/4.5f, camera.orthographicSize);
		Vector2 upperLeftCorner = (Vector2)transform.position - halfDiagonal;
		Vector2 lowerRightCorner = (Vector2)transform.position + halfDiagonal;
		
		// spwan above camera
		for(int i = 0; i<10; i++)
		{
			GameObject newRBC = (GameObject) Instantiate(Resources.Load("Prefabs/Objects/RBC/RBC"), new Vector3(upperLeftCorner.x+halfDiagonal.x/5*i,upperLeftCorner.y-1,0), transform.rotation);
			if(!pointInBloodStream(newRBC.transform.position)) Destroy(newRBC);
			
		}
		// spwan below camera
		for(int i = 0; i<10; i++)
		{
			GameObject newRBC = (GameObject) Instantiate(Resources.Load("Prefabs/Objects/RBC/RBC"), new Vector3(lowerRightCorner.x-halfDiagonal.x/5*i,lowerRightCorner.y+1,0), transform.rotation);
			if(!pointInBloodStream(newRBC.transform.position)) Destroy(newRBC);			
		}
		// spwan left camera
		for(int i = 0; i<10; i++)
		{
			GameObject newRBC = (GameObject) Instantiate(Resources.Load("Prefabs/Objects/RBC/RBC"), new Vector3(upperLeftCorner.x+1,upperLeftCorner.y+halfDiagonal.y/5*i,0), transform.rotation);
			if(!pointInBloodStream(newRBC.transform.position)) Destroy(newRBC);			
		}
		// spwan right camera
		for(int i = 0; i<10; i++)
		{
			GameObject newRBC = (GameObject) Instantiate(Resources.Load("Prefabs/Objects/RBC/RBC"), new Vector3(lowerRightCorner.x-1,lowerRightCorner.y-halfDiagonal.y/5*i,0), transform.rotation);
			if(!pointInBloodStream(newRBC.transform.position)) Destroy(newRBC);			
		}
		
	}
}
