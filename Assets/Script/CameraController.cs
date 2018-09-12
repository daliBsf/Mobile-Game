using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	private Vector3 desiredPosition;
	public GameObject stair;
	// Update is called once per frame

	void Start()
	{ 
		
	}

	void Update () {
		Camera.main.orthographicSize = (14.6f / Screen.width * Screen.height / 2f );
		//el condition elle5ra zedtha bch el camera ma twa5ach felloul ;
		if (!SphereController.endGame&&( StairController.tailNumber > 6)&&!(stair.transform.GetChild (stair.transform.childCount - 2).localPosition.z<6f)) {
			GameObject tail = stair.transform.GetChild (stair.transform.childCount - 2).gameObject;
			desiredPosition = stair.transform.TransformPoint (tail.transform.localPosition);
			desiredPosition.x = 9.99f;
			desiredPosition.y += 3.2f;
			desiredPosition.z += 5f;
			transform.position = Vector3.Lerp (transform.position,desiredPosition, 2 * Time.deltaTime);
		}
	
	}

}
