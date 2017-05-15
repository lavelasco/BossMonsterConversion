using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour 
{
	public GameObject[] roomCards;
	public GameObject[] heroCards;
	public GameObject[] bossCards;
	public GameObject hand;
	public GameObject heroZone;
	public GameObject bossZone;
	//public GameObject dropZone1;
	//public GameObject dropZone2;
	public GameObject dropZone3;
	public GameObject dropZone4;
	public GameObject dropZone5;
	public GameObject AfterActionPanel;

	public Text phaseText;
	public Text healthText;
	public Text soulsText;
	public Text afterActionText;

	public Button nextPhaseButton;
	public Button deckButton;
	public Button startGameButton;
	public Button mainMenuButton;
	public Button pauseButton;

	//phases for each turn
	//set to true for current phase, false for others
	public bool buildPhase = true;
	//bool baitPhase;
	public bool adventurePhase = false;
	public bool gameOn = true;

	public int health;
	public int souls;
	public int availableRoomSlots = 2;

	void Update()
	{
		CheckHealth ();
		CheckSouls ();
	}

	public void BeginGame()
	{
		startGameButton.gameObject.SetActive (false);
		nextPhaseButton.gameObject.SetActive (true);
		deckButton.gameObject.SetActive (true);
		phaseText.gameObject.SetActive (true);

		GameObject boss = bossCards [Random.Range (0, bossCards.Length)];
		GameObject newBoss = Instantiate (boss) as GameObject;
		newBoss.transform.SetParent (bossZone.transform);
		DrawCard ();
		DrawCard ();
		DrawCard ();
		DrawCard ();
		DrawCard ();
	}

	void Start()
	{

	}

	public void ChangePhase()
	{
		//attached to a button
		/*
		if (buildPhase == true) 
		{
			buildPhase = false;
			baitPhase = true;
			phaseText.text = "Bait Phase";
			deckButton.GetComponent<Button> ().interactable = false;
			//Debug.Log("Bait Phase");
		}
		*/
		if (buildPhase == true)
		{
			buildPhase = false;
			adventurePhase = true;
			phaseText.text = "Adventure Phase";
			SpawnHero();
			deckButton.GetComponent<Button> ().interactable = false;
			//Debug.Log("Adventure Phase");
		}

		else if (adventurePhase == true) 
		{
			adventurePhase = false;
			buildPhase = true;
			phaseText.text = "Build Phase";
			deckButton.GetComponent<Button>().interactable = true;
			OpenRoomSlot();
			//Debug.Log("Build Phase");
		}

		else
		{
			Debug.Log ("Something went wrong");
		}
	}

	public void changeToScene(int sceneToChangeTo)
	{
		Application.LoadLevel (sceneToChangeTo);
	}

	public void DrawCard()
	{
		GameObject room = roomCards [Random.Range (0, roomCards.Length)];
		GameObject newRoom = Instantiate (room) as GameObject;
		newRoom.transform.SetParent(hand.transform);
		deckButton.GetComponent<Button> ().interactable = false;
		//Debug.Log ("room draw");
	}

	public void SpawnHero()
	{
		GameObject hero = heroCards [Random.Range (0, heroCards.Length)];
		GameObject newHero = Instantiate (hero) as GameObject;
		newHero.transform.SetParent (heroZone.transform);
		//Debug.Log ("hero spawn");
	}

	void CheckHealth()
	{
		healthText.text = "Health: " + health;

		if (health <= 0 && gameOn == true) 
		{
			pauseButton.gameObject.SetActive(false);
			AfterActionPanel.gameObject.SetActive(true);
			afterActionText.text = "YOU LOSE";
			gameOn = false;
		}
	}
	
	void CheckSouls()
	{
		soulsText.text = "Souls: " + souls;

		if (souls >= 10 && gameOn == true) 
		{
			pauseButton.gameObject.SetActive(false);
			AfterActionPanel.gameObject.SetActive(true);
			afterActionText.text = "YOU WIN";
			gameOn = false;
		}
	}

	void OpenRoomSlot()
	{
		availableRoomSlots++;
		if (availableRoomSlots == 3) 
		{
			dropZone3.gameObject.SetActive(true);
		} 
		else if (availableRoomSlots == 4) 
		{
			dropZone4.gameObject.SetActive(true);
		} 
		else if (availableRoomSlots == 5) 
		{
			dropZone5.gameObject.SetActive(true);
		} 
		else 
		{
			return;
		}
	}
}
