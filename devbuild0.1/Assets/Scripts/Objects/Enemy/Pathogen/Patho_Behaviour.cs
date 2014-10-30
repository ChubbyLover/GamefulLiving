using UnityEngine;
using System.Collections;

public class Patho_Behaviour : MonoBehaviour {
	
	public int timeUntilMitosis;
	public GameObject antibodySprite;
	public int antibodyType;
	public static int amountOfPathogens  = 1;
	// Use this for initialization
	void Start () {
		if(antibodyType == 16) 
		{
			antibodyType = Random.Range(0,15);
		}
		Sprite[] test = Resources.LoadAll <Sprite> ("Sprites/Objects/Player/Play_Antigens");
		antibodySprite.GetComponent<SpriteRenderer>().sprite = test[antibodyType];
		gameObject.tag = "pathogen"+antibodyType.ToString();
		
		timeUntilMitosis = Random.Range(50,amountOfPathogens*100);
		rigidbody2D.AddForce(new Vector2(Random.value*50-25,Random.value*50-25));
	}
	
	// Update is called once per frame
	void Update () {
		timeUntilMitosis--;
		if(timeUntilMitosis < 0)
		{
			amountOfPathogens++;
			GameObject clone = (GameObject) Instantiate(Resources.Load("Prefabs/Objects/Enemy/Pathogen/Patho_GenericPathogen"), transform.position, transform.rotation);
			clone.GetComponent<Patho_Behaviour>().antibodyType = antibodyType;
			timeUntilMitosis = Random.Range(50,amountOfPathogens*100);
		}
	}
}
