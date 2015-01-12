using UnityEngine;
using System.Collections;

public class pulsate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float miau = 0.5f+(Mathf.Abs(Mathf.Sin((float)Time.frameCount/20f)));
		gameObject.transform.localScale = new Vector3(miau, miau, 1);
	}
}
