using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Icon_DisplayLock : MonoBehaviour {

	Button ParentImageBtn;

	void Start () 
	{
		ParentImageBtn = gameObject.GetComponentInParent<Button>();

		if(!ParentImageBtn.IsInteractable())
		{
			GetComponent<Image>().enabled=true;
		}
		else
		{
			GetComponent<Image>().enabled=false;
		}
	}
}
