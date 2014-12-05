using UnityEngine;
using System.Collections;

public class Pathogen_Behaviour : MonoBehaviour {
	
	public int timeUntilMitosis;
	public int pathoType;
	public float fLastTime;
	public static int amountOfPathogens  = 1;
	private bool eaten = false;
	public bool Medicine = false;
<<<<<<< HEAD
	public bool MythosisEnabled = true;
	
=======
	public static bool stopSpreading = false;
>>>>>>> b0dcbc4b5e69f2eda455fdd0d82a5cb7dbe8a8a3
	int dissolve=1;
	Transform Phagozytose;

	//Body Influencing variable

	public float fHeart;
	public float fLungs;
	public float fDarm;
	

	// Use this for initialization
	void Start () 
	{
		if(amountOfPathogens > 30) stopSpreading = true;
		timeUntilMitosis = Random.Range(200,amountOfPathogens*300);
		rigidbody2D.AddForce(new Vector2(Random.value*50-25,Random.value*50-25));
		InvokeRepeating("Clean", 10.0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () 
	{
<<<<<<< HEAD
		
		if(MythosisEnabled &&timeUntilMitosis<=0 && !eaten && tag=="Pathogen")
=======
		print (amountOfPathogens);
		if(timeUntilMitosis<=0 && !eaten && tag=="Pathogen")
>>>>>>> b0dcbc4b5e69f2eda455fdd0d82a5cb7dbe8a8a3
		{
			amountOfPathogens++;
			GameObject clone = (GameObject) Instantiate(gameObject, transform.position, transform.rotation);
			timeUntilMitosis = Random.Range(200,amountOfPathogens*300);
			
		}
		if(eaten)
		{
			dissolve--;
			transform.localScale*=0.98f;
			if(Phagozytose!=null )
			{
				// Phagozytose.localScale-=new Vector3(0.0002f,0.0002f,0.0002f);
				Vector3 goal = Phagozytose.position;
				transform.position = transform.position + (goal - transform.position)*0.1f;
				if(dissolve<0)
				{
					if(Phagozytose.gameObject.tag=="Helper")
					{
						Destroy (Phagozytose.gameObject);
					}
					Destroy (gameObject);
				}
			}

		} else {
			if(Time.timeScale == 1.0f && !stopSpreading) {
				
				
				timeUntilMitosis--;
				
			}
		}
		if(Medicine)
		{
			GetComponent<Animator>().SetTrigger("Die");
			Destroy(gameObject,1);
		}
	}
	
	public void Phagozytiert (Transform Phagozyt)
	{
		eaten = true;
		gameObject.tag = "Pathogen"; 
		dissolve = 100;
		Phagozytose=Phagozyt;
	}
	public void Die ()
	{
		Medicine = true;
		gameObject.tag = "Pathogen"; 
		dissolve = 100;
	}
	public void Clean()
	{
		if(tag=="Marked" && !renderer.isVisible && Random.value < 0.1f) { Destroy(gameObject); }
	}
	
	void OnDestroy()
	{
		// Will be called just prior to destruction of the gameobject to which this script is attached
		amountOfPathogens--;
		print (amountOfPathogens);
		
		if(amountOfPathogens<=0) Camera.main.GetComponent<Camera_Follow>().Sieg();
	}
}
