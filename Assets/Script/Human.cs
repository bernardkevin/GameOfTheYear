using UnityEngine;
using System.Collections;

public class Human : IA {

	void Start () {
		name = GenerateName();
		life = 100;
		strength = 10;
		state = 0;
	}


	string GenerateName(){
		string[] names = new string[]{"Neil","Paul","Michel","Eugène","Teddy","John","Vincent"};
		int rand1 = (int)Random.Range(0.0F, names.Length);
		string[] surnames = new string[]{"Smith","Armstrong","Elric","Houston","Martin","Dupont","Aslamov"};
		int rand2 = (int)Random.Range(0.0F, names.Length);
		return names[rand1]+" "+surnames[rand2];
	}
}
