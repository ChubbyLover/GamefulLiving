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
			if(sAdditionalInfo=="LevelUebersicht"&&Application.loadedLevelName=="GUI_Alpha")
			{
				GameObject.Find("Canvas_LevelUebersicht").GetComponent<Canvas>().enabled=true;
				GameObject.Find("Canvas_Hauptmenu").GetComponent<Canvas>().enabled=false;
				GameObject[] Navigators = GameObject.FindGameObjectsWithTag("Navigation");
				foreach(GameObject Navigator in Navigators )
				{
					if(Navigator.GetComponent<Level_Navigator>().bChanged!=true) Destroy(Navigator);
				}
			}
		}
	}
	public void ChangeLevel(bool Next)
	{
		Application.LoadLevel(Application.loadedLevel+1);
	}
	public void ChangeLevel()
	{
		Application.LoadLevel(Application.loadedLevel);
	}
	public void ChangeLevel(int i)
	{
		Application.LoadLevel(i);
	}
	public void ChangeLevel(string sAdditionalInfo)
	{
		Application.LoadLevel("GUI_Alpha");
		this.sAdditionalInfo=sAdditionalInfo;
		bChanged = true;
	}
}
