using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AudioControl : MonoBehaviour 
{
	AudioSource aSource;

	void Start ()
	{
		aSource = gameObject.GetComponent<AudioSource>();
	}
	public void ChangeVolume(GameObject Go)
	{
		if(Go.GetComponent<Slider>()!=null)
		{
			Slider slider = Go.GetComponent<Slider>();
			aSource.volume=slider.value;
		}
	}
	public void PlaySound()
	{
		aSource.loop=true;
		aSource.Play();

	}
	public void PauseSound()
	{
		aSource.loop=false;
		aSource.Pause();
	}
}
