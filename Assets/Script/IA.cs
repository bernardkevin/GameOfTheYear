using UnityEngine;
using System.Collections;

public abstract class IA : MonoBehaviour {
	public int id,state,life,strenght;//state 0->free 1->working
	public string name;
	public Building job;
	public Planet planet;

	private Vector3 moveDir;
	public float LR,time,lastTime;
	public bool over;

	void Awake(){
		// set planet
		planet = gameObject.transform.parent.gameObject.GetComponent<Planet>();
		GetComponent<GravityBody2d>().setAttractor(gameObject.transform.parent.gameObject.GetComponent<GravityAttractor2d>());

	}

	void Start(){
		over = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(state == 0){
			walk();
		}
	}

	void FixedUpdate(){
		if(Time.time - lastTime < time && state == 0)
			GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position + (Vector2)transform.TransformDirection(moveDir) * Time.deltaTime);
	}

	void Randomize(){
		LR = Random.Range(-1.0F, 1.0F);
		time = Random.Range(1.0F, 5.0F);
		lastTime = Time.time;
		over=false;
	}

	public void walk(){
		if(Time.time - lastTime < time && !over)
			moveDir = new Vector2(LR,0).normalized;
		else
			Randomize();
	}

	public void work(){}

	public void Attack(){}

	public void getHired(Building b){
		job = b;
		state = 1;
	}

	public void getFired(){
		job = null;
		state = 0;
	}

	public void Died(){
		Destroy(gameObject);
	}

	public void OnMouseDown(){
		
	}
}
