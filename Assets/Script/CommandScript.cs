using UnityEngine;
using System.Collections;

public class CommandScript : MonoBehaviour {

	public static GameObject[] selected = new GameObject[3];
	public GameObject PlanetHUD,BotHUD,BuildingHUD;
	public static bool showPlanetHUD,showBotHUD,showBuildingHUD;

	// Update is called once per frame
	void Update () {
		if(showPlanetHUD) PlanetHUD.SetActive(true);
		else PlanetHUD.SetActive(false);

		if(showBotHUD) BotHUD.SetActive(true);
		else BotHUD.SetActive(false);

		if(showBuildingHUD) BuildingHUD.SetActive(true);
		else BuildingHUD.SetActive(false);

		if(Input.GetKeyDown(KeyCode.Mouse1)){
			showPlanetHUD = false;
			showBotHUD = false;
			showBuildingHUD = false;
			selected[0]=null;
			selected[1]=null;
		}

		if(selected[0]!=null)showBotHUD = true;
		if(selected[1]!=null)showBuildingHUD = true;
	
	}

	public static void setBotHUD(string name,int life,int state){
		
	}

	public static void setBuildingHUD(string name,int life,int state){
		
	}

	public static void setPlanetHUD(string name,int maxOre,int maxFood,int maxEnergy,
												int curOre,int curFood,int curEnergy,
												int regOre,int regFood,int regEnergy,
												float sunLevel,float windLevel){
		
	}

	public void AddBuilding(int x){
		if(selected[2]!=null && selected[2].GetComponent<Planet>().nbBot!=0)
			selected[2].GetComponent<Planet>().SelectBuilding(x);
	}
}
