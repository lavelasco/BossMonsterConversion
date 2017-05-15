using UnityEngine;
using System.Collections;

public class RoomCard : MonoBehaviour 
{
	public int damage;
	public bool isPlayed = false;

	void Update()
	{
		CheckPlay ();
		CheckPhase ();
		CheckGameStatus ();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "HeroCard") 
		{
			HeroCard heroCard = other.gameObject.GetComponent<HeroCard>();
			heroCard.health -= damage;
			//Debug.Log("hero took " + damage);
			//Debug.Log("hero has " + heroCard.health + " health");
		}

		else 
		{
			return;
		}
	}

	void CheckPlay()
	{
		if (transform.parent.tag == "RoomSlot") 
		{
			isPlayed = true;
			gameObject.GetComponent<Draggable>().enabled = false;
		} 
		
		else 
		{
			return;
		}
	}

	void CheckPhase()
	{
		GameObject gameController = GameObject.Find ("GameController");
		GameController controller = gameController.GetComponent<GameController> ();
		if (controller.buildPhase == false) 
		{
			gameObject.GetComponent<Draggable> ().enabled = false;
		} 

		else 
		{
			gameObject.GetComponent<Draggable> ().enabled = true;
		}
	}

	void CheckGameStatus()
	{
		GameObject gameController = GameObject.Find ("GameController");
		GameController controller = gameController.GetComponent<GameController> ();
		if (controller.gameOn == false) 
		{
			gameObject.GetComponent<Draggable> ().enabled = false;
		}
	}
}
