using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
	public int Life;
	public float speed = 1.0f;
	public float rayLength = 1.5f;
	public float jumpSpeed = 15.0f;
	public float Slidespeed = 1f;
	public float Resetspeed;
	public AnimationCurve PlayerSpeed;
	public bool isGliding  = false; 
	
	private LayerMask mask = 8;
	private bool canGlide;
	
	public bool isGrounded()
	{
		Vector2 myPos = new Vector2 (this.transform.position.x, this.transform.position.y); // Jump Fixierung 
		return Physics2D.Raycast(myPos, -Vector2.up, rayLength, 1<<mask.value);
	}
	
	void Start()
	{
		Resetspeed = speed;
	}
	
	void FixedUpdate(){
		
		if (Input.GetKey (KeyCode.A)) {
			this.transform.rigidbody2D.velocity = new Vector2(-speed ,this.transform.rigidbody2D.velocity.y ); // Der Spieler bewegt sich nach Links
		} else if (Input.GetKey (KeyCode.D)) {
			this.transform.rigidbody2D.velocity = new Vector2 (speed,this.transform.rigidbody2D.velocity.y ); // Der Spieler bewegt sich nach Rechts 
		} else if(isGrounded()){
			rigidbody2D.velocity = Vector2.zero;
		}
		
		if (isGrounded () == false && Input.GetKey (KeyCode.LeftShift)&& !this.isGliding &&this.transform.rigidbody2D.velocity.y <0.0f) {
			this.transform.rigidbody2D.gravityScale = 0.5f;
			this.isGliding = true;
			//Debug.Log("Gleiten");
			
		}
	//	Debug.Log (rigidbody2D.velocity);
		
		
		if (isGrounded ()) {
			this.transform.rigidbody2D.gravityScale = 2f;
			//Debug.Log("isGrounded");
			isGliding = false ;
			
			if (Input.GetKey (KeyCode.Space)) { // Der Spieler kann mit dem Code Springen
				//Dann verändert sich der Y Wert des Spielers
				this.rigidbody2D.velocity = new Vector3 (0, jumpSpeed, 0);
			}
		} 
	}

	void OnTriggerEnter2D(Collider2D other)
	{
			Debug.Log("ich bin tot");
			Life -= 1;

	}
	
	
}

