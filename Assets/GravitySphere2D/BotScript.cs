using UnityEngine;
using System.Collections;

public class BotScript : MonoBehaviour {

	public float moveSpeed = 1;
	private Vector3 moveDir;

	public int LR;
	public float time,lastTime;
	public bool over;

	// Use this for initialization
	void Start () {
		over=true;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time - lastTime < time && !over)
			moveDir = new Vector2(LR,0).normalized;
		else
			Randomize();
	}

	void FixedUpdate(){
		if(Time.time - lastTime < time)
			GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position + (Vector2)transform.TransformDirection(moveDir) * moveSpeed * Time.deltaTime);
	}

	void Randomize(){
		LR = (int)Random.Range(-2.0F, 2.0F);
		time = Random.Range(1.0F, 5.0F);
		over=false;
		lastTime = Time.time;
	}
}
