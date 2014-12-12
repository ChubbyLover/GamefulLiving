using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button_LevelAccessControl : MonoBehaviour {

	public int iLevelsUnlocked=0;
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
			
			for(int i=0; i<iLevelsUnlocked; i++)
			{
				Levelpanels[i].GetComponent<Button>().interactable=true;
				Levelpanels[i].GetComponentInChildren<Icon_DisplayLock>().CheckInteractable();
			}
			bUpdated=true;
		}
	}
	public void Levelfinished(int i)
	{
		iLevelsUnlocked=i;
	}
}
