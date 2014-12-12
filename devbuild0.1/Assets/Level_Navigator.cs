using UnityEngine;
using System.Collections;

public class Level_Navigator : MonoBehaviour {

	string sAdditionalInfo;
	bool bChanged = false;
	// Use this for initialization
	void Start () 
	{
		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(bChanged)
		{
			if(sAdditionalInfo=="LevelUebersicht"&&Application.loadedLevel==0)
			{
				GameObject.Find("Canvas_Hauptmenu").GetComponent<Canvas>().enabled=false;
				GameObject.Find("Canvas_LevelUebersicht").GetComponent<Canvas>().enabled=true;
				sAdditionalInfo="";
			}
			GameObject[] Navigators = GameObject.FindGameObjectsWithTag("Navigation");
			foreach(GameObject Navigator in Navigators )
			{
				if(Navigator.GetComponent<Level_Navigator>().bChanged!=true) Destroy(Navigator);
			}
		}
	}
	public void LoadNextLevel()
	{
		Application.LoadLevel(Application.loadedLevel+1);
	}
	public void ReloadLevel()
	{
		Application.LoadLevel(Application.loadedLevel);
	}
	public void LoadMenuLevel()
	{
		Application.LoadLevel(0);
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
}
