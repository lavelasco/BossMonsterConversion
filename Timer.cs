using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	public float timeRemaining = 30f;
	// Use this for initialization
	void Start () {
		
	}
	
	void Update () {
		if (timeRemaining > 0) {
			Debug.Log("Waitting..."+timeRemaining);
			timeRemaining -= Time.deltaTime;
			if ( timeRemaining == 0 ) { ChangePhase(); }
		} 
	}
	
	void ChangePhase(){
		
	}
}


