using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class Button_LevelAccessControl : MonoBehaviour {

	public int iLevelsUnlocked;

	public string[] Levels = new string[] {"Tut1","Tut2","Tut3","Tut4","Tut5","Lvl1","Lvl2","Lvl3","Lvl4"};

	public bool bUpdated=false;
	// Use this for initialization
	void Start () 
	{
	}
	// Update is called once per frame
	void Update () 
	{
		if(Application.loadedLevelName=="GUI_Alpha"&&!bUpdated)
		{
			GameObject[] Levelpanels = GameObject.FindGameObjectsWithTag("GUI_LevelButton");
			
			for(int i=0; i<Levels.Length; i++)
			{
				for(int j=0;j<iLevelsUnlocked+1; j++)
				{
					Icon_DisplayLock Icon =  Levelpanels[i].GetComponentInChildren<Icon_DisplayLock>();
					if (Icon.sId==Levels[j])
					{
						Levelpanels[i].GetComponent<Button>().interactable=true;
						Levelpanels[i].GetComponentInChildren<Icon_DisplayLock>().CheckInteractable();
					}
				}
			}
			bUpdated=true;
		}
	}

	public void  Save()
	{
		BinaryFormatter Formatter = new BinaryFormatter();
		FileStream file = File.Open(Application.persistentDataPath+"/Levels.dat",FileMode.OpenOrCreate);
		LevelAccess la = new LevelAccess(iLevelsUnlocked);

		Formatter.Serialize(file,la);
		file.Close();
	}
	public void  Load()
	{
		//print(Application.persistentDataPath);
		if(File.Exists(Application.persistentDataPath+"/Levels.dat"))
		{
			BinaryFormatter Formatter = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath+"/Levels.dat",FileMode.Open);
			LevelAccess la = Formatter.Deserialize(file) as LevelAccess;

			iLevelsUnlocked = la.iLevelsUnlocked;
		}
	}
	public void Levelfinished(int i)
	{
		bUpdated = false;
		if(i>iLevelsUnlocked) iLevelsUnlocked=i;
		Save ();
	}
}

[Serializable]
class LevelAccess
{
	public int iLevelsUnlocked;

	public LevelAccess(int iLevelsUnlocked)
	{
		this.iLevelsUnlocked = iLevelsUnlocked;
	}
}
