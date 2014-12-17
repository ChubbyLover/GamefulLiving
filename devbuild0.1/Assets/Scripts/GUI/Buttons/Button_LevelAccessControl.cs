using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class Button_LevelAccessControl : MonoBehaviour {

	public int iLevelsUnlocked=0;
	public bool bUpdated=false;
	// Use this for initialization
	void Start () 
	{
		// bUpdated=false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.K))
		{
			iLevelsUnlocked=3;
			bUpdated=false;
		}
		if(Application.loadedLevelName=="GUI_Alpha"&&!bUpdated)
		{
			GameObject[] Levelpanels = GameObject.FindGameObjectsWithTag("GUI_LevelButton");
			
			for(int i=0; i<iLevelsUnlocked; i++)
			{
				Levelpanels[i].GetComponent<Button>().interactable=true;
				Levelpanels[i].GetComponentInChildren<Icon_DisplayLock>().CheckInteractable();
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
		print ("miau");
		bUpdated = false;
		iLevelsUnlocked=i;
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
