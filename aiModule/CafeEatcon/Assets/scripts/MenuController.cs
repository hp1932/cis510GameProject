using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {
	public static MenuController instance = null;


	public void ToggleAudio()
	{
		SoundManager.instance.soundPaused = !SoundManager.instance.soundPaused;
		AudioListener.pause = SoundManager.instance.soundPaused;
	}
}
