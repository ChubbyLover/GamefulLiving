using UnityEngine;
using System.Collections;

public class Play_AntibodyCannon : MonoBehaviour {

	public GameObject antibodySprite;
	private Animator anim;

	private AudioSource Asrc;
	// Use this for initialization
	void Start () 
	{
		Asrc = GetComponentInChildren<AudioSource>();
		//anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
		//if(GameObject.Find("Patho_GenericPathogen")==null) Camera.main.GetComponent<Camera_Follow>().Follow(GameObject.Find("Screen1"));
		
		if(gameObject.GetComponent<Play_Behaviour>().selected)
		{
			if (Input.GetMouseButtonDown(0) && Time.timeScale!=0)
			{
				// anim.SetTrigger("Shoot");
				GameObject clone = (GameObject) Instantiate(Resources.Load("Prefabs/Objects/Player/AntibodyMunition"), transform.position+transform.right*0.5f, transform.rotation);
				clone.rigidbody2D.velocity = transform.right*20.0f;
				clone.GetComponent<Play_Antibody>().antibodyType = gameObject.GetComponent<Play_Behaviour>().antibodyType;
				clone.GetComponent<SpriteRenderer>().sprite = antibodySprite.GetComponent<SpriteRenderer>().sprite;
				Animator anim = GetComponent<Animator>();

				anim.SetTrigger("Pew");
				Asrc.clip= Resources.Load("Sounds/Shoot")as AudioClip;
				Asrc.Play();
				// gameObject.tag = "pathogen"+gameObject.GetComponent<Play_Behaviour>().antibodyType.ToString();
			}
		}	
		
	}
}
