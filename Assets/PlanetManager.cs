using UnityEngine;
using System.Collections;

public class PlanetManager : MonoBehaviour {

	public GameObject canvasBuild;
	private bool isCanvasActive;

	public GameObject[] building;
	public GameObject buildingSelected;
	public int id;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(isCanvasActive)canvasBuild.SetActive(true);
		else canvasBuild.SetActive(false);


		if(Input.GetKeyDown(KeyCode.Mouse1))isCanvasActive=false;
	}

	void OnMouseOver(){
		if(Input.GetKeyDown(KeyCode.Mouse0)){
			isCanvasActive=true;
		}
	}

	void SelectBuilding(int x){
		if(x>0 && x>building.Length)
			buildingSelected=building[x];
	}

/*
	void AddBuilding(){
		public static double mX,mY;
		private float x,y;

		x = Input.mousePosition.x;
		y = Input.mousePosition.y;

		Vector3 difference = GetComponent<Camera>().ScreenToWorldPoint (new Vector3(x,y,Mathf.Abs(transform.position.z))) - transform.position;

		mX = Math.Ceiling(difference.x + transform.position.x);
		mY = Math.Ceiling(difference.y + transform.position.y);
	}
	*/
}
