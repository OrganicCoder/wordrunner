using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreStorage : MonoBehaviour
{
	public int score { get; set;}
	private int addScore = 10;

	void Awake ()
	{
		score = 0;
	}

	public void setScoreFromWord(string str)
	{
		addScore = str.Length * 10;
	}

	public void failedChallenge()
	{
		if (addScore > 1)
			addScore = addScore == 10 ? 1 : addScore - 10;
	}

	public void passedChallenge()
	{
		score += addScore;
	}
}
