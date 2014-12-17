using UnityEngine;
using System.Collections;

public class Play_SpawningWBC : MonoBehaviour {

	public int iMaxCountWBC;
	public int iCurrentCountWBC;
	public float fMaxCastDistance;
	public int iSpawnTimespan;

	public LayerMask SpawningMask;
	public Vector2 VelVector2D;
	public Powers_HelperAI script;
	
	private GameObject WBC;

	private float iLastSpawn;

	// Use this for initialization
	void Start () 
	{
		WBC = Resources.Load("Prefabs/Objects/Player/Powers/Power_WhiteHelper") as GameObject;
		iLastSpawn = Time.time;
	}
	
	// Update is called once per frame
	void Update () 
	{
		try{
		script = GameObject.FindGameObjectWithTag("Helper").GetComponent<Powers_HelperAI>();
		if(script!=null) iCurrentCountWBC = script.getAmountOfHelpers();
		} catch { //<3 exception handling like a bozz
		}
		if(iCurrentCountWBC<iMaxCountWBC&&Time.time>iLastSpawn+iSpawnTimespan)
		{
			VelVector2D = gameObject.rigidbody2D.velocity;
			RaycastHit2D WallHit = Physics2D.Raycast(transform.position,VelVector2D,fMaxCastDistance,SpawningMask);
			if(WallHit.collider!=null)
			{
				// Debug.DrawLine (transform.position, WallHit.point, Color.cyan,5);

				GameObject clone = Instantiate(WBC,WallHit.point+WallHit.normal*0.1f,WBC.transform.rotation) as GameObject;
				iCurrentCountWBC++;
				iLastSpawn=Time.time;
			}
			else
			{
				// Debug.DrawLine (transform.position, WallHit.point, Color.cyan,5);
				GameObject clone = Instantiate(WBC,WallHit.point,transform.rotation) as GameObject;
				iCurrentCountWBC++;
				iLastSpawn=Time.time;
			}
		}
	}
}
