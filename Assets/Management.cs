using UnityEngine;
using System.Collections;

public class Management : MonoBehaviour {

	public float maxEnergy,maxWater,maxOxygenLevel,maxFood,maxMetal;
	public float curEnergy,curWater,curOxygenLevel,curFood,curMetal;
	
	public GameObject[] blocs = new GameObject[10];
	public int idSelected;
	public GameObject selected;

	public GameObject[] station = new GameObject[10];

	// Use this for initialization
	void Start () {
		setIdSelected(-1);
	}
	
	// Update is called once per frame
	void Update () {





		if(selected!=null){ // build Mode
			selected.transform.parent = transform;
			selected.transform.localPosition = new Vector3((float)MouseController.mX,(float)MouseController.mY,0.0f);
			if(Input.GetKey(KeyCode.Mouse0)){
				if(selected.GetComponent<Module>().collide == false){
					selected=null;
				}
			}
			if(Input.GetKey(KeyCode.Mouse1) || idSelected == -1){
				Destroy(selected);
				setIdSelected(-1);
			}
		}
	}

	public void setIdSelected(int id){
		idSelected = id;
		if(id!=-1){
			selected=blocs[idSelected];
			if(id!=null){
				selected = Instantiate(blocs[idSelected], Vector3.zero, Quaternion.identity) as GameObject;
			}
		}
	}

	void OnGUI(){
		GUI.Box(new Rect(Screen.width-110,0,100,20),"");
	}
}