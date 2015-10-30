using UnityEngine;
using System.Collections;

public abstract class Building : MonoBehaviour {
	public GameObject planet;
	public string name;
	public int life,progressBuild,placeAvailable,state,maxPlace;//state 0->OFF 1->ON
	public bool isFull,isBuild;
	public GameObject[] employes;

	public void Start(){
		isBuild = false;
	}


	public void Update(){
		if(planet != null){
			if(!isBuild){
				Build();
			}
		}
	}

	public void Build(){
		progressBuild++;
		if(progressBuild==100)isBuild = true;
	}
/*
	public int HireEmploye(){
		Order();
		int i = 0;
		bool findPlace = false;
		while(i < employes.Length && !isFull && !findPlace){
			if(employes[i]==null)findPlace = true;
			else i++;
		}
		if(!findPlace)i=-1;
		return i;
	}

	public void Order(){
		for(int i = 0;i<employes.Length;i++){
			if(employes[i]==null){
				employes[i]=employes[i+1];
				employes[i+1]=null;
			}
		}
		if(employes[employes.Length-1] != null) isFull = true;
	}

	public void Destroy(){
		for(int i = 0;i<employes.Length;i++)
			employes[i].getFired();
		Destroy(gameObject);
	}
*/
	public void OnMouseDown(){
		CommandScript.selected[1]=gameObject;
		CommandScript.setBuildingHUD(name,life,state);
	}
}
