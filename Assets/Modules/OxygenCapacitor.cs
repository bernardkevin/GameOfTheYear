using UnityEngine;
using System.Collections;

public class OxygenCapacitor : Module {
// Use this for initialization
	void Start () {
		progressBuild = 100;
		
		name="OxygenCapacitor";

		nameObj.GetComponent<TextMesh>().text = name;
		integrityObj.GetComponent<TextMesh>().text = (int)integrity+"/100";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
