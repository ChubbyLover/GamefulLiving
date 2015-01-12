using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Icon_DisplayLock : MonoBehaviour {

	Button ParentImageBtn;

	public string sId;

	void Start () 
	{
		CheckInteractable();
	}
	public void CheckInteractable ()
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
