using UnityEngine;
using System.Collections;

public class Pathogen_Behaviour : MonoBehaviour {
	
	public int timeUntilMitosis;
	public float fLastTime;
	public static int amountOfPathogens  = 1;

	int dissolve=1;
	Transform Phagozytose;

	//Body Influencing variable

	public float fHeart;
	public float fLungs;
	public float fDarm;

	// Use this for initialization
	void Start () 
	{
		timeUntilMitosis = Random.Range(10,amountOfPathogens*100);
		rigidbody2D.AddForce(new Vector2(Random.value*50-25,Random.value*50-25));
	}
	
	// Update is called once per frame
	void Update () 
	{
		timeUntilMitosis--;
		if(timeUntilMitosis<=0)
		{
			amountOfPathogens++;
			GameObject clone = (GameObject) Instantiate(gameObject, transform.position, transform.rotation);
			timeUntilMitosis = Random.Range(10,amountOfPathogens*100);
		}
		if(Phagozytose!=null)
		{
			dissolve--;
			transform.localScale*=0.98f;
			Phagozytose.localScale-=new Vector3(0.0002f,0.0002f,0.0002f);
			Vector3 goal = Phagozytose.position;
			transform.position = transform.position + (goal - transform.position)*0.08f;
			if(dissolve<0)
			{
				Destroy (gameObject);
			}
		}
	}
	
	public void Phagozytiert (Transform Phagozyt)
	{
		dissolve = 100;
		Phagozytose=Phagozyt;
	}
}
