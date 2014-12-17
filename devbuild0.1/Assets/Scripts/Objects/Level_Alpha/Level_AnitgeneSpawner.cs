using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level_AnitgeneSpawner : MonoBehaviour {
	
	public GameObject antiGen;
	public float Tickspeed=1;
	float LastTick;
	public List<Sprite> sprites = new List<Sprite>();
	public int iAntigene=0;
	public bool bNoantigene=false;

	// Use this for initialization
	void Start () 
	{
		LastTick=Time.time;
		
		/*Object[] AntigeneBuffer = Resources.LoadAll("Sprites/Objects/Player/Aura/Antigene");
		for(int i=1; i<12; i+=2)
			sprites.Add((Sprite)AntigeneBuffer[i]);*/
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Time.time>LastTick+Tickspeed&&!bNoantigene)
		{
			// antiGen = new GameObject();
			antiGen = Instantiate (Resources.Load("Prefabs/Objects/Player/Antigene/Antigene"),transform.position, transform.rotation) as GameObject;
			int antigeneType = iAntigene;
			antiGen.GetComponent<SpriteRenderer>().sprite = sprites[antigeneType];
			antiGen.GetComponent<Level_Anitgene>().antigeneType = antigeneType;
			antiGen.GetComponent<Level_Anitgene>().Spawner=gameObject;
			LastTick=Time.time;
			Destroy (antiGen, 5.0f);
		}
	}
}
