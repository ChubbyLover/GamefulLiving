using UnityEngine;
using System.Collections;

public class GUI_RetractPanel : MonoBehaviour {

	public float time;
	public bool bStart=false;
	private bool bIgnore=false;

	AudioSource AsrcMusic;
	AudioSource Asrc;
	// Use this for initialization
	void Start () {
		AsrcMusic = GameObject.FindGameObjectWithTag("Audio_Music").GetComponent<AudioSource>();
		Asrc = GameObject.FindGameObjectWithTag("Audio_Sprecher").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(bStart&&!bIgnore)
		{
			Invoke("Retract",time);
			bIgnore=true;
		}
	}
	void Retract ()
	{
		bStart=false;
		GetComponent<Animator>().SetTrigger("In");
		AsrcMusic.volume = 0.7f;
		Asrc.Stop();
		Invoke("EnabelNewPanel",2);
	}
	void EnabelNewPanel()
	{
		Camera.main.GetComponent<Tutorial_CheckButtonsPressed>().Panelout=false;
		bStart=false;
	}
}
