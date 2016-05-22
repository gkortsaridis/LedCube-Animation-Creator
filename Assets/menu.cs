using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class menu : MonoBehaviour {

	public Button start;
	public InputField frames;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.Escape))
			Application.Quit ();
	}

	public void startCreate(){
		
		try {
			int framesNum = System.Int32.Parse(frames.text); 
			if(framesNum > 0 && framesNum < 26){
				PlayerPrefs.SetInt("frames",framesNum);
				Application.LoadLevel("create");
			}
		} catch (System.FormatException e) {

		}
	}

	public void OnGUI(){
		if (GUI.Button (new Rect (Screen.width-100,Screen.height-100,100,100), "About")) {
			Application.LoadLevel ("about");
		}
	}
}
