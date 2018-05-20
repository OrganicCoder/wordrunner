using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WordHints : MonoBehaviour
{
	public BigKeyDisplay display;
	public BigKeyInput inputController;

	public void drawLetterHint(int numOfLetters, string hintWord)
	{
		StartCoroutine(hintDrawCoroutine(numOfLetters, hintWord));
	}

	private IEnumerator hintDrawCoroutine(int numOfLetters, string hintWord)
	{
		inputController.lockInput();
		List<int> l = Enumerable.Range(0, hintWord.Length).ToList();
		Utilities.shuffleList<int>(l);
		Queue<int> q = new Queue<int>(l);

		while (numOfLetters < q.Count)
		{
			q.Dequeue();
		}

		foreach (int i in q)
		{
			display.placeLetterAtPosition((int)hintWord[i]-96, i);
			yield return new WaitForSeconds(0.15f);
		}

		display.clearLetterBox();
		inputController.unlockInput();
	}
}
