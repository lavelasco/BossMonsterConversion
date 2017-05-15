using UnityEngine;
using System.Collections;

public class RandomGenerator : MonoBehaviour {

	public GameObject[] cards; //these sprites are dragged and dropped into the array from the inspector. The sprites should be prefabs
	
	public float spawnFrequency = 1;
	float spawnTimer = 0;
	
	void Update()
	{
		spawnTimer += Time.deltaTime;
		if (spawnTimer >= spawnFrequency)
		{
			SpawnCard();
			spawnTimer = 0;
		}
	}
	
	public void SpawnCard()
	{
		//int random; //add a random value from 0 to 3 into this value
		//GameObject s = Instantiate (sprites[random] as GameObject);
		//then set the postion of s wherever you want it to start
		//s.transform.position = ;
		//GameObject card = cards [Random.Range (0, cards.Length)];
	}
}
