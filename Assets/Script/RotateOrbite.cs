using UnityEngine;
using System.Collections;

public class RotateOrbite : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Rotate(Vector3.forward * 10 * Time.deltaTime);
	}
}
