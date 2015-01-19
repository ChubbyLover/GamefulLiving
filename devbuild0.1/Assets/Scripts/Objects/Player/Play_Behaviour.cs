using UnityEngine;
using System.Collections;

public class Play_Behaviour: MonoBehaviour {

	public int lifeSpan;
	public bool selected;
	public bool activated;
	public int antibodyType;
	public float fCompensator;
	public float fMaxSpeed;
	public GameObject antibodySprite;
	public Transform partner;
	public LayerMask SpawningMask;
	private AudioSource Asrc;
	
	private Animator[] anims;
	private Transform target;
	
	void Awake() {
		// Application.targetFrameRate = 60;
	}
	
	void Start () 
	{
		
		/*if(antibodyType == 16) antibodyType = Random.Range(0,15);
		Sprite[] test = Resources.LoadAll <Sprite> ("Sprites/Objects/Player/Play_Antigens");
		antibodySprite.GetComponent<SpriteRenderer>().sprite = test[antibodyType];*/
		Asrc = GetComponentInChildren<AudioSource>();
		anims=GetComponentsInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		//CHANGE ZYTHI SELECTION
		if (Input.GetKeyDown(KeyCode.F)&&Application.loadedLevelName != "Level_Tutorial_1"&&Application.loadedLevelName != "Level_Tutorial_2"&&Application.loadedLevelName != "Level_Tutorial_3")
		{
			selected = !selected;
			if(selected) 
			{ 
				transform.localScale = new Vector3(0.3f,0.3f,0.3f);
				// gameObject.GetComponent<SpriteRenderer>().sortingOrder = 7;
				Camera.main.GetComponent<Camera_Follow>().Follow(gameObject);
			} else {
				transform.localScale = new Vector3(0.2f,0.2f,0.2f);
				// gameObject.GetComponent<SpriteRenderer>().sortingOrder = 5;
			}
		}
		
		if(selected)
		{
			if(Time.timeScale == 1.0f)// LOOKAT MOUSE
			{
				Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
				float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
				transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

				if(Input.GetKey(KeyCode.Space)) rigidbody2D.AddForce(dir.normalized*fCompensator*Time.deltaTime);
			}
		}
		else
		{
			// QUIETLY FOLLOW YOUR PARTNER
			Vector2 dir = partner.position - transform.position;
			
			// Check if wall inbetween
				RaycastHit2D WallHit = Physics2D.Raycast(partner.position,-dir,dir.magnitude,SpawningMask);
				if(WallHit.collider!=null)
				{
					transform.position = WallHit.point+dir.normalized*0.1f;
				}
			
			if(dir.magnitude > 2)  {
				rigidbody2D.velocity = dir*(float)(dir.magnitude-2.0f);
			} else {
				rigidbody2D.velocity = Vector2.zero; 
			}
			float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}
		
		/*if(target != null)
		{
			Vector2 dir = target.position - transform.position;
			float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			Quaternion desiredRotation = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.time*0.01f);
			// print(transform.rotation);
		}*/
	}
	
	
	void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.tag == "Antigene" && selected)
		{
			antibodyType = collision.gameObject.GetComponent<Level_Anitgene>().antigeneType;
			partner.gameObject.GetComponent<Play_Behaviour>().antibodyType = antibodyType;
			antibodySprite.GetComponent<SpriteRenderer>().sprite = collision.gameObject.GetComponent<SpriteRenderer>().sprite;
			partner.gameObject.GetComponent<Play_Behaviour>().antibodySprite.GetComponent<SpriteRenderer>().sprite = collision.gameObject.GetComponent<SpriteRenderer>().sprite;
			Destroy (collision.gameObject);
		}
		else
		{
			Asrc.clip = Resources.Load("Sounds/Bump") as AudioClip;
			Asrc.Play();
		}
	}
		
	void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Pathogen" || collision.gameObject.tag == "Marked")
		{	
			if(collision.gameObject.GetComponent<Pathogen_Behaviour>().pathoType == antibodyType)
			{
				if(collision.gameObject.transform.parent == null) collision.gameObject.transform.parent = gameObject.transform;
				Destroy(collision.gameObject.GetComponent<Rigidbody2D>());
				Destroy(collision.gameObject.GetComponent<CircleCollider2D>());
				collision.gameObject.GetComponent<Pathogen_Behaviour>().Phagozytiert(gameObject.transform);
				// transform.localScale+=new Vector3(0.02f,0.02f,0.02f);
				anims[0].SetTrigger("HitEnemy");
				anims[1].SetTrigger("HitEnemy");
				Asrc.clip = Resources.Load("Sounds/Eating") as AudioClip;
				Asrc.Play();
			}
		}

	}

	bool GetAnyKey(params KeyCode[] aKeys)
	{
		foreach(var key in aKeys)
			if (Input.GetKey(key))
				return true;
		return false;
	}

	void OnTriggerLeave2D(Collider2D collision)
	{
		
		// CLOSE MOUTH
	}
}
