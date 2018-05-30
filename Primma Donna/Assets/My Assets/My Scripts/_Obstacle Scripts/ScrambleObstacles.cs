using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets._2D
{
	public class ScrambleObstacles : MonoBehaviour {

		public static Queue<string> GenerateShuffledObstacleQueue()
		{
			Dictionary<string, string[]> dictionary = new Dictionary<string, string[]>();
			Queue<string> shuffledObstacleQueue = new Queue<string>();

			// Return queue if generated.
			if(shuffledObstacleQueue.Count > 0)
			{
				return shuffledObstacleQueue;
			}

			// Get 'obstacle' dictionary.
			dictionary = GenericReader.GetObstacles();

			// Create a list of dictionary keys
			List<string> keys = new List<string>();
			foreach (string key in dictionary.Keys)
			{
				keys.Add(key);
			}

			// Randomly shuffle list of dictionary keys.
			Utilities.shuffleList<string>(keys);

			// Add the shuffled keys to a queue.
			shuffledObstacleQueue = new Queue<string>();
			foreach (string key in keys)
			{
				shuffledObstacleQueue.Enqueue(key);
			}

			return shuffledObstacleQueue;
		}
	}
}
