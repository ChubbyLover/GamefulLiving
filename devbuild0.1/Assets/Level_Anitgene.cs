using UnityEngine;
using System.Collections;

public class Level_Anitgene : MonoBehaviour {

	Sprite[] Antigene;
	
	public float TimeStamp;
	public float Livetime; 
	public int iAmmountOfAntigenes=6;
	// Use this for initialization
	void Start () 
	{
		Object[] AntigeneBuffer = Resources.LoadAll("Sprites/Objects/Player/Aura/Antigene");

		Antigene = new Sprite[iAmmountOfAntigenes];
		int iUnevenNumbers =0;
		for(int i = 0; i<iAmmountOfAntigenes;i++)
		{
			if(i%2==1) 
			{
				iUnevenNumbers++;
				Antigene[i-iUnevenNumbers]=AntigeneBuffer[i] as Sprite;
			}
		}
		float TimeStamp= Time.time;
		gameObject.GetComponent<SpriteRenderer>().sprite = Antigene[Random.Range(0,Antigene.Length)] as Sprite;

	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Time.time>TimeStamp+Livetime) Destroy(gameObject);
	}
}
