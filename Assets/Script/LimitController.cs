using UnityEngine;
using System.Collections;

public class LimitController : MonoBehaviour {
	private Vector3 offset;
	public Camera cam;


	// Use this for initialization
	void Start () {
		offset = transform.position - cam.transform.position;
		
		
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = cam.transform.position + offset;
	
	}
	public void OnTriggerExit(Collider other)
	{  if (other.gameObject.tag=="moving")
		{
		Vector3 desiredPosition = transform.GetChild (0).position;
		desiredPosition.y = other.transform.position.y;
		other.gameObject.transform.position = desiredPosition;
		}


	}


}
