using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/**************************************
 * Due to the way the global controller is set up,
 * I could not put these functions inside it.
 * ************************************/
public class ButtonController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SwitchToScene(string scene)
	{
		SceneManager.LoadScene (scene);
	}

	public void SwitchToSimulation()
	{
		SceneManager.LoadScene ("phase1");
		GlobalControl.Instance.savedPlayerData.ResetValuesForPhase1 ();
	}
}
