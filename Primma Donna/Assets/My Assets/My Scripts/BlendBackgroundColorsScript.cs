using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendBackgroundColorsScript : MonoBehaviour
{
	// StateSaver savedState;
	Color currentSceneBackgroundColor;
	Color nextSceneBackgroundColor;
	Dictionary<string, Color> colorDictionary;
	Camera mainCamera;
	float duration = 1;
	float lerpTime = 0; // lerp control variable

	void Start ()
	{
		colorDictionary = GenericReader.GetBackgroundColorDictionary();

		// Next scene
		string nextScene = String.Empty;

		if(StateSaver.shuffledObstacleQueue.Count <= 0){
			StateSaver.RescrambleObstacles();
		}

		nextScene = StateSaver.shuffledObstacleQueue.Peek();
		// Debug.Log("Next Scene: " + nextScene);

		// Update background color
		if(colorDictionary == null)
		{
			Debug.LogError("Oh boy, we've got a null dictionary");
		}
		else if(colorDictionary.ContainsKey(nextScene))
		{
			nextSceneBackgroundColor = colorDictionary[nextScene];
			// Debug.Log("Found background color for next scene '" + nextScene + "' (" + nextSceneBackgroundColor + ")");
		}
		else
		{
			Debug.LogWarning("No background color entry for scene '" + nextScene + "'");
		}

		mainCamera = Camera.main;

		// Get the current scene color
		currentSceneBackgroundColor = mainCamera.backgroundColor;
	}

	void Update ()
	{
		mainCamera.backgroundColor = Color.Lerp(currentSceneBackgroundColor, nextSceneBackgroundColor, lerpTime);
		if (lerpTime < 1){ // while t below the end limit...
			// increment it at the desired rate every update:
			lerpTime += Time.deltaTime/duration;
		}
	}
}
