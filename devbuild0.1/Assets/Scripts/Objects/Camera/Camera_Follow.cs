using UnityEngine;
using System.Collections;

public class Camera_Follow : MonoBehaviour {

	// Use this for initialization
	public Transform target;
	public Transform storeTarget;
	public LayerMask walls;
	bool bFrozen=false;
	bool freeLook = false;
	bool bStart=true;
	public bool bCameralocked=true;
	public Texture2D CursorIMGNormal;

	void Start () 
	{
<<<<<<< HEAD
		Cursor.SetCursor(CursorIMGNormal,Vector2.zero,CursorMode.Auto);
		InvokeRepeating("BloodstreamIndicators", 0, 10);
		if(Application.loadedLevelName=="Level_Tutorial") bStart=false;	
=======
		// InvokeRepeating("BloodstreamIndicators", 0, 10);
>>>>>>> 7be481b070567a9f509331d24dfc75bbdf861477
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(bStart)
		{
			FreezeUnfreeze();
			bStart=false;
		}
		if(!freeLook)
		{
			Vector3 goal = new Vector3(target.position.x,target.position.y,-10f);
		 	camera.orthographicSize = 5+(goal - transform.position).magnitude;
			transform.position = transform.position + (goal - transform.position)*0.08f;
		}
	}
	void Update(){
		GameObject[] Marked = GameObject.FindGameObjectsWithTag("Marked") as GameObject[];
		GameObject[] UnMarked = GameObject.FindGameObjectsWithTag("Pathogen") as GameObject[];

		if(Marked.Length==0&&UnMarked.Length==0)
		{
			FreezeUnfreeze();
			bCameralocked=true;
			GameObject.Find("Canvas_Ingame_GUI_Tut").GetComponent<Canvas>().enabled=false;
			GameObject.Find("Canvas_LevelSieg").GetComponent<Canvas>().enabled=true;
		}
		if(freeLook)
		{
			Vector3 goal = new Vector3(target.position.x,target.position.y,-10f);
			camera.orthographicSize = 10;
			transform.position = transform.position + (goal - transform.position)*0.08f;
		}

	}
	
	public void Follow(GameObject targetToFollow)
	{
		target = targetToFollow.transform;
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
	public void sbCameraLocked (bool b)
	{
		this.bCameralocked=b;
	}
	public void startFreeLook(Transform freeTarget)
	{
		if(!bCameralocked)
		{
			freeLook = true;
			Time.timeScale=0.1f;
			storeTarget = target;
			target=freeTarget;
		}
	}
	public void endFreeLook()
	{
		if(freeLook)
		{
			freeLook = false;
			Time.timeScale=1;
			target = storeTarget;
		}
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
