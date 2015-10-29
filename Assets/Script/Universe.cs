using UnityEngine;
using System.Collections;

public class Universe : MonoBehaviour {

	public static readonly int maxPlanet = 10;
	public static readonly int diversity = 10;

	public GameObject[] spawn = new GameObject[maxPlanet];
	public bool[] freeSpawn = new bool[maxPlanet];

	public GameObject[] prefab = new GameObject[diversity];
	public GameObject[] planets = new GameObject[maxPlanet];
	private int nbPlanet;

	void Awake(){
		nbPlanet = 0;
		for(int i = 0 ; i< maxPlanet ; i++) freeSpawn[i]=true;
		spawn = GameObject.FindGameObjectsWithTag("Spawn");
	}

	void Start(){
		for(int i = 00 ; i < maxPlanet ; i++)
			AddPlanet(i);
	}

	void AddPlanet(int i){
		if(freeSpawn[i]){
			planets[nbPlanet] = Instantiate(prefab[0],spawn[i].transform.position,spawn[i].transform.rotation) as GameObject;
			freeSpawn[i] = false;

			planets[nbPlanet].transform.parent = gameObject.transform;
			planets[nbPlanet].GetComponent<Planet>().id = "0"+i;
			nbPlanet++;
		}
	}
}
