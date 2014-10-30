using UnityEngine;
using System.Collections;

public class FluidStream : MonoBehaviour
{
	float fTimelastPulse;
	float fPulseInterval=1;

	void Start()
	{
		fTimelastPulse=Time.time;
	}
	void OnTriggerStay2D(Collider2D col) 
	{
		if(Time.time>=fTimelastPulse+fPulseInterval)
		{
			float fAccelleration = Random.Range(19.0f,31f);
			if (col.gameObject.tag!="Helper"&&/*col.attachedRigidbody&&col.gameObject.tag=="Stream_Influence"||col.gameObject.tag=="Pathogen"&&*/col.attachedRigidbody.velocity.magnitude<40)
			{
				col.attachedRigidbody.AddForce(this.collider2D.transform.right * fAccelleration);
			}
		}
	} 
}
