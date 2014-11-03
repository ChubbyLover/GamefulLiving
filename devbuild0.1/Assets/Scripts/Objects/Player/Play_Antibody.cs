using UnityEngine;
using System.Collections;

public class Play_Antibody : MonoBehaviour {

	int life;
	public int antibodyType;
	// Use this for initialization
	void Start () {
		life=1000;
	}
	
	// Update is called once per frame
	void Update () {
		life--;
		if(life<0) Destroy(gameObject);
	}
	
	void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.tag == "pathogen"+(antibodyType.ToString()) && (collision.gameObject.name == "Patho_GenericPathogen" || collision.gameObject.name == "Patho_GenericPathogen(Clone)") || collision.gameObject.tag == "marked") 
		{
			if(gameObject.transform.parent == null) gameObject.transform.parent = collision.gameObject.transform;
			Destroy(gameObject.GetComponent<Rigidbody2D>());
			Destroy(gameObject.GetComponent<CircleCollider2D>());
			collision.gameObject.GetComponent<Prototype_Patho_Behaviour>().Phagozytiert(gameObject.transform);
			collision.gameObject.tag="marked";
		}
	}
}
