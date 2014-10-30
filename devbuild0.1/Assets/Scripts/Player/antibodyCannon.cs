using UnityEngine;
using System.Collections;

public class antibodyCannon : MonoBehaviour {

	public GameObject antibodySprite;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(gameObject.GetComponent<cell>().selected)
		{
			Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
			float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			
			if (Input.GetMouseButtonDown(0))
			{
				GameObject clone = (GameObject) Instantiate(Resources.Load("antibodyMarker"), transform.position+transform.right, transform.rotation);
				clone.rigidbody2D.velocity = transform.right*100.0f;
				clone.GetComponent<antibodyMarker>().antibodyType = gameObject.GetComponent<cell>().antibodyType;
				clone.GetComponent<SpriteRenderer>().sprite = antibodySprite.GetComponent<SpriteRenderer>().sprite;
				gameObject.tag = "pathogen"+gameObject.GetComponent<cell>().antibodyType.ToString();
			}
		}	
		
	}
}
