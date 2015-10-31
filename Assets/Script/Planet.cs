using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour {
	public string id;
	public string name;

	private int curWater,maxWater;
	public string water;

	private int curFood,maxFood;
	public string food;

	private int curOre,maxOre;
	public string ore;

	private int curIngot,maxIngot;
	public string ingot;

	private int curEnergy,maxEnergy;
	public string energy;

	public float sunLevel,windLevel;

	public int nbBot;
	public GameObject[] bots = new GameObject[20];
	public GameObject[] buildings = new GameObject[10];


	private int nbBuilding;
	public GameObject buildingSelected;
	public GameObject[] prefabBuilding;

	private GameObject cam;
	private int rotationOffSet = -90;
	private float x,y,rotZ;

	// Use this for initialization
	void Awake () {
		name = "Groot";

		maxWater = 10;
		maxFood = 10;
		maxOre = 10;
		maxIngot = 10;
		maxEnergy = 10;

		sunLevel = 1.2f;
		windLevel = 1.2f;

		cam = GameObject.FindWithTag("MainCamera") as GameObject;
		nbBot = 0;
		nbBuilding = 0;

		buildings = new GameObject[10];

		for(int i = 0 ; i < bots.Length;i++)bots[i]=null;
		for(int i = 0 ; i < buildings.Length;i++)buildings[i]=null;
	}
	
	// Update is called once per frame
	void Update () {

		water = "water :"+curWater+"/"+maxWater;
		food = "food :"+curFood+"/"+maxFood;
		ore = "ore :"+curOre+"/"+maxOre;
		ingot = "ingot :"+curIngot+"/"+maxIngot;
		energy = "energy :"+curEnergy+"/"+maxEnergy;



		if(buildingSelected != null){
			AddBuilding();
			buildingSelected.transform.rotation = Quaternion.Euler (0f, 0f, rotZ + rotationOffSet);
			if(Input.GetKeyDown(KeyCode.Mouse0) && buildingSelected.GetComponent<Building>().canSet){
				buildingSelected.transform.parent = gameObject.transform;
				buildings[nbBuilding] = buildingSelected;
				buildings[nbBuilding].GetComponent<Building>().planet = gameObject;
				nbBuilding++;
				SelectBuilding(-1);
			}
			if(Input.GetKeyDown(KeyCode.Mouse1)){
				Destroy(buildingSelected);
				SelectBuilding(-1);
			}
		}
	
	}

	public void AddWater(int x){
		curWater = curWater+x;
		if(curWater>maxWater){
			curWater = maxWater;
		}
	}

	public void AddMaxWater(int x){
		maxWater+=x;
	}

	public void AddFood(int x){
		curFood = curFood+x;
		if(curFood>maxFood){
			curFood = maxFood;
		}
	}

	public void AddOres(int x){
		curOre = curOre+x;
		if(curOre>maxOre){
			curOre = maxOre;
		}
	}

	public void AddSolarEnergy(int x){
		curEnergy = curEnergy + (int)(x*sunLevel);
		if(curEnergy>maxEnergy){
			curEnergy = maxEnergy;
		}
	}

	public void AddWindEnergy(int x){
		curEnergy = curEnergy + (int)(x*windLevel);
		if(curEnergy>maxEnergy){
			curEnergy = maxEnergy;
		}
	}

	public void SelectBuilding(int x){
		if(x>=0 && x<prefabBuilding.Length){
			buildingSelected = Instantiate(prefabBuilding[x],transform.position,Quaternion.Euler (0f, 0f, rotZ + rotationOffSet)) as GameObject;
		}
		else buildingSelected = null;
	}

	public void AddBuilding(){
		x = Input.mousePosition.x;
		y = Input.mousePosition.y;

		Vector3 difference = cam.GetComponent<Camera>().ScreenToWorldPoint (new Vector3(x,y,Mathf.Abs(cam.transform.position.z))) - transform.position;

		difference.Normalize ();
		rotZ = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;
	}

	public void AddBot(GameObject that){
		OrderBot();
		bots[nbBot]=that;
		that.GetComponent<IA>().id = id+"0"+nbBot;
		that.transform.parent = gameObject.transform;
		nbBot++;
	}

	public void RmvBot(GameObject that){
		bots[nbBot]=that;
		nbBot++;
		OrderBot();
	}

	public void OrderBot(){
		for(int i = 0;i<bots.Length;i++){
			if(bots[i]==null && i<bots.Length-1){
				bots[i]=bots[i+1];
				//bots[i].GetComponent<IA>().id=bots[i+1].GetComponent<IA>().id;
				bots[i+1]=null;
			}
		}
	}

	public void OnMouseDown(){
		CommandScript.selected[2]=gameObject;
	}
}
