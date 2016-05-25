using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	private bool quitClicked = false;

	public void ToggleAudio()
	{
		SoundManager.instance.soundPaused = !SoundManager.instance.soundPaused;
		AudioListener.pause = SoundManager.instance.soundPaused;
	}

	public void Restart()
	{
		quitClicked = true;
		//Destroy (GlobalControl.Instance);
		//SceneManager.LoadScene ("start");
	}

	public void OnGUI()
	{
		if (quitClicked) {
			Rect windowRect = new Rect(75, 300, 248, 50);
			windowRect = GUI.Window(0, windowRect, OpenConfirmation, "Are you sure you want to quit?");
		}
	}
	void OpenConfirmation(int windowID) 
	{
		//GUI.Label (new Rect (0, 0, 248, 100), "Are you sure you want to quit?");
		if (GUI.Button (new Rect (10, 20, 100, 20), "Yes")) {
			Destroy (GlobalControl.Instance);
			SceneManager.LoadScene ("start");
			quitClicked = false;
		}
		if (GUI.Button (new Rect (130, 20, 100, 20), "No")) {
			quitClicked = false;
		}
	}
}
