using UnityEngine;
using System.Collections;

public class Prototype_Patho_Behaviour : MonoBehaviour {
	
	public int timeUntilMitosis;
	public GameObject antibodySprite;
	public int antibodyType;
	public static int amountOfPathogens  = 1;
	int dissolve;
	Transform Phagozytose;
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
		if(Phagozytose!=null)
		{
			dissolve--;
			transform.localScale*=0.98f;
			Phagozytose.localScale-=new Vector3(0.0002f,0.0002f,0.0002f);
			Vector3 goal = Phagozytose.position;
			transform.position = transform.position + (goal - transform.position)*0.08f;
			if(dissolve<0) Destroy (gameObject);
		}
	}
	
	public void Phagozytiert (Transform Phagozyt)
	{
		dissolve = 100;
		Phagozytose=Phagozyt;
	}
}
