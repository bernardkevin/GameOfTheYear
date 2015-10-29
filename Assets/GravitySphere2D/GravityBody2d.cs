using UnityEngine;
using System.Collections;

public class GravityBody2d : MonoBehaviour {
	public GravityAttractor2d attractor;
	public Transform myTransform;

	void Start () {
		GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
		myTransform = transform;
	}
	
	void Update () {
		attractor.Attract(myTransform);
	}

	public void setAttractor(GravityAttractor2d attractor){
		this.attractor = attractor;
	}
}
