using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	void OnGUI () {
		if (GUI.Button(new Rect(Screen.width/2.5f+ 20,Screen.height/2-150,100,100),"Spiel Starten")){
			Application.LoadLevel(1);

		}
		if(GUI.Button(new Rect(Screen.width/2.5f + 20,Screen.height/2-30,100,100),"Verlassen"))
		{
			Application.Quit();
		}

	}

	// Use this for initialization
	void Start () {
	
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
