using UnityEngine;
using System.Collections;

public class Controller : Module {

	// Use this for initialization
	void Start () {
		isBuild = true;
		progressBuild = 100;
		
		name="controller";

		nameObj.GetComponent<TextMesh>().text = name;
		integrityObj.GetComponent<TextMesh>().text = (int)integrity+"/100";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
