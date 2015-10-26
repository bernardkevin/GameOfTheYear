using UnityEngine;
using System.Collections;

public class Module : MonoBehaviour {

	public int progressBuild;

	public bool isSet;
	public bool isLinked;

	// Use this for initialization
	void Start () {
		progressBuild = 0;
		isSet = false;
	}

	// Update is called once per frame
	void Update () {
		if(progressBuild == 100){

		}
		else{
			Build();
		}
	}

	public void Build(){
		if(isSet)
			progressBuild++;
	}

	public void OnTriggerStay2D(Collider2D other){isLinked=true;}
	public void OnTriggerExit2D(Collider2D other){isLinked=false;}
	
	public void setIsSet(){isSet = true;}
}
