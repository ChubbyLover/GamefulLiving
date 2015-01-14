using UnityEngine;
using System.Collections;

public class Level_Navigator : MonoBehaviour {

	public static Level_Navigator Navigation;

	string sAdditionalInfo;
	bool bChanged = false;
	// Use this for initialization

	void Awake()
	{
		if(Navigation == null)
		{
			Navigation=this;
			DontDestroyOnLoad(gameObject);
			gameObject.GetComponent<Button_LevelAccessControl>().Load();
		}
		else if(Navigation != this)
		{
			Destroy(gameObject);
		}
	}
	// Update is called once per frame
	void Update () 
	{
		if(bChanged)
		{
			if(Application.loadedLevel==0)
			{
				if(sAdditionalInfo=="LevelUebersicht")
				{
					GameObject.Find("Canvas_Hauptmenu").GetComponent<Canvas>().enabled=false;
					GameObject.Find("Canvas_Intoranimation").GetComponent<Canvas>().enabled=false;
					GameObject.Find("Canvas_LevelUebersicht").GetComponent<Canvas>().enabled=true;
					gameObject.GetComponent<Button_LevelAccessControl>().bUpdated = false;
					sAdditionalInfo="";
					bChanged=false;
				}
				else
				{
					GameObject.Find("Canvas_Hauptmenu").GetComponent<Canvas>().enabled=true;
					GameObject.Find("Canvas_Intoranimation").GetComponent<Canvas>().enabled=false;
					gameObject.GetComponent<Button_LevelAccessControl>().bUpdated = false;
					bChanged=false;
				}

			}
			GetComponent<Audio_Levelmanager>().SetAudioLevels();

		}
	}
	public void LoadLevel(int i)
	{
		Application.LoadLevel(i);
	}
	public void LoadNextLevel()
	{
		int iNextlevel= Application.loadedLevel+1;
		Application.LoadLevel(iNextlevel);
	}
	public void ReloadLevel()
	{
		Application.LoadLevel(Application.loadedLevel);
	}
	public void LoadMenuLevel()
	{
		Application.LoadLevel(0);
		bChanged = true;
	}
	public void GotoLevelMenu()
	{
		string sAdditionalInfo="LevelUebersicht";
		Application.LoadLevel(0);
		this.sAdditionalInfo=sAdditionalInfo;
		bChanged = true;
	}
	public void setbChanged(bool bChanged)
	{
		this.bChanged=bChanged;
	}
	public void EndGame ()
	{
		Application.Quit();
	}
	void OnApplicationQuit()
	{
		gameObject.GetComponent<Button_LevelAccessControl>().Save();
	}
}
