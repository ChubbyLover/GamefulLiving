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

	private Animator[] anims;
	private Transform target;

	void Start () 
	{
		// selected = false;
		if(antibodyType == 16) antibodyType = Random.Range(0,15);
		Sprite[] test = Resources.LoadAll <Sprite> ("Sprites/Objects/Player/Play_Antigens");
		antibodySprite.GetComponent<SpriteRenderer>().sprite = test[antibodyType];
		anims=gameObject.GetComponentsInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
		if(!selected && !activated) 
		{	
			
			lifeSpan--; 
			if(lifeSpan < 0) Destroy(gameObject);
		}
		else{
			if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)&&rigidbody2D.velocity.magnitude<fMaxSpeed)
			{
				rigidbody2D.AddForce(Vector2.up*fCompensator);	
			}
			if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)&&rigidbody2D.velocity.magnitude<fMaxSpeed)
			{
				rigidbody2D.AddForce(Vector2.up*fCompensator*-1.0f);
			}
			if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)&&rigidbody2D.velocity.magnitude<fMaxSpeed)
			{
				rigidbody2D.AddForce(Vector2.right*fCompensator*-1.0f);	
			}
			if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)&&rigidbody2D.velocity.magnitude<fMaxSpeed)
			{
				rigidbody2D.AddForce(Vector2.right*fCompensator);	
			}
		}
		
		if(target != null)
		{
			Vector2 dir = target.position - transform.position;
			float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			Quaternion desiredRotation = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.time*0.01f);
			// print(transform.rotation);
		}
	}
	
	void OnMouseDown()
	{
		Camera.main.GetComponent<Camera_Follow>().Follow(gameObject);
		selected = true;
	}
	
	void OnCollisionEnter2D(Collision2D collision){
		
		if(collision.gameObject.tag == "pathogen"+(antibodyType.ToString())) 
		{	
			if((collision.gameObject.name == "Patho_GenericPathogen" || collision.gameObject.name == "Patho_GenericPathogen(Clone)") && (gameObject.name != "Play_AntibodyCannon(Clone)") && (gameObject.name != "Play_AntibodyCannon")) 
			{
				if(collision.gameObject.transform.parent == null) collision.gameObject.transform.parent = gameObject.transform;
				Destroy(collision.gameObject.GetComponent<Rigidbody2D>());
				// Destroy(collision.gameObject.GetComponent<CircleCollider2D>());
				collision.gameObject.GetComponent<Prototype_Patho_Behaviour>().Phagozytiert(gameObject.transform);
				transform.localScale+=new Vector3(0.02f,0.02f,0.02f);
				anims[0].SetTrigger("HitEnemy");
				anims[1].SetTrigger("HitEnemy");
				target = null;
				// Destroy (collision.gameObject);
			}			
			// ACTIVATE
			if(!activated) 
			{	
				activated = true;
				GameObject cannon = (GameObject) Instantiate(Resources.Load("Prefabs/Objects/Player/Play_AntibodyCannon"), transform.position, transform.rotation);
				cannon.GetComponent<Play_Behaviour>().antibodyType = antibodyType;
				cannon.GetComponent<Play_Behaviour>().activated = true;
			}
		}
		
	}
	
	void OnTriggerEnter2D(Collider2D collision)
	{
		
		if(collision.tag == "pathogen11" && target==null){
			 target = collision.transform;
		} 
	}
	
	void OnTriggerLeave2D(Collider2D collision)
	{
		
		if(collision.tag == "pathogen11" && target!=null){
			target = null;
		} 
	}
}
