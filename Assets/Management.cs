using UnityEngine;
using System.Collections;

public class Management : MonoBehaviour {

	public int energie,water,oxygenLevel;

	public GameObject[] blocs = new GameObject[10];
	public int idSelected;
	public GameObject selected;

	// Use this for initialization
	void Start () {
		setIdSelected(-1);
	}
	
	// Update is called once per frame
	void Update () {
		if(selected!=null){
			selected.transform.parent = transform;
			selected.transform.localPosition = new Vector3((float)MouseController.mX,(float)MouseController.mY,0.0f);
			if(Input.GetKey(KeyCode.Mouse0)){
				if(selected.GetComponent<Module>().isLinked == true){
					selected.GetComponent<Module>().setIsSet();
					selected=null;
				}
			}
			if(Input.GetKey(KeyCode.Mouse1)){
				Destroy(selected);
				setIdSelected(-1);
			}
		}
	}

	public void setIdSelected(int id){
		if(id!=-1){
			idSelected = id;
			selected=blocs[idSelected];
			if(id!=null){
				selected = Instantiate(blocs[idSelected], Vector3.zero, Quaternion.identity) as GameObject;
			}
		}
	}

	void OnGUI(){
		GUI.Box(new Rect(0,0,100,20),"("+MouseController.mX+";"+MouseController.mY+")");
	}
}