using UnityEngine;
using System.Collections;

public class Powers_Medicine : MonoBehaviour {

	public float fLifetime=60;
	public int iAntibodytype;
	float fBirthtime;

	Play_Behaviour Cellscript;
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
				Powers_HelperAI AI = Helper.GetComponent<Powers_HelperAI>();
				AI.Pathogens.Clear();
			}
			GameObject.Destroy(coll.gameObject);
			GameObject.Destroy(gameObject);
		}
	}
}
