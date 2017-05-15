using UnityEngine;
using System.Collections;

public class HeroCard : MonoBehaviour 
{
	public int damage;
	public int souls;
	public int health;
	//public GameObject explosion;

	GameObject gameController;
	GameController controller;
	/*
	void Awake()
	{

	}
	*/
	void Update()
	{
		if (health <= 0) 
		{
			Destroy(gameObject);
		}
	}

	void OnDestroy()
	{
		gameController = GameObject.Find ("GameController");
		controller = gameController.GetComponent<GameController> ();
		controller.souls += souls;
		//Debug.Log (controller.souls);
		//Debug.Log ("hero created " + souls);
		//Instantiate (explosion, transform.position, transform.rotation);

	}

}
