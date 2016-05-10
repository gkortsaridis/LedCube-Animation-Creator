using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class code : MonoBehaviour {

	public Text codeTxt;

	// Use this for initialization
	void Start () {
		codeTxt.text = PlayerPrefs.GetString ("code","ERROR");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
