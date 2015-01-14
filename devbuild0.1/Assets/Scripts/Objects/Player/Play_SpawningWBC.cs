using UnityEngine;
using System.Collections;

public class Play_SpawningWBC : MonoBehaviour {

	public int iMaxCountWBC;
	public int iCurrentCountWBC;
	public float fMaxCastDistance;

	public int iSpawnTimespan;
	private float fLastSpawn;

	public bool bSpawningEnabled=true;

	public LayerMask SpawningMask;
	public Vector2 VelVector2D;
	public Vector2 AdjustedVelVector2Dr;
	public Vector2 AdjustedVelVector2Dl;
	public Powers_HelperAI script;
	
	private GameObject WBC;



	// Use this for initialization
	void Start () 
	{
		WBC = Resources.Load("Prefabs/Objects/Player/Powers/Power_WhiteHelper") as GameObject;
		fLastSpawn = Time.time;
	}
	
	// Update is called once per frame
	void Update () 
	{
		try{
		script = GameObject.FindGameObjectWithTag("Helper").GetComponent<Powers_HelperAI>();
		if(script!=null) iCurrentCountWBC = script.getAmountOfHelpers();
		} catch { //<3 exception handling like a bozz
		}
		if(iCurrentCountWBC<iMaxCountWBC&&Time.time>fLastSpawn+iSpawnTimespan && bSpawningEnabled)
		{
			VelVector2D = gameObject.rigidbody2D.velocity;
			AdjustedVelVector2Dr = Quaternion.AngleAxis(Random.Range(0,60), Vector3.forward) * VelVector2D;
			AdjustedVelVector2Dl = Quaternion.AngleAxis(Random.Range(300,360), Vector3.forward) * VelVector2D;

			RaycastHit2D WallHit = Physics2D.Raycast(transform.position,VelVector2D,fMaxCastDistance,SpawningMask);
			RaycastHit2D WallHitr = Physics2D.Raycast(transform.position,AdjustedVelVector2Dr,fMaxCastDistance,SpawningMask);
			RaycastHit2D WallHitl = Physics2D.Raycast(transform.position,AdjustedVelVector2Dl,fMaxCastDistance,SpawningMask);

			Debug.DrawLine(transform.position,new Vector3(VelVector2D.x+transform.position.x,VelVector2D.y+transform.position.y,0),Color.green, 2);
			Debug.DrawLine(transform.position,new Vector3(AdjustedVelVector2Dr.x+transform.position.x,AdjustedVelVector2Dr.y+transform.position.y,0),Color.green, 2);
			Debug.DrawLine(transform.position,new Vector3(AdjustedVelVector2Dl.x+transform.position.x,AdjustedVelVector2Dl.y+transform.position.y,0),Color.green, 2);
			if(WallHit.collider!=null)
			{
				// Debug.DrawLine (transform.position, WallHit.point, Color.cyan,5);

				GameObject clone = Instantiate(WBC,WallHit.point+WallHit.normal*0.1f,WBC.transform.rotation) as GameObject;
				iCurrentCountWBC++;
				fLastSpawn=Time.time;
			}
			else
			{
				// Debug.DrawLine (transform.position, WallHit.point, Color.cyan,5);
				GameObject clone = Instantiate(WBC,WallHit.point,transform.rotation) as GameObject;
				iCurrentCountWBC++;
				fLastSpawn=Time.time;
			}

			if(WallHitr.collider!=null)
			{
				// Debug.DrawLine (transform.position, WallHit.point, Color.cyan,5);
				
				GameObject clone = Instantiate(WBC,WallHitr.point+WallHitr.normal*0.1f,WBC.transform.rotation) as GameObject;
				iCurrentCountWBC++;
				fLastSpawn=Time.time;
			}
			else
			{
				// Debug.DrawLine (transform.position, WallHit.point, Color.cyan,5);
				GameObject clone = Instantiate(WBC,WallHitr.point,transform.rotation) as GameObject;
				iCurrentCountWBC++;
				fLastSpawn=Time.time;
			}

			if(WallHitl.collider!=null)
			{
				// Debug.DrawLine (transform.position, WallHit.point, Color.cyan,5);
				
				GameObject clone = Instantiate(WBC,WallHitl.point+WallHitl.normal*0.1f,WBC.transform.rotation) as GameObject;
				iCurrentCountWBC++;
				fLastSpawn=Time.time;
			}
			else
			{
				// Debug.DrawLine (transform.position, WallHit.point, Color.cyan,5);
				GameObject clone = Instantiate(WBC,WallHitl.point,transform.rotation) as GameObject;
				iCurrentCountWBC++;
				fLastSpawn=Time.time;
			}


		}
	}
}
