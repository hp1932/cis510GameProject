using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	public void ToggleAudio()
	{
		SoundManager.instance.soundPaused = !SoundManager.instance.soundPaused;
		AudioListener.pause = SoundManager.instance.soundPaused;
	}

	public void Restart()
	{
		Destroy (GlobalControl.Instance);
		SceneManager.LoadScene ("phase1");
	}
}
