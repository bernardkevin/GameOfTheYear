using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour {
	public string id;
	public int ore,food,energy;
	public float sunLevel,windLevel;
	public GameObject[] bots;

	public GameObject[] buildings;
	public int nbBuilding;
	public GameObject buildingSelected;
	public GameObject[] prefabBuilding;

	public GameObject cam;
	private int rotationOffSet = -90;
	private float x,y,rotZ;

	public bool showBuildMode;//affichage du HUD de construction
	public GameObject buildMode;//affichage du HUD de construction

	// Use this for initialization
	void Awake () {

		cam = GameObject.FindWithTag("MainCamera") as GameObject;

		nbBuilding = 0;
		bots = new GameObject[10];
		buildings = new GameObject[10];
		//prefabBuilding = new GameObject[10];
		for(int i = 0 ; i < bots.Length;i++)bots[i]=null;
		for(int i = 0 ; i < buildings.Length;i++)buildings[i]=null;
	}
	
	// Update is called once per frame
	void Update () {
		if(showBuildMode) buildMode.SetActive(true);
		else buildMode.SetActive(false);

		if(Input.GetKeyDown(KeyCode.Mouse1))showBuildMode = false;

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

	public void Order(){
		for(int i = 0;i<bots.Length;i++){
			if(bots[i]==null){
				bots[i]=bots[i+1];
				bots[i+1]=null;
			}
		}
	}

	public void OnMouseDown(){
		showBuildMode = true;
	}
}
