using UnityEngine;
using System.Collections;

public class Camera_LevelNavigation : MonoBehaviour 
{
	public void CallFunctionfromHelper(int i)
	{
		switch (i)
		{
		case 0: GameObject.FindGameObjectWithTag("Navigation").GetComponent<Level_Navigator>().ReloadLevel();
				break;
		case 1: GameObject.FindGameObjectWithTag("Navigation").GetComponent<Level_Navigator>().LoadNextLevel();
				break;
		case 2: GameObject.FindGameObjectWithTag("Navigation").GetComponent<Level_Navigator>().GotoLevelMenu();
				break;
		case 3: GameObject.FindGameObjectWithTag("Navigation").GetComponent<Level_Navigator>().LoadMenuLevel();
				break;
		}
	}
	public void LoadLevel (int i)
	{
		Application.LoadLevel(i);
		GameObject.FindGameObjectWithTag("Navigation").GetComponent<Level_Navigator>().setbChanged(true);
	}
}
