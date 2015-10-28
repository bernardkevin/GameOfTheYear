﻿using UnityEngine;
using System.Collections;

public class GravityAttractor2d : MonoBehaviour {

	public float gravity = 1;

	public void Attract(Transform body){
		Vector3 gravityUp = (body.position - transform.position).normalized;
		Vector3 bodyUp = body.up;

		body.GetComponent<Rigidbody2D>().AddForce(gravityUp * gravity);
		Quaternion targetRotation = Quaternion.FromToRotation(bodyUp,gravityUp) * body.rotation;
		body.rotation = Quaternion.Slerp(body.rotation,targetRotation,50 * Time.deltaTime);
	}

}
