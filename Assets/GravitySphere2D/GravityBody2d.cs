using UnityEngine;
using System.Collections;

public class GravityBody2d : MonoBehaviour {

	//public GameObject Planet;
	public GravityAttractor2d attractor;
	public Transform myTransform;

	void Start () {
		//attractor = Planet.GetComponent<GravityAttractor>();
		GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
		//GetComponent<Rigidbody2D>().useGravity = false;
		myTransform = transform;
	}
	
	void Update () {
		attractor.Attract(myTransform);
	}
}
