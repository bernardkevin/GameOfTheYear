using UnityEngine;
using System.Collections;

public abstract class IA : MonoBehaviour {
	public int state,life,strength;//state 0->free 1->working
	public string id,name;
	public GameObject job;
	public GameObject planet;

	private Vector3 moveDir;
	private float LR,time,lastTime;
	private bool over;

	void Awake(){

	}

	void Start(){
		over = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(state == 0 && planet!=null){
			walk();
		}
	}

	void FixedUpdate(){
		if(Time.time - lastTime < time && state == 0 && planet!=null)
			GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position + (Vector2)transform.TransformDirection(moveDir) * Time.deltaTime);
	}

	void Randomize(){
		LR = Random.Range(-1.0F, 2.0F);
		time = Random.Range(0.0F, 5.0F);
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

	public void getHired(GameObject b){
		job = b;
		state = 1;
	}

	public void getFired(){
		job = null;
		state = 0;
	}

	public void Died(){
		planet.GetComponent<Planet>().RmvBot(gameObject);
		Destroy(gameObject);
	}

	public void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Planet"){
			planet = other.gameObject;
			planet.GetComponent<Planet>().AddBot(gameObject);
			GetComponent<GravityBody2d>().setAttractor(planet.GetComponent<GravityAttractor2d>());
		}
	}

	public void OnTriggerExit2D(Collider2D other){
		if(other.tag == "Planet"){
			planet = null;
			planet.GetComponent<Planet>().RmvBot(gameObject);
			GetComponent<GravityBody2d>().setAttractor(null);
		}
	}

	public void OnMouseDown(){
		CommandScript.selected[0]=gameObject;
		CommandScript.setBotHUD(name,life,state);
	}
}
