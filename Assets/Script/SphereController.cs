using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SphereController : MonoBehaviour {
	Rigidbody body;
	public Canvas retry;
	public static int score=0;
	public Camera cam;
	public Text textScore;
	private const float  BASE_SPEED=0.5f;
	private Vector3 sp;
	public static bool endGame=false;
	public GameObject stair;
	public Text highText;
	public GameObject destroyedTail;

	// Use this for initialization
	void Start () {
		score = 0;
		body = GetComponent<Rigidbody> ();
		endGame = false;
		sp = new Vector3 (0f, 0f, BASE_SPEED);
		textScore.text = score.ToString ();

	}
	
	// Update is called once per frame
	void Update () {
			
		if ((!endGame) && (stair.transform.GetChild (stair.transform.childCount - 1).position.y > transform.position.y + 0.3))
			EndGame ();
		if (!endGame) { 
			sp = new Vector3 (0f, 0f, BASE_SPEED + ((score / 10f)*0.2f));
		}
		
	}
	public void OnCollisionEnter(Collision other)
	{ 
		if (other.gameObject.tag == "fixed") {
			score++;
			textScore.text = score.ToString ();
		} else if((other.gameObject.tag == "moving")&&(!endGame))
		{
			other.rigidbody.useGravity = true;
			EndGame ();

		}
		if (!endGame && other.gameObject.tag != "moving")
			gameObject.GetComponent <Rigidbody> ().velocity = sp;
		
	

	}
	public void EndGame(){
		endGame = true;
		int s = PlayerPrefs.GetInt ("HighScore");
		if (score > s)
			PlayerPrefs.SetInt ("HighScore", score);
		
		highText.text=PlayerPrefs.GetInt("HighScore").ToString ();
		retry.gameObject.SetActive (true);

	} 

	public void OnCollisionExit(Collision other)
	{ 	
		Transform tr = other.transform;
		GameObject o=(GameObject)Instantiate (destroyedTail,other.transform.position,other.transform.rotation);
		Color desiredColor =other.gameObject.GetComponent<Renderer> ().material.GetColor("_Color");

		for (int j = 0; j <5; j++) {
			for (int k = 0; k < 2; k++) {
				for (int l = 0; l < 5; l++) {
					o.transform.GetChild (j).GetChild (k).GetChild (l).gameObject.GetComponent<Renderer> ().material.color = desiredColor;

				}
			}
		}
		Vector3 desiredScale = o.transform.localScale;
		desiredScale.z = tr.localScale.z / 2f;
		o.transform.localScale =desiredScale;
		Destroy (other.gameObject);
		Destroy (o,3f);




}
}
