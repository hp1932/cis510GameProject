using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/**************************************
 * Due to the way the global controller is set up,
 * I could not put these functions inside it.
 * ************************************/
public class ButtonController : MonoBehaviour {
	public AudioClip switchSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SwitchToScene(string scene)
	{
		//reset time scale
		Time.timeScale = 1.0f;
		SoundManager.instance.PlaySingle (switchSound);
		SceneManager.LoadScene (scene);

	}

	/********************************
	 * Purpose: Speed up moveSpeed and 
	 * 			arrival speed
	 * 			Called byt button in phase 1
	 * ******************************/
	public void ForwardFast()
	{
		Time.timeScale = 8.0f;
	}


	public void SwitchToSimulation()
	{
		GlobalControl.Instance.savedPlayerData.ResetValuesForPhase1 ();
		GlobalControl.Instance.savedPlayerData.updateNumCustomers ();
		SoundManager.instance.PlaySingle (switchSound);
		SceneManager.LoadScene ("phase1");
	}
}
