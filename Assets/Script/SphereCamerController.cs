using UnityEngine;
using System.Collections;

public class SphereCamerController : MonoBehaviour {
	public GameObject Sphere;
	private  Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - Sphere.transform.position;	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = offset + Sphere.transform.position;
	
	}
}
