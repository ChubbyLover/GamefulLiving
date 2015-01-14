using UnityEngine;
using System.Collections;

public class TheDuke : MonoBehaviour {
	

	public int[] iAntigenes = new int[5] {0,0,1,4,3};
	public int[] iCollected = new int[5] {0,0,0,0,0};

	public int iElement = 0;

	bool bDuke=false;

	// Use this for initialization
	void Start () 
	{
		InvokeRepeating("CheckForDuke",0,5);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(bDuke)
		{
			print ("The Duke Arrives");
			CancelInvoke();
		}
	}

	void CheckForDuke()
	{

		for(int i=0;i<iCollected.Length;i++)
		{
			if(iAntigenes[i]!=iCollected[i]) bDuke=false;
			else bDuke=true;
		}
	}
}

