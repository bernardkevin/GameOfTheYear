using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CommandScript : MonoBehaviour {

	public static GameObject[] selected = new GameObject[3];

	public GameObject BotHUD,BotHUDName,BotHUDLife,BotHUDState;

	public GameObject BuildingHUD,BuildingHUDName,BuildingHUDState,BuildingHUDPlace;

	public GameObject PlanetHUD,PlanetHUDName,PlanetHUDWater,PlanetHUDFood,PlanetHUDOre,PlanetHUDIngot,PlanetHUDEnergy;

	// Update is called once per frame
	void Update () {
		if(selected[0]!=null){
			BotHUD.SetActive(true);
			setBotHUD();
		}
		else BotHUD.SetActive(false);

		if(selected[1]!=null){
			BuildingHUD.SetActive(true);
			setBuildingHUD();
		}
		else BuildingHUD.SetActive(false);

		if(selected[2]!=null){
			PlanetHUD.SetActive(true);
			setPlanetHUD();
		}
		else PlanetHUD.SetActive(false);

		if(Input.GetKeyDown(KeyCode.Mouse1)){
			selected[0]=null;
			selected[1]=null;
			selected[2]=null;
		}
	
	}

	public void setBotHUD(){
		BotHUDName.GetComponent<Text>().text = selected[0].GetComponent<IA>().name;
		BotHUDLife.GetComponent<Text>().text = ""+selected[0].GetComponent<IA>().life;
		BotHUDState.GetComponent<Text>().text = ""+selected[0].GetComponent<IA>().state;
	}

	public void setBuildingHUD(){
		BuildingHUDName.GetComponent<Text>().text = selected[1].GetComponent<Building>().name;
		BuildingHUDState.GetComponent<Text>().text = ""+selected[1].GetComponent<Building>().state;
		BuildingHUDPlace.GetComponent<Text>().text = ""+selected[1].GetComponent<Building>().placeAvailable;
	}

	public void setPlanetHUD(){
		PlanetHUDName.GetComponent<Text>().text = selected[2].GetComponent<Planet>().name;
		PlanetHUDWater.GetComponent<Text>().text = selected[2].GetComponent<Planet>().water;
		PlanetHUDFood.GetComponent<Text>().text = selected[2].GetComponent<Planet>().food;
		PlanetHUDOre.GetComponent<Text>().text = selected[2].GetComponent<Planet>().ore;
		PlanetHUDIngot.GetComponent<Text>().text = selected[2].GetComponent<Planet>().ingot;
		PlanetHUDEnergy.GetComponent<Text>().text = selected[2].GetComponent<Planet>().energy;
	}

	public void AddBuilding(int x){
		if(selected[2]!=null && selected[2].GetComponent<Planet>().nbBot!=0)
			selected[2].GetComponent<Planet>().SelectBuilding(x);
	}
}
