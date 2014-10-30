using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Powers_HelperAI : MonoBehaviour 
{

	public List<GameObject> Pathogens = new List<GameObject>();
    GameObject Closest;
    float fDistance = 200;
	public int iMode=0;
    public float fSpeed;
	public float angle; 
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{

         if (Pathogens.Count != 0)
        {
			gameObject.tag="Helper";
            GetClosestPathogen();

			Quaternion rotation = Quaternion.LookRotation
				(Closest.transform.position - transform.position, transform.TransformDirection(Vector3.up));
			transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);

            rigidbody2D.AddRelativeForce(Vector2.right*-fSpeed);
        }
		else
		{
			gameObject.tag="Stream_Influence";
			Pathogens.Clear();
		}
	}
	void OnTriggerEnter2D (Collider2D coll)
	{
		if(coll.gameObject.tag=="marked")
		{
			Pathogens.Add(coll.gameObject);
		}
	}
	void OnTriggerExit2D (Collider2D coll)
	{
		if(coll.gameObject.tag=="marked")
		{	
			Pathogens.Clear();
		}
	}
	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.gameObject.tag == "marked")
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
    void GetClosestPathogen()
    {
        foreach (GameObject Pathogen in Pathogens)
        {
			if(Pathogen!=null)
			{
	            if (fDistance > Vector3.Distance(Pathogen.transform.position, gameObject.transform.position))
	            {
	                fDistance=Vector3.Distance(Pathogen.transform.position, gameObject.transform.position);
	                Closest=Pathogen;
	            }
			}
			else
			{
				Pathogens.Remove(Pathogen);
			}
        }
    }
}
