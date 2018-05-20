using System;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities
{
	public static void shuffleList<T>(List<T> l)
	{
		System.Random rng = new System.Random();
		int n = l.Count;

		while (n > 1) {
			n--;
			int k = rng.Next(n + 1);
			T temp = l[k];
			l[k] = l[n];
			l[n] = temp;
		}
	}

	public static string ObstacleToSceneName(string obstacle)
	{
		Debug.Log(obstacle);
		// Assuming obstacle is all lowercase.
		if(obstacle.Equals(obstacle.ToLower()))
		{
			return Char.ToUpper(obstacle[0]).ToString() + obstacle.Substring(1) + " Scene";
		}
		else
		{
			Debug.LogWarning("Obstacle name is not in lowercase format. Returning empty string");
			return "";
		}
	}
}
