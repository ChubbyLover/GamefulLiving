using UnityEngine;
using System.Collections;

public class Syringe : MonoBehaviour {

	public int iDose;
	public bool set=false;
	public bool selfdestruct=false;
	public int iAntibodytype;
	public GameObject Spawn;
	GameObject Medicine;

	float fTimer=0.2f;
	float fTime;

	Animator anim;

	private int i=0;
	// Use this for initialization
	void Start () 
	{
		fTime=Time.time;
		Medicine = Resources.Load("Prefabs/Medicine")as GameObject;
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(selfdestruct)
		{
			Destroy(gameObject.transform.parent.gameObject);
		}
		if(set)
		{
			if(i<iDose&&Time.time>fTime+fTimer)
			{
				GameObject clone = Instantiate(Medicine,Spawn.transform.position,Spawn.transform.rotation) as GameObject;
				Syringe_Medicine med = clone.GetComponent<Syringe_Medicine>();
				med.iAntibodytype=iAntibodytype;
				i++;
			}
			if(i>=iDose)
			{
				set=false;
				anim.SetTrigger("PullOut");
			}

		}
	}
}
