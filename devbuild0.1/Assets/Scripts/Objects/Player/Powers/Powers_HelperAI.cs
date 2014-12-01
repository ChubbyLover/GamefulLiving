using UnityEngine;
using System.Collections;

public class Powers_HelperAI : MonoBehaviour 
{

	GameObject Target;
	GameObject WBC;
	public string sState;

	public float fSpeed;
	public float fSpeedRotation;
	public float fSpeedMaximum;

	float fLastTimeDirectionChanged;
	public int iTimeDirectionChange;
	public float fTimeToDeath;
	public bool bConsumedPathogen = false;

	// Use this for initialization
	void Start ()
	{
		fLastTimeDirectionChanged = Time.time;
		WBC=GameObject.FindGameObjectWithTag("wbc");
	}
	
	// Update is called once per frame
	void Update ()
	{
		Statemachine();
	}

	void OnBecameInvisible() 
	{
		if(WBC!=null && sState != "Consume")
		{
			Play_SpawningWBC script = GameObject.FindGameObjectWithTag("wbc").GetComponent<Play_SpawningWBC>();
			script.iCurrentCountWBC--;
			Destroy(gameObject);
		}
	}
	void Idle()
	{
		if(Target == null&&Time.time > fLastTimeDirectionChanged+iTimeDirectionChange&&rigidbody2D.velocity.magnitude < fSpeedMaximum&&!bConsumedPathogen)
		{
			Vector2 Direction = new Vector2(Random.Range(-fSpeed,fSpeed),Random.Range(-fSpeed,fSpeed));
			rigidbody2D.AddForce(Direction,ForceMode2D.Impulse);
			fLastTimeDirectionChanged = Time.time;
			sState = "Search";
		}
		if(bConsumedPathogen)
		{
			transform.localScale*=0.98f;
			// Destroy(gameObject,fTimeToDeath);
		}
	}
	public void Search()
	{
		// GameObject[] PathogensUnmarked;
		GameObject[] PathogensMarked;
		float fDistance = 50000;

		// PathogensUnmarked = GameObject.FindGameObjectsWithTag("Pathogen");
		PathogensMarked = GameObject.FindGameObjectsWithTag("Marked");
		if(PathogensMarked != null)
		{

			foreach (GameObject Pathogen in PathogensMarked)
			{
				if(Vector3.Distance(transform.position,Pathogen.transform.position)<fDistance)
				{
					fDistance = Vector3.Distance(transform.position,Pathogen.transform.position);
					Target = Pathogen;

				}
			}
		}
		/*if(PathogensUnmarked != null&&Target == null)
		{
			foreach (GameObject Pathogen in PathogensUnmarked)
			{
				if(Vector3.Distance(transform.position,Pathogen.transform.position)<fDistance)
				{
					fDistance = Vector3.Distance(transform.position,Pathogen.transform.position);
					Target = Pathogen;
				}
			}
		}*/
		if(Target == null) sState="Idle";
		else sState="Swim";
	}
	void Swim()
	{
		if (Target!=null)
		{
			Vector3 vectorToTarget = Target.transform.position - transform.position;
			float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
			Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * fSpeedRotation);

			if(rigidbody2D.velocity.sqrMagnitude < fSpeedMaximum)
			{
				rigidbody2D.AddRelativeForce(Vector2.right*fSpeed,ForceMode2D.Impulse);
			}
		}
	}
	void Consume ()
	{
		Animator anim = gameObject.GetComponent<Animator>();

		anim.SetTrigger("Consume");
		GameObject[] WBC = GameObject.FindGameObjectsWithTag("Helper");
		foreach (GameObject Helper in WBC)
		{
			Powers_HelperAI HelperAI = Helper.GetComponent<Powers_HelperAI>();
			HelperAI.ForceState("Search");
		}
		sState="Idle";
	}
	void Statemachine ()
	{
		switch (sState)
		{
		case "Idle": 	Idle ();
					 	break;
		case "Search": 	Search ();
						break;
		case "Swim": 	Swim ();
						break;
		case "Consume": Consume ();
						break;
		default: 		Idle ();
						break;
		}
	}
	public void ForceState(string sState)
	{
		this.sState=sState;
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag=="Marked")
		{
			sState="Consume";
			col.gameObject.GetComponent<Pathogen_Behaviour>().Phagozytiert(gameObject.transform);
			bConsumedPathogen=true;
		}
		if(col.gameObject.tag=="Wall")
		{
			sState="Idle";
		}
	}
}
