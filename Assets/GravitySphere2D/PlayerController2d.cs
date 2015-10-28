using UnityEngine;
using System.Collections;

public class PlayerController2d : MonoBehaviour {
	public float moveSpeed = 5;
	private Vector3 moveDir;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		moveDir = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Jump")).normalized;
	}

	void FixedUpdate(){
		GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position + (Vector2)transform.TransformDirection(moveDir) * moveSpeed * Time.deltaTime);
	}
}
