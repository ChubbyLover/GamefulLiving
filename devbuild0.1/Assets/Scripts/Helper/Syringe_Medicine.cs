using UnityEngine;
using System.Collections;

public class Syringe_Medicine : MonoBehaviour {

	public float fLifetime=60;
	public int iAntibodytype;
	float fBirthtime;

	cell Cellscript;
	// Use this for initialization
	void Start () 
	{
		fBirthtime=Time.time;	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Time.time>fBirthtime+fLifetime) Destroy(gameObject);
	}
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "pathogen"+iAntibodytype.ToString())
		{
			GameObject[] Helpers =  GameObject.FindGameObjectsWithTag("Helper");
			foreach(GameObject Helper in Helpers)
			{
				Helper_AI AI = Helper.GetComponent<Helper_AI>();
				AI.Pathogens.Clear();
			}
			GameObject.Destroy(coll.gameObject);
			GameObject.Destroy(gameObject);
		}
	}
}
