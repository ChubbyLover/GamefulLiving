using UnityEngine;
using System.Collections;

public class Walls_Vanepressure: MonoBehaviour
{
	float fTimelastPulse;
	float fPulseInterval=4;
	
	void Start()
	{
		fTimelastPulse=Time.time;
	}
	void OnTriggerStay2D(Collider2D col) 
	{
		if(Time.time>=fTimelastPulse+fPulseInterval)
		{
			float fAccelleration = 3;
			if (col.attachedRigidbody.velocity.magnitude<7)
			{
				col.attachedRigidbody.AddForce(this.collider2D.transform.right * fAccelleration);
			}
		}
	} 
}
