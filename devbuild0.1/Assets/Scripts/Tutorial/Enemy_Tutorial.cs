using UnityEngine;
using System.Collections;

public class Enemy_Tutorial : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.name=="AntibodyMunition(Clone)"&&col.gameObject.GetComponent<Play_Antibody>().antibodyType == GetComponent<Pathogen_Behaviour>().pathoType)
		{
			Camera.main.GetComponent<Tutorial_CheckButtonsPressed>().Pathogen=true;
		}
	}
}
