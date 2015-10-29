using UnityEngine;
using System.Collections;

public class Universe : MonoBehaviour {

	public static readonly int maxPlanet = 10;
	public static readonly int diversity = 10;

	public GameObject[] spawn = new GameObject[maxPlanet];
	public GameObject prefabSpawn;
	public bool[] freeSpawn = new bool[maxPlanet];

	//public float[,] distance = new float[maxPlanet,maxPlanet];

	public GameObject[] prefab = new GameObject[diversity];
	public GameObject[] planets = new GameObject[maxPlanet];
	private int nbPlanet;

	void Awake(){
		nbPlanet = 0;
		for(int i = 0 ; i< maxPlanet ; i++) freeSpawn[i]=true;
		generateAllSpawn();
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

	public void generateAllSpawn(){
		spawn[0] = Instantiate(prefabSpawn,new Vector3( 0.0f, 0.0f, 0.0f),Quaternion.identity) as GameObject;
		spawn[0].transform.parent = gameObject.transform;
		for(int i = 1;i < maxPlanet;i++){
			generateOneSpawn(i);
		}
	}

	public void generateOneSpawn(int i){
		Vector3 RandomPosition;

		do{
			RandomPosition = randomVector3();
		}while(!checkPosition(RandomPosition));

		spawn[i] = Instantiate(prefabSpawn,RandomPosition,Quaternion.identity) as GameObject;
		spawn[i].transform.parent = gameObject.transform;
	}

	public Vector3 randomVector3(){
		int signX = 0;
		int signY = 0;
		while(signX==0){
			signX = (int)Random.Range(-2.0F, 2.0F);
		}
		while(signY==0){
			signY = (int)Random.Range(-2.0F, 2.0F);
		}
		float X = Random.Range(0.0F, 80.0F);
		float Y = Random.Range(0.0F, 80.0F);

		return new Vector3( signX*X, signY*Y, 0.0f);
	}

	public bool checkPosition(Vector3 v){
		bool isEquidistant = true;
		for(int i = 0;i<maxPlanet;i++){
			if(spawn[i]!=null){
				if(Vector3.Distance(spawn[i].transform.position, v) < 30){
					isEquidistant = false;
				}
			}
		}
		return isEquidistant;
	}
}
