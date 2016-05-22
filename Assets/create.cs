using UnityEngine;
using System.Collections;

public class create : MonoBehaviour {

	private int posx,posy,sizex,sizey,space;
	private int level,maxFrame;
	public static bool[,,] states;
	public static int frame;
	private float vSbarValue;
	public GameObject cube;
	public GameObject marker;
	public float levelZeroY;
	private bool isPlaying;
	private IEnumerator coroutine;

	// Use this for initialization
	void Start () {
		sizex = Screen.width / 20;
		sizey = sizex;
		posx = 2*Screen.width / 3 - Screen.width/20;
		posy = Screen.height / 10;
		space = Screen.width / 80;

		level = 0;
		frame = 0;
		maxFrame = PlayerPrefs.GetInt ("frames",0);

		states = new bool[5,25,maxFrame];

		isPlaying = false;
	}
		
	void Update(){
		cube.transform.rotation = Quaternion.Euler(0, vSbarValue, 0);
		Vector3 temp = marker.transform.position; // copy to an auxiliary variable...
		temp.y = levelZeroY + level * 3;
		marker.transform.position = temp; 


		if (Input.GetKeyUp (KeyCode.Escape))
			Application.LoadLevel ("menu");
	}

	void OnGUI(){

		if (GUI.Button (new Rect (Screen.width / 10, posy, 150, 50), "Load from Clipboard")) {
			loadAnimation ();
		}

		vSbarValue = GUI.HorizontalScrollbar(new Rect(Screen.width/20, Screen.height*14/15, Screen.width/2.5f, Screen.height/30), vSbarValue, 2.0F, 0.0F, 360.0F);

		if (isPlaying)
			GUI.enabled = false;

		if (GUI.Button (new Rect (posx + 0 * sizex + 0 * space, posy, sizex, sizey), "21"))states [level,20,frame] = !states [level,20,frame];
		if(GUI.Button (new Rect(posx+1*sizex+1*space,posy,sizex,sizey),"22"))states[level,21,frame] = !states[level,21,frame];
		if(GUI.Button (new Rect(posx+2*sizex+2*space,posy,sizex,sizey),"23"))states[level,22,frame] = !states[level,22,frame];
		if(GUI.Button (new Rect(posx+3*sizex+3*space,posy,sizex,sizey),"24"))states[level,23,frame] = !states[level,23,frame];
		if(GUI.Button (new Rect(posx+4*sizex+4*space,posy,sizex,sizey),"25"))states[level,24,frame] = !states[level,24,frame];

		if(GUI.Button (new Rect(posx+0*sizex+0*space,posy+1*sizey+1*space,sizex,sizey),"16"))states[level,15,frame] = !states[level,15,frame];
		if(GUI.Button (new Rect(posx+1*sizex+1*space,posy+1*sizey+1*space,sizex,sizey),"17"))states[level,16,frame] = !states[level,16,frame];
		if(GUI.Button (new Rect(posx+2*sizex+2*space,posy+1*sizey+1*space,sizex,sizey),"18"))states[level,17,frame] = !states[level,17,frame];
		if(GUI.Button (new Rect(posx+3*sizex+3*space,posy+1*sizey+1*space,sizex,sizey),"19"))states[level,18,frame] = !states[level,18,frame];
		if(GUI.Button (new Rect(posx+4*sizex+4*space,posy+1*sizey+1*space,sizex,sizey),"20"))states[level,19,frame] = !states[level,19,frame];

		if(GUI.Button (new Rect(posx+0*sizex+0*space,posy+2*sizey+2*space,sizex,sizey),"11"))states[level,10,frame] = !states[level,10,frame];
		if(GUI.Button (new Rect(posx+1*sizex+1*space,posy+2*sizey+2*space,sizex,sizey),"12"))states[level,11,frame] = !states[level,11,frame];
		if(GUI.Button (new Rect(posx+2*sizex+2*space,posy+2*sizey+2*space,sizex,sizey),"13"))states[level,12,frame] = !states[level,12,frame];
		if(GUI.Button (new Rect(posx+3*sizex+3*space,posy+2*sizey+2*space,sizex,sizey),"14"))states[level,13,frame] = !states[level,13,frame];
		if(GUI.Button (new Rect(posx+4*sizex+4*space,posy+2*sizey+2*space,sizex,sizey),"15"))states[level,14,frame] = !states[level,14,frame];

		if(GUI.Button (new Rect(posx+0*sizex+0*space,posy+3*sizey+3*space,sizex,sizey),"6"))states[level,5,frame] = !states[level,5,frame];
		if(GUI.Button (new Rect(posx+1*sizex+1*space,posy+3*sizey+3*space,sizex,sizey),"7"))states[level,6,frame] = !states[level,6,frame];
		if(GUI.Button (new Rect(posx+2*sizex+2*space,posy+3*sizey+3*space,sizex,sizey),"8"))states[level,7,frame] = !states[level,7,frame];
		if(GUI.Button (new Rect(posx+3*sizex+3*space,posy+3*sizey+3*space,sizex,sizey),"9"))states[level,8,frame] = !states[level,8,frame];
		if(GUI.Button (new Rect(posx+4*sizex+4*space,posy+3*sizey+3*space,sizex,sizey),"10"))states[level,9,frame] = !states[level,9,frame];

		if(GUI.Button (new Rect(posx+0*sizex+0*space,posy+4*sizey+4*space,sizex,sizey),"1"))states[level,0,frame] = !states[level,0,frame];
		if(GUI.Button (new Rect(posx+1*sizex+1*space,posy+4*sizey+4*space,sizex,sizey),"2"))states[level,1,frame] = !states[level,1,frame];
		if(GUI.Button (new Rect(posx+2*sizex+2*space,posy+4*sizey+4*space,sizex,sizey),"3"))states[level,2,frame] = !states[level,2,frame];
		if(GUI.Button (new Rect(posx+3*sizex+3*space,posy+4*sizey+4*space,sizex,sizey),"4"))states[level,3,frame] = !states[level,3,frame];
		if(GUI.Button (new Rect(posx+4*sizex+4*space,posy+4*sizey+4*space,sizex,sizey),"5"))states[level,4,frame] = !states[level,4,frame];

		GUIStyle myStyle = new GUIStyle();
		myStyle.fontSize = Screen.width / 50; 	
		myStyle.normal.textColor = Color.black;
		myStyle.alignment = TextAnchor.MiddleCenter;


		if (GUI.Button (new Rect (posx, posy + 5 * sizey + 5 * space, sizex, sizey), "<<")) {
			if (level > 0) {
				level--;
			}
		}

		GUI.Label  (new Rect (posx+sizex+space, posy+5*sizey+5*space, 3*sizex+2*space, sizey), "Level "+level,myStyle);

		if (GUI.Button (new Rect (posx + 4 * sizex + 4 * space, posy + 5 * sizey + 5 * space, sizex, sizey), ">>")) {
			if (level < 4) {
				level++;
			}
		}

		if (GUI.Button (new Rect (posx, posy + 6 * sizey + 6 * space, sizex, sizey), "<<")) {
			if (frame > 0) {
				frame--;
			}
		}
		GUI.Label  (new Rect (posx+sizex+space, posy+6*sizey+6*space, 3*sizex+2*space, sizey), "Frame "+frame+"/"+(maxFrame-1),myStyle);

		if (GUI.Button (new Rect (posx + 4 * sizex + 4 * space, posy + 6 * sizey + 6 * space, sizex, sizey), ">>")) {
			if (frame < (maxFrame-1)) {
				frame++;
			}
		}

		if (GUI.Button (new Rect (posx, posy + 7 * sizey + 7 * space, 5 * sizex + 4 * space, sizey), "GENERATE CODE")) {
			Debug.Log ("GENERATE!");
			string code = "int anim_frames = " + maxFrame+";\n";
			code += "int[anit_frames][125] animation = {";

			for (int fr = 0; fr < maxFrame; fr++) {
				code += "{";
				for (int lev = 0; lev < 5; lev++) {
					for (int l = 0; l < 25; l++) {
						if (l*lev != 96) {
							if (states [lev, l, fr]) {
								code += "1,";
							} else {
								code += "0,";
							}
						} else {
							if (states [lev, l, fr]) {
								code += "1";
							} else {
								code += "0";
							}
						}
					}
				}

				if (fr != maxFrame - 1) {
					code += "},";
				} else {
					code += "}";
				}

			}

			code += "};";
			code = MyEscapeURL(code);

			string t ="mailto:mdasyg@ieee.com?subject=Led%20Cube%20Animation%20code&body="+code;
			Application.OpenURL(t);
		}

		GUI.enabled = true;

		if (!isPlaying) {
			GUI.enabled = true;
		} else {
			GUI.enabled = false;
		}
		if(GUI.Button(new Rect (posx, posy + 8 * sizey + 8 * space, 2.5f * sizex + space, sizey), "Play")){
			coroutine = iterateFrames ();
			StartCoroutine(coroutine);
			isPlaying = true;
		}
		GUI.enabled = true;

		if (isPlaying) {
			GUI.enabled = true;
		} else {
			GUI.enabled = false;
		}
		if(GUI.Button(new Rect (posx + 2.5f * sizex + 3*space, posy + 8 * sizey + 8 * space, 2.5f * sizex + space, sizey), "Pause")){
			StopCoroutine (coroutine);
			isPlaying = false;
			frame = 0;
		}



	}

	string MyEscapeURL (string url)
	{
		return WWW.EscapeURL(url).Replace("+","%20");
	}

	IEnumerator iterateFrames() {
		while (true) {
			for (int i = 0; i < maxFrame; i++) {
				frame = i;
				yield return new WaitForSeconds (0.3f);
			}
		}
	}

	public static bool[,,] getStates(){
		return states;
	}

	public static int getFrame(){
		return frame;
	}

	public void loadAnimation(){
		Debug.Log ("LOAD");
		string code = GUIUtility.systemCopyBuffer;
		Debug.Log (code);
		code = code.Replace ("{","");
		code = code.Replace ("}","");
		code = code.Replace (";","");
		code = code.Replace ("\n","");

		string[] array = code.Split(',');
		if (array.Length % 125 == 0) {
			maxFrame = array.Length/125;

			for (int fr = 0; fr < maxFrame; fr++) {
				for (int lev = 0; lev < 5; lev++) {
					for (int l = 0; l < 25; l++) {
						if (array [fr * 125 + 25 * lev + l] == "1") {
							states [lev, l, fr] = true;
						} else {
							states [lev, l, fr] = false;
						}
					}
				}
			}
		}

	}
		
}
