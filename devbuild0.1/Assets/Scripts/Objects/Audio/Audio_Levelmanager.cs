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
		DontDestroyOnLoad(gameObject);
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
}
