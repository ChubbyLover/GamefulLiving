using UnityEngine;
using System.Collections;

public class Level_Anitgene : MonoBehaviour {
	
	public float TimeStamp;
	public float Livetime; 
	//public int iAmmountOfAntigenes=6;
	public int antigeneType;

	public GameObject Spawner;
	// Use this for initialization
	void Start () 
	{
		
		
		/*Antigene = new Sprite[iAmmountOfAntigenes];
		int iUnevenNumbers =0;
		for(int i = 0; i<iAmmountOfAntigenes;i++)
		{
			if(i%2==1) 
			{
				iUnevenNumbers++;
				Antigene[i-iUnevenNumbers]=AntigeneBuffer[i] as Sprite;
			}
		}
		
		antigeneType = Random.Range(0,Antigene.Length);
		gameObject.GetComponent<SpriteRenderer>().sprite = Antigene[antigeneType] as Sprite;*/
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	void OnDestroy()
	{
		Spawner.GetComponent<Level_AnitgeneSpawner>().bNoantigene=true;
	}
}
