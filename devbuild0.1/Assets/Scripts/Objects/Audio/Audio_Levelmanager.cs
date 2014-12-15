using UnityEngine;
using System.Collections;

public class Audio_Levelmanager : MonoBehaviour 
{
	public float fLevelMusic=1;
	public float fLevelEffects=1;
	public float fLevelSprecher=1;

	// Use this for initialization
	void Start () 
	{
	}
	// Update is called once per frame
	void Update () 
	{
	
	}
	public void setMusicLevel (float fLevelMusic)
	{
		this.fLevelMusic=fLevelMusic;
	}
	public void setSprecherLevel (float fLevelSprecher)
	{
		this.fLevelSprecher=fLevelSprecher;
	}
	public void setEffectsLevel (float fLevelEffects)
	{
		this.fLevelEffects=fLevelEffects;
	}
	public float getMusicLevel ()
	{
		return fLevelMusic;
	}
	public float getSprecherLevel ()
	{
		return fLevelSprecher;
	}
	public float getEffectsLevel ()
	{
		return fLevelEffects;
	}
	public void  SetAudioLevels ()
	{
		GameObject[] Effects = GameObject.FindGameObjectsWithTag("Audio_Effects");
		GameObject[] Sprechers = GameObject.FindGameObjectsWithTag("Audio_Sprecher");
		GameObject[] Musics = GameObject.FindGameObjectsWithTag("Audio_Music");

		foreach(GameObject Effect in Effects)
		{
			Effect.GetComponent<AudioSource>().volume = fLevelEffects;
		}
		foreach(GameObject Sprecher in Sprechers)
		{
			Sprecher.GetComponent<AudioSource>().volume = fLevelSprecher;
		}
		foreach(GameObject Music in Musics)
		{
			Music.GetComponent<AudioSource>().volume = fLevelMusic;
		}

	}
}
