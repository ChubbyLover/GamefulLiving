using UnityEngine;
using System.Collections;

public class Play_Antibody : MonoBehaviour {

	int life;
	public int antibodyType;
	// Use this for initialization
	void Start () {
		life=100;
	}
	
	// Update is called once per frame
	void Update () {
		if(gameObject.transform.parent == null) life--;
		if(life<0) Destroy(gameObject);
	}
	
	void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.tag == "Pathogen" || collision.gameObject.tag == "Marked") 
		{
			if(collision.gameObject.GetComponent<Pathogen_Behaviour>().pathoType == antibodyType)
			{
				gameObject.transform.parent = collision.gameObject.transform;
				Destroy(gameObject.GetComponent<Rigidbody2D>());
				Destroy(gameObject.GetComponent<BoxCollider2D>());
				collision.gameObject.tag="Marked";
				collision.gameObject.layer=17;
			}
		}
	}
}
