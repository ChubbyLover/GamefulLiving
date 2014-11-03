using UnityEngine;
using System.Collections;

public class Play_AntibodyCannon : MonoBehaviour {

	public GameObject antibodySprite;
	private Animator anim;
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(GameObject.Find("Patho_GenericPathogen")==null) Camera.main.GetComponent<Camera_Follow>().Follow(GameObject.Find("Screen1"));
		
		if(gameObject.GetComponent<Play_Behaviour>().selected)
		{
			Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
			float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			
			if (Input.GetMouseButtonDown(0) && Time.timeScale!=0)
			{
				anim.SetTrigger("Shoot");
				GameObject clone = (GameObject) Instantiate(Resources.Load("Prefabs/Objects/Player/PLay_Antibody"), transform.position+transform.right, transform.rotation);
				clone.rigidbody2D.velocity = transform.right*20.0f;
				clone.GetComponent<Play_Antibody>().antibodyType = gameObject.GetComponent<Play_Behaviour>().antibodyType;
				clone.GetComponent<SpriteRenderer>().sprite = antibodySprite.GetComponent<SpriteRenderer>().sprite;
				gameObject.tag = "pathogen"+gameObject.GetComponent<Play_Behaviour>().antibodyType.ToString();
			}
		}	
		
	}
}
