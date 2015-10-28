using UnityEngine;
using System.Collections;

public class Module : MonoBehaviour {
	public string name;
	public float integrity;
	public GameObject nameObj,integrityObj;


	protected bool isBuild;
	public int progressBuild;

	protected bool isLinked;
	public bool isSet,collide;

	// Use this for initialization
	void Awake () {
		progressBuild = 0;
		isSet = false;
		collide = false;
	}

	// Update is called once per frame
	void Update () {
		collide = false;

		if(!isBuild){
			Building();
		}
		else{

		}
	}



	public void Building ()	{
		if(progressBuild<100){
			progressBuild++;
		}
		else{
			isBuild = true;
			integrity = 100;
		}
	}

	public void OnTriggerStay2D(Collider2D other){isLinked=true;}
	public void OnTriggerExit2D(Collider2D other){isLinked=false;}

	public void OnCollisionStay2D(Collision2D other){collide=true;}
	public void OnCollisionExit2D(Collision2D other){collide=false;}
}
