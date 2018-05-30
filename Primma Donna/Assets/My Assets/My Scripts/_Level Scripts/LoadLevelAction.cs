using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets._2D;

public class LoadLevelAction : ActionToDo
{
	StateSaver savedState;

	void Awake()
	{
		savedState = (GameObject.FindWithTag("StateSaver")).GetComponent(typeof(StateSaver)) as StateSaver;
	}

	public override void doThisOnTrue()
	{
		savedState.playerHandler.playerController.runSpeed = 1.0f;
		savedState.defaultRunningSpeed = 1.0f;
		savedState.ui.counterInput.disableInputField();
		savedState.ui.toGameDisplay();
		if (savedState.debugMode)
		{
			string debugLevel = savedState.ui.counterInput.getBuiltInputString();
			savedState.dontDestroyOnLoad();
			savedState.ui.dontDestroyOnLoad();
			savedState.playerHandler.dontDestroyOnLoad();
			SceneManager.LoadScene(Utilities.ObstacleToSceneName(debugLevel), LoadSceneMode.Single);
		}
		else
		{
			SceneManager.LoadScene("Words Scene v0.0005", LoadSceneMode.Single);
		}
	}
}
