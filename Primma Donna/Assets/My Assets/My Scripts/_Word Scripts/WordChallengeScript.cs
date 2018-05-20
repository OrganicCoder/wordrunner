using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

// Refactor to StartWordChallenge?
public class WordChallengeScript : MonoBehaviour
{
	public delegate void actionIfTrue();

	StateSaver savedState;
	private bool isFirstTime;

	public ActionToDo thisAction;
	public ObstacleType thisObstacle;

	void Awake()
	{
		isFirstTime = false;
		savedState = (GameObject.FindWithTag("StateSaver")).GetComponent(typeof(StateSaver)) as StateSaver;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			if (!isFirstTime)
			{
				isFirstTime = true;
				savedState.ui.counterInput.resetAttempts();
			}
			savedState.ui.counterInput.enableInputField(thisAction.doThisAction, savedState.obstacleDictionary[thisObstacle.ObstacleName]);
			savedState.ui.counterInput.displayHint();
		}
	}
}
