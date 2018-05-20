using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class MainMenuScript : MonoBehaviour
{
	StateSaver savedState;
	public ActionToDo doThis;

	void Awake()
	{
		StartCoroutine(ActivateMenuWithDelay());
	}

	IEnumerator ActivateMenuWithDelay()
	{
		savedState = (GameObject.FindWithTag("StateSaver")).GetComponent(typeof(StateSaver)) as StateSaver;
		yield return new WaitUntil(() => savedState != null);

		if (savedState.debugMode)
		{
			savedState.ui.counterInput.enableInputField(doThis.doThisAction, new string[] {"fire", "cactus", "river", "tree", "shark", "ztest"});
		}
		else
		{
			savedState.ui.counterInput.enableInputField(doThis.doThisAction, new string[] {"start"});
		}
		savedState.ui.toMainMenuDisplay();

		savedState.playerHandler.playerController.runSpeed = 0.0f;
	}
}
