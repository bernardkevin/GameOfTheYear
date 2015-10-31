using UnityEngine;
using System.Collections;

public class Farm : Building {
	public float lastTime;

	// Use this for initialization
	void Start () {
		canSet=true;
		name = "Farm";
		placeAvailable = 2;
		lastTime=-1.0f;
		state = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if(lastTime<0 && planet!=null)lastTime=Time.time;
		if(Time.time - lastTime>1.0f && state==1 && planet!=null){
			planet.GetComponent<Planet>().AddFood(1);
			lastTime=Time.time;
		}
	}
}
