using UnityEngine;
using System.Collections;

public class Water : Building {

	public bool isAdded;

	// Use this for initialization
	void Start () {
		canSet=true;
		name = "SolarPanel";
		placeAvailable = 2;
		isAdded=false;
		state = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if(!isAdded && planet!=null){
			planet.GetComponent<Planet>().AddMaxWater(100);
			isAdded=true;
		}
	}
}
