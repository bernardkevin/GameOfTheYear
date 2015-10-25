using UnityEngine;
using System.Collections;

public class MovingCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Move();
	}

	void Move(){
		if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.UpArrow)){
			transform.Translate(Vector3.up * 0.05f);		}
		else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)){
			transform.Translate(-Vector3.up * 0.05f);
		}
		else if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow)){
			transform.Translate(Vector3.left * 0.05f);
		}
		else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
			transform.Translate(-Vector3.left * 0.05f);
		}
	}
}
