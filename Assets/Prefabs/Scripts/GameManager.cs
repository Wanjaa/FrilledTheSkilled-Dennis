using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	private Movement PlayerMovement;
	public GameObject Respawn;
	public GameObject Player;
	public int Respawncount;
	public bool Pausing;
	// Use this for initialization
	void Start (){
		Player = GameObject.FindGameObjectWithTag("Player");
		PlayerMovement = new Movement ();
		PlayerMovement = GameObject.FindGameObjectWithTag ("Player").GetComponent<Movement> ();
		Player.transform.position = Respawn.transform.position;
		
		
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerMovement.Life == 0)
		{
			respawn();
		}
		if(Respawncount == 3)
		{
			GameOver();
		}
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Pausing = true;
			Time.timeScale = 0;
		}
	}

	void OnGUI()
	{
	if(Pausing){
		if(GUI.Button(new Rect(Screen.width/2,Screen.height/2,50,50),"Pause"))
			{
				Pausing = false;
				Time.timeScale = 1;
			}
		}
	}
	
	void respawn()
	{
		Debug.Log ("Respawn");
		PlayerMovement.Life = 1;
		Player.transform.position = Respawn.transform.position;
		Respawncount++;
	}
	
	void GameOver()
	{
		Application.LoadLevel (0);
	}
}
