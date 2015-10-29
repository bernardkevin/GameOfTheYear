using UnityEngine;
using System.Collections;

public class MovingCamera : MonoBehaviour {

	public float speed = 1.0f;

	void Update () {
		if(GetComponent<Camera>().orthographicSize>40 && GetComponent<Camera>().orthographicSize<50)
			speed = 6.0f;
		if(GetComponent<Camera>().orthographicSize>30 && GetComponent<Camera>().orthographicSize<40)
			speed = 3.0f;
		if(GetComponent<Camera>().orthographicSize>20 && GetComponent<Camera>().orthographicSize<30)
			speed = 1.5f;
		if(GetComponent<Camera>().orthographicSize>10 && GetComponent<Camera>().orthographicSize<20)
			speed = 1.0f;
		if(GetComponent<Camera>().orthographicSize>5 && GetComponent<Camera>().orthographicSize<10)
			speed = 0.5f;
		if(GetComponent<Camera>().orthographicSize>1 && GetComponent<Camera>().orthographicSize<5)
			speed = 0.3f;
		Move();
		Zoom();
	}

	void Move(){
		if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.UpArrow)){
			transform.Translate(Vector3.up * 0.1f * speed);
		}
		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)){
			transform.Translate(-Vector3.up * 0.1f * speed);
		}
		if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow)){
			transform.Translate(Vector3.left * 0.1f * speed);
		}
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
			transform.Translate(-Vector3.left * 0.1f * speed);
		}
	}

	void Zoom(){
		if (Input.GetAxis("Mouse ScrollWheel")<0 || Input.GetKey(KeyCode.KeypadMinus)){
			if(GetComponent<Camera>().orthographicSize<50){
				GetComponent<Camera>().orthographicSize++;
			}
		}
		if (Input.GetAxis("Mouse ScrollWheel")>0 || Input.GetKey(KeyCode.KeypadPlus)){
			if(GetComponent<Camera>().orthographicSize>1){
				GetComponent<Camera>().orthographicSize--;
			}
		}
	}
}
