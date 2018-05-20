using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndWordChallenge : MonoBehaviour
{
	public ActionToDo thisAction;

	private bool passedChallenge;

	void Awake()
	{
		passedChallenge = false;
	}

	// pretty big refactor is necessary
	// want to add "Do this on Pass"
	// "Do this on Fail"
	// "Do this when true"
	// "Do this when false"
	// May want to make up multiple kinds of actions?
	// Maybe ones for passing through stuff and ones for other conditions?
	// not sure?
	void OnTriggerEnter2D(Collider2D other)
  {

  }
}
