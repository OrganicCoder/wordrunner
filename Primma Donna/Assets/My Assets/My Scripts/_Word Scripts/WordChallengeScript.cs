using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class WordChallengeScript : MonoBehaviour
	{
		public delegate void actionIfTrue();

		ObstacleType thisObstacle;
		StateSaver savedState;
		private bool isFirstTime;

		public ActionToDo thisAction;

		void Awake()
		{
			isFirstTime = false;
			thisObstacle = gameObject.transform.parent.GetComponent(typeof(ObstacleType)) as ObstacleType;
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
				savedState.ui.counterInput.enableInputField(thisAction.doThisOnTrue, savedState.obstacleDictionary[thisObstacle.ObstacleName]);
				savedState.ui.counterInput.displayHint();
			}
		}
	}
