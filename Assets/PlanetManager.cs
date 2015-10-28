using UnityEngine;
using System.Collections;

public class PlanetManager : MonoBehaviour {

	public GameObject canvasBuild;
	private bool isCanvasActive;

	public GameObject[] building = new GameObject[10];
	public GameObject buildingSelected;

	public GameObject cam;
	private int rotationOffSet = -90;
	private float x,y,rotZ;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		AddBuilding();
		if(isCanvasActive)canvasBuild.SetActive(true);
		else canvasBuild.SetActive(false);


		if(Input.GetKeyDown(KeyCode.Mouse1))isCanvasActive=false;

		if(buildingSelected != null){
			buildingSelected.transform.rotation = Quaternion.Euler (0f, 0f, rotZ + rotationOffSet);
			if(Input.GetKeyDown(KeyCode.Mouse0)){
				SelectBuilding(-1);
			}
		}
	}

	void OnMouseOver(){
		if(Input.GetKeyDown(KeyCode.Mouse0)){
			isCanvasActive=true;
		}
	}

	public void SelectBuilding(int x){
		if(x>=0 && x<building.Length){
			buildingSelected = Instantiate(building[x],transform.position,Quaternion.Euler (0f, 0f, rotZ + rotationOffSet)) as GameObject;
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
}
