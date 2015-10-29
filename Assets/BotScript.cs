using UnityEngine;
using System.Collections;

public class BotScript : MonoBehaviour {

	public string name;
	public string statut;// free -> working -> dead
	public GameObject planet;

	public float moveSpeed = 1;
	private Vector3 moveDir;
	public int LR;
	public float time,lastTime;
	public bool over;

	// Use this for initialization
	void Start () {
		over=true;
		name = "jean Paul";
		statut = "free";
	}
	
	// Update is called once per frame
	void Update () {
		if(statut == "free"){
			if(Time.time - lastTime < time && !over)
				moveDir = new Vector2(LR,0).normalized;
			else
				Randomize();
		}
	}

	void FixedUpdate(){
		if(Time.time - lastTime < time && statut == "free")
			GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position + (Vector2)transform.TransformDirection(moveDir) * moveSpeed * Time.deltaTime);
	}

	void Randomize(){
		LR = (int)Random.Range(-2.0F, 2.0F);
		time = Random.Range(1.0F, 5.0F);
		lastTime = Time.time;
		over=false;
	}

	void OnMouseOver(){
		if(Input.GetKeyDown(KeyCode.Mouse0)){
			GlobalManagement.Selected[0]=gameObject;
		}
	}
}
