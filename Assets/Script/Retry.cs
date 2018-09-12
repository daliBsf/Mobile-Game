using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	public void RetryGame()
	{	SceneManager.UnloadScene ( SceneManager.GetActiveScene ());
		SceneManager.LoadScene ("Game");

	}

	// Update is called once per frame
	void Update () {
	
	}
}
