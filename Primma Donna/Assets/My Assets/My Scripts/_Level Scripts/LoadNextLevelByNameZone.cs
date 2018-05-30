using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets._2D;

namespace UnityStandardAssets._2D
{
	public class LoadNextLevelByNameZone : MonoBehaviour
	{
		StateSaver savedState;
		public string levelName;

		void Awake() // I'll fix this sloppy mess later, I swear!
		{
			savedState = (GameObject.FindWithTag("StateSaver")).GetComponent(typeof(StateSaver)) as StateSaver;
		}

		void OnTriggerEnter2D(Collider2D other)
		{
			if (other.tag == "Player")
			{
				// Shuffle Obstacle Scenes, except "Limbo Scene"
				if(!levelName.Equals("Limbo Scene"))
				{
					if(StateSaver.shuffledObstacleQueue.Count > 0)
					{
						string nextSceneName = StateSaver.shuffledObstacleQueue.Dequeue();
						levelName = Utilities.ObstacleToSceneName(nextSceneName);
						// Debug.Log("Converted '" + nextSceneName + "' to '" + levelName + "'.");
					}
					else
					{
						Debug.Log("The length of the shuffledObstacleQueue is 0. Shuffling...");
						StateSaver.RescrambleObstacles();
					}
				}

				// TODO: Check if the loaded scene is a valid scene by using the following command:
				//		 SceneManager.GetSceneByName(levelName).IsValid()

				savedState.ui.dontDestroyOnLoad();
				savedState.dontDestroyOnLoad();
				savedState.playerHandler.dontDestroyOnLoad();
				SceneManager.LoadScene(levelName, LoadSceneMode.Single);
			}
		}
	}
}
