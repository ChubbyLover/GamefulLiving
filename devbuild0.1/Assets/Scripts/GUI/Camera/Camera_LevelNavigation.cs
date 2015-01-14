using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Camera_LevelNavigation : MonoBehaviour 
{
	public int iTutorial=0;
	public float fLevelMusic=1;
	public float fLevelEffects=1;
	public float fLevelSprecher=1;
	GameObject Navigation;

	public void Start()
	{
		Navigation = GameObject.FindGameObjectWithTag("Navigation");	
		fLevelMusic = Navigation.GetComponent<Audio_Levelmanager>().fLevelMusic;
		fLevelEffects = Navigation.GetComponent<Audio_Levelmanager>().fLevelEffects;
		fLevelSprecher = Navigation.GetComponent<Audio_Levelmanager>().fLevelSprecher;
	}

	public void setiTutorial (int iTutorial)
	{
		this.iTutorial=iTutorial;
	}
	public void CallFunctionfromHelper(int i)
	{
		switch (i)
		{
		case 0: Navigation.GetComponent<Level_Navigator>().ReloadLevel();
				break;
		case 1: Navigation.GetComponent<Level_Navigator>().LoadNextLevel();
				break;
		case 2: Navigation.GetComponent<Level_Navigator>().GotoLevelMenu();
				break;
		case 3: Navigation.GetComponent<Level_Navigator>().LoadMenuLevel();
				break;
		case 4: Navigation.GetComponent<Level_Navigator>().LoadLevel(iTutorial);
				break;
		case 5: Navigation.GetComponent<Level_Navigator>().EndGame();
				break;
		}
	}
	public void LoadLevel (int i)
	{
		//GameObject.Find("Canvas_Loadscreen").GetComponent<Canvas>().enabled=true;
		Application.LoadLevel(i);
		Navigation.GetComponent<Level_Navigator>().setbChanged(true);
	}
	public void RefreshAudioLevels ()
	{
		Navigation.GetComponent<Audio_Levelmanager>().setEffectsLevel(fLevelEffects);
		Navigation.GetComponent<Audio_Levelmanager>().setMusicLevel(fLevelMusic);
		Navigation.GetComponent<Audio_Levelmanager>().setSprecherLevel(fLevelSprecher);
		Navigation.GetComponent<Audio_Levelmanager>().SetAudioLevels();
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
}
