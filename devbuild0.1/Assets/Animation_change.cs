using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Animation_change : MonoBehaviour {

	public Canvas Current;
	public Canvas Next;

	public bool change=false;
	public bool changed=false;

	public void Update()
	{
		if(!changed&&change) Change();
	}

	public void Change()
	{
		Current.enabled=false;
		Next.enabled=true;
		changed = true;
	}
}
