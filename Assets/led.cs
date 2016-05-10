using UnityEngine;
using System.Collections;

public class led : MonoBehaviour {

	public int whichLed;


	// Update is called once per frame
	void Update () {
		//bool[,,] states = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<create>().states;
		//int frame = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<create>().frame;

		bool[,,] states = create.states;
		int frame = create.frame;

		int level =whichLed/25;
		int which = whichLed % 25;
		if (states [level, which, frame]) {
			this.gameObject.GetComponent<Renderer>().material.color = Color.yellow; 
		} else {
			this.gameObject.GetComponent<Renderer>().material.color = Color.grey; 
		}
	}
}

//states -> level , (0-24) , frame