using UnityEngine;
using System.Collections;

public class DestroyStair : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnCollisionExit(Collision other)
	{ Rigidbody rigidBody=other.gameObject.GetComponent <Rigidbody>();
		Collider collider=other.gameObject.GetComponent <Collider>();

		rigidBody.isKinematic = false;
		rigidBody.useGravity = true;
		collider.isTrigger = true;

		
	}
}
