using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Test : MonoBehaviour {

	public void SetText(GameObject GO)
	{
		// acessing text component, via Script
		Text textExt = GO.GetComponent<Text>();
		Text textInt = this.GetComponent<Text>();

		textInt.text=textExt.text;
		//

	}
}
