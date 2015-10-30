using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour {
	public string id;
	public string name;

	public int maxOre,maxFood,maxEnergy;
	public int curOre,curFood,curEnergy;
	public int regOre,regFood,regEnergy;

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
		cam = GameObject.FindWithTag("MainCamera") as GameObject;
		nbBot = 0;
		nbBuilding = 0;

		buildings = new GameObject[10];

		for(int i = 0 ; i < bots.Length;i++)bots[i]=null;
		for(int i = 0 ; i < buildings.Length;i++)buildings[i]=null;
	}
	
	// Update is called once per frame
	void Update () {
		if(buildingSelected != null){
			AddBuilding();
			buildingSelected.transform.rotation = Quaternion.Euler (0f, 0f, rotZ + rotationOffSet);
			if(Input.GetKeyDown(KeyCode.Mouse0)){
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

	public void SelectBuilding(int x){
		if(x>=0 && x<prefabBuilding.Length){
			buildingSelected = Instantiate(prefabBuilding[x],transform.position,Quaternion.Euler (0f, 0f, rotZ + rotationOffSet)) as GameObject;
		}
		else buildingSelected = null;
	}

	void AddBuilding(){
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
		CommandScript.showPlanetHUD = true;
		CommandScript.setPlanetHUD(name,maxOre,maxFood,maxEnergy,curOre,curFood,curEnergy,regOre,regFood,regEnergy,sunLevel,windLevel);
	}
}
