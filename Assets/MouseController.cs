using UnityEngine;
using System.Collections;
using System;

public class MouseController : MonoBehaviour {

	public double mX,mY;
	private float x,y;

	public 
	
	// Update is called once per frame
	void FixedUpdate () {
		x = Input.mousePosition.x;
		y = Input.mousePosition.y;

		Vector3 difference = GetComponent<Camera>().ScreenToWorldPoint (new Vector3(x,y,Mathf.Abs(transform.position.z))) - transform.position;

		mX = Math.Ceiling(difference.x + transform.position.x);
		mY = Math.Ceiling(difference.y + transform.position.y);
	}

	void OnGUI(){
		GUI.Box(new Rect(0,0,100,20),"("+mX+";"+mY+")");
	}
}
