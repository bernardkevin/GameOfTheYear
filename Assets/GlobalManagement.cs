using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GlobalManagement : MonoBehaviour {

	public static GameObject[] Selected = new GameObject[2];

	public GameObject BotHUD,BotName,BotStatut;
	public GameObject BuildingHUD,BuildingName,BuildingStatut,BuildingPlace;
	public GameObject InteractHUD;

	// Use this for initialization
	void Start () {
		resetSelected();
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Mouse1))resetSelected();

		if(Selected[0]!=null){BotHUD.SetActive(true);refreshBotPanel();}
		else BotHUD.SetActive(false);
		if(Selected[1]!=null){BuildingHUD.SetActive(true);refreshBuildingPanel();}
		else BuildingHUD.SetActive(false);

		if(Selected[0]!=null && Selected[1]!=null)InteractHUD.SetActive(true);
		else InteractHUD.SetActive(false);
	}

	void resetSelected(){
		Selected[0]=null;
		Selected[1]=null;
	}

	void refreshBotPanel(){
		BotName.GetComponent<Text>().text = Selected[0].GetComponent<BotScript>().name;
		BotStatut.GetComponent<Text>().text = Selected[0].GetComponent<BotScript>().statut;
	}

	void refreshBuildingPanel(){
		BuildingName.GetComponent<Text>().text = Selected[1].GetComponent<Building>().name;
		BuildingStatut.GetComponent<Text>().text = ""+Selected[1].GetComponent<Building>().state;
		BuildingPlace.GetComponent<Text>().text = ""+Selected[1].GetComponent<Building>().placeAvailable;
	}
}
