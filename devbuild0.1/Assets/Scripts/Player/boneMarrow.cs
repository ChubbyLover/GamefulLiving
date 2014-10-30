using UnityEngine;
using System.Collections;

public class boneMarrow : MonoBehaviour {

	public int timeUntilGeneration;
	void Start () {
		timeUntilGeneration = Random.Range(10,50);
	}
	
	// Update is called once per frame
	void Update () {
		timeUntilGeneration--;
		if(timeUntilGeneration < 0)
		{
			GameObject newCell = (GameObject) Instantiate(Resources.Load("cell"), transform.position, transform.rotation); 
			newCell.rigidbody2D.AddForce(new Vector2(Random.value*50-25,Random.value*50-25));
			timeUntilGeneration = Random.Range(10,50);
		}
	}
}
