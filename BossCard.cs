using UnityEngine;
using System.Collections;

public class BossCard : MonoBehaviour 
{
	GameObject gameController;
	GameController controller;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "HeroCard") 
		{
			HeroCard heroCard = other.gameObject.GetComponent<HeroCard> ();
			gameController = GameObject.Find ("GameController");
			controller = gameController.GetComponent<GameController> ();
			controller.health -= heroCard.damage;
			controller.souls -= heroCard.souls;
			//Debug.Log ("hero did " + heroCard.damage + " damage");
			//Debug.Log ("player has " + controller.health + " health left");
			Destroy(other.gameObject);
		}
		else 
		{
			return;
		}
	}
}
