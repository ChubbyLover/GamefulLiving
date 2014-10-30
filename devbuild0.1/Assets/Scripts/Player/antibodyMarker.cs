using UnityEngine;
using System.Collections;

public class antibodyMarker : MonoBehaviour {

	int life;
	public int antibodyType;
	// Use this for initialization
	void Start () {
		life=100;
	}
	
	// Update is called once per frame
	void Update () {
		//life--;
		if(life<0) Destroy(gameObject);
	}
	
	void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.tag == "pathogen"+(antibodyType.ToString()) && (collision.gameObject.name == "pathogen" || collision.gameObject.name == "pathogen(Clone)")) 
		{
			if(gameObject.transform.parent == null) gameObject.transform.parent = collision.gameObject.transform;
			Destroy(gameObject.GetComponent<Rigidbody2D>());
			Destroy(gameObject.GetComponent<CircleCollider2D>());
			collision.gameObject.tag="marked";
		}
	}
}
