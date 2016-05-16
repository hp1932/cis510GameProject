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
		SoundManager.instance.PlaySingle (switchSound);
		SceneManager.LoadScene (scene);

	}

	public void SwitchToSimulation()
	{
		GlobalControl.Instance.savedPlayerData.ResetValuesForPhase1 ();
		SoundManager.instance.PlaySingle (switchSound);
		SceneManager.LoadScene ("phase1");
	}
}
