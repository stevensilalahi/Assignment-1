using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour 
{
	private Rigidbody rb; //Rigidbody is the sphere, variable that holds the reference
	//public float speed; //controls the speed of the ball


	private int count;

	public float speed; //public makes it apparent in the inspector and can be readjusted there

	public Text countText; //holds reference to the UI text component
	public Text winText;

	void Start() //called on the first frame of the game
	{
		//returns reference to the Rigidbody if there is one
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";
	}

	void FixedUpdate()
	{
		//grabs input from players through keyboard
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		//Vector3 holds 3 components (to describe a rotation)
		//x,y,z determines the direction of the force we will add to our ball
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical); 

		//addForce adds force to the ball from user input
		rb.AddForce (movement * speed);
	}


	//gets called when player touches OnTrigger Collider
	void OnTriggerEnter(Collider other)
	{
		//gets called everytime player touches PickUp
		if (other.gameObject.CompareTag ("Pick Up")) 
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}
	}

	void SetCountText ()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 9)
		{
			winText.text = "You Win!";
		}
	}

}
