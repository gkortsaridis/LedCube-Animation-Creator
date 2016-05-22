using UnityEngine;
using System.Collections;

public class about : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void Update () {
		if (Input.GetKeyUp (KeyCode.Escape))
			Application.LoadLevel("menu");
	}
}
