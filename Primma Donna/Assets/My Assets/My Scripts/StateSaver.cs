using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace UnityStandardAssets._2D
{
	public class StateSaver : MonoBehaviour
	{
			// Carryover Resources
		public static Queue<string> shuffledObstacleQueue;
		public Color previousSceneBackgroundColor;
		public Color nextSceneBackgroundColor;

			// System Resources
		public Dictionary<String, String[]> obstacleDictionary;
		public ScoreStorage score;
		public UiElements ui; 
		public PlayerInterface playerHandler;

			// Game settings
		public float defaultRunningSpeed = 1.0f;
		public bool debugMode;

		public GameObject player
		{
			get
			{
				return playerHandler.thisPlayer;
			}
		}

		void Start ()
		{
			// Retrieve obstacle dictionary.
			if(obstacleDictionary == null)
			{
				obstacleDictionary = GenericReader.GetObstacles();
				Debug.Log("Updated obstacleDictionary.");
			}

			// Retrieve obstacle queue.
			if(shuffledObstacleQueue == null || shuffledObstacleQueue.Count == 0)
			{
				Debug.Log("shuffledObstacleQueue is empty (or null). Updating...");
				shuffledObstacleQueue = ScrambleObstacles.GenerateShuffledObstacleQueue();
			}
		}

		public static void RescrambleObstacles()
		{
			shuffledObstacleQueue = ScrambleObstacles.GenerateShuffledObstacleQueue();
			Debug.Log("Obstacles Scrambled.");
		}

		public void dontDestroyOnLoad()
		{
			DontDestroyOnLoad(this);
		}
	}
}
