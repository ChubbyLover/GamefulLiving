using UnityEngine;
using System.Collections;

public class Pathogen_Behaviour : MonoBehaviour {
	
	public int timeUntilMitosis;
	public int pathoType;
	public float fLastTime;
	public static int amountOfPathogens  = 1;
	private bool eaten = false;
	public bool Medicine = false;
	public bool bEasymode=false;
	public static bool stopSpreading = false;
	int dissolve=1;
	Transform Phagozytose;

	public int MytosisMin;
	public int MytosisMax;
	public int maxAmountOfPathogens;

	//Body Influencing variable

	public float fHeart;
	public float fLungs;
	public float fDarm;
	
	void OnLevelWasLoaded(int level) {
		stopSpreading = false;
		amountOfPathogens  = 1;
	}
	// Use this for initialization
	void Start () 
	{
		if(bEasymode&&amountOfPathogens > maxAmountOfPathogens) stopSpreading = true;
		if(Application.loadedLevelName=="Level_Tutorial_1") stopSpreading=true;
		timeUntilMitosis = Random.Range(MytosisMin,amountOfPathogens*MytosisMax);
		rigidbody2D.AddForce(new Vector2(Random.value*50-25,Random.value*50-25));
		InvokeRepeating("Clean", 10.0f, 2.0f);
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		
		if(timeUntilMitosis<=0 && !eaten && tag=="Pathogen")
		{
			amountOfPathogens++;
			GameObject clone = (GameObject) Instantiate(gameObject, transform.position, transform.rotation);
			timeUntilMitosis = Random.Range(MytosisMin,amountOfPathogens*MytosisMax);
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
				
			}

		} else {
			if(Time.timeScale == 1.0f && !stopSpreading) {
				
				
				timeUntilMitosis--;
				
			}
		}
		if(dissolve<0 || transform.localScale.x < 0.01f)
		{
			if(Phagozytose!=null )
			{
				if(Phagozytose.gameObject.tag=="Helper")
				{
					Destroy (Phagozytose.gameObject);
				}
			}
			Destroy (gameObject);
		}
		
		if(Medicine)
		{
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
	public void goDiePlease()
	{
		Invoke ("DieAlone",10);
	}
	
	public void DieAlone ()
	{
		eaten = true;
		gameObject.tag = "Pathogen"; 
		dissolve = 100;
		Phagozytose = this.transform;
	}
	
	public void Clean()
	{
		if(tag=="Marked" && !renderer.isVisible && Random.value < 0.1f) { Destroy(gameObject); }
	}
	public void OnDestroy()
	{
		amountOfPathogens--;
	}

}
