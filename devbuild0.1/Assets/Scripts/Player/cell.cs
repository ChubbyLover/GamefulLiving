﻿using UnityEngine;
using System.Collections;

public class cell : MonoBehaviour {

	public int lifeSpan;
	public bool selected;
	public bool activated;
	public int antibodyType;
	public float fCompensator=100;
	public GameObject antibodySprite;
	void Start () {
		selected = false;
		if(antibodyType == 16) antibodyType = Random.Range(0,15);
		Sprite[] test = Resources.LoadAll <Sprite> ("sprites/antigeneTypes");
		antibodySprite.GetComponent<SpriteRenderer>().sprite = test[antibodyType];
	}
	
	// Update is called once per frame
	void Update () {
		if(!selected && !activated) 
		{	
			lifeSpan--; 
			if(lifeSpan < 0) Destroy(gameObject);
		}
		else{
			if (Input.GetKey(KeyCode.W))
			{
				rigidbody2D.AddForce(Vector2.up*fCompensator);	
			}
			if (Input.GetKey(KeyCode.S))
			{
				rigidbody2D.AddForce(Vector2.up*fCompensator*-1.0f);
			}
			if (Input.GetKey(KeyCode.A))
			{
				rigidbody2D.AddForce(Vector2.right*fCompensator*-1.0f);	
			}
			if (Input.GetKey(KeyCode.D))
			{
				rigidbody2D.AddForce(Vector2.right*fCompensator);	
			}
		}
		
	}
	
	void OnMouseDown()
	{
		Camera.main.GetComponent<cameraScript>().Follow(gameObject);
		selected = true;
	}
	
	void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.tag == "pathogen"+(antibodyType.ToString())) 
		{	
			if((collision.gameObject.name == "pathogen" || collision.gameObject.name == "pathogen(Clone)") && (gameObject.name != "antibodyCannon(Clone)")) Destroy (collision.gameObject);
			
			// ACTIVATE
			if(!activated) 
			{	
				activated = true;
				GameObject cannon = (GameObject) Instantiate(Resources.Load("antibodyCannon"), transform.position, transform.rotation);
				cannon.GetComponent<cell>().antibodyType = antibodyType;
				cannon.GetComponent<cell>().activated = true;
			}
		}
		
	}
}
