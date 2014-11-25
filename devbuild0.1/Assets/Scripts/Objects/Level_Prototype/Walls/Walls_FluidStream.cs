using UnityEngine;
using System.Collections;

public class Walls_FluidStream : MonoBehaviour
{
	float fTimelastPulse;
	float fPulseInterval=2;

	void Start()
	{
		fTimelastPulse=Time.time;
	}
	void OnTriggerStay2D(Collider2D col) 
	{
		if(Time.time>=fTimelastPulse+fPulseInterval)
		{
			float fAccelleration = 5;
			if (col.attachedRigidbody.velocity.magnitude<7)
			{
				col.attachedRigidbody.AddForce(this.collider2D.transform.right * fAccelleration);
			}
		}
	} 
}
