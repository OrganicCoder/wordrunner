using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigKeyInput : MonoBehaviour
{
	public delegate void actionIfTrue();
	public BigKeyDisplay display;
	public WordHints hints;

	private string builtInputString;
	private int letterBoxIndex;
	private bool gettingInput;
	private string primaryTarget = "";
	private System.Random rand = new System.Random();

	private int attemptsCount;
	private actionIfTrue thisAction;
	private HashSet<string> targetStrings = new HashSet<string>();

	void Awake()
	{
		letterBoxIndex = 0;
		attemptsCount = 0;
		gettingInput = false;
		builtInputString = "";
		thisAction = youMessedUp;
		targetStrings.Add("test");
	}

	void OnGUI()
	{
		Event e = Event.current;
		if (gettingInput && e.type == EventType.KeyDown)
		{
			if (Input.GetKeyDown(e.keyCode))
			{
				if (isValidInput(e.keyCode))
					addLetterToLetterBox(e.keyCode);
				else if (e.keyCode == KeyCode.Return)
					Debug.Log("The Current Input was: " + builtInputString);
				else if (e.keyCode == KeyCode.Backspace && e.alt)
					resetLetterBox();
				else if (e.keyCode == KeyCode.Backspace)
					deleteLastLetter();

				if (isPassInput())
				{
					thisAction();
				}
			}
		}
	}

	public void enableInputField()
	{
		builtInputString = string.Empty;
		gettingInput = true;
		display.prepareForInputAtPosition(letterBoxIndex);
	}

	public void enableInputField(actionIfTrue a, string target)
	{
		enableInputField(a, new string[] {target});
	}

	public void enableInputField(actionIfTrue a, string[] targets)
	{
		if (primaryTarget == string.Empty)
		{
			int index = rand.Next(0, targets.Length);
			primaryTarget = targets[index];
		}

		enableInputField();
		targetStrings.Clear();
		thisAction = a;

		foreach (string tar in targets)
		{
			targetStrings.Add(tar);
		}
	}

	IEnumerator waitForHint()
	{
		yield return new WaitUntil(() => gettingInput == true);
		display.setStringIntoLetterBox(builtInputString);
	}

	public void displayHint()
	{
		hints.drawLetterHint(attemptsCount,primaryTarget);
		StartCoroutine(waitForHint());
	}

	public void disableInputField()
	{
		display.clearLetterBox();
		letterBoxIndex = 0;
		primaryTarget = string.Empty;
		gettingInput = false;
	}

	public void hangInputField()
	{
		gettingInput = false;
		display.disablePosition(letterBoxIndex);
	}

	public string getBuiltInputString()
	{
		return builtInputString;
	}

	public void incrementAttempts()
	{
		if (attemptsCount < primaryTarget.Length)
			attemptsCount++;
	}

	public void resetAttempts()
	{
		attemptsCount = 0;
	}

	public void lockInput()
	{
		gettingInput = false;
	}

	public void unlockInput()
	{
		gettingInput = true;
	}

	private void addLetterToLetterBox(KeyCode k)
	{
		if (letterBoxIndex < display.LetterBoxLength)
		{
			display.placeLetterAtPosition(keyCodeToInt(k),letterBoxIndex);
			builtInputString += (char)k;
			letterBoxIndex++;
			display.prepareForInputAtPosition(letterBoxIndex);
		}
	}

	private void deleteLastLetter()
	{
		if (letterBoxIndex > 0)
		{
			display.disablePosition(letterBoxIndex);
			letterBoxIndex--;
			display.clearPosition(letterBoxIndex);
			builtInputString = builtInputString.Substring(0,builtInputString.Length-1);
		}
	}

	private void resetLetterBox()
	{
		display.clearLetterBox();
		letterBoxIndex = 0;
		builtInputString = "";
		display.prepareForInputAtPosition(letterBoxIndex);
	}

	private int keyCodeToInt (KeyCode k)
	{
		if (k == KeyCode.Space)
			return 0;
		else
			return (int)k - 96;
	}

	private bool isValidInput(KeyCode k)
	{
		return (k >= KeyCode.A && k <= KeyCode.Z) || k == KeyCode.Space;
	}

	private bool isPassInput()
	{
		return targetStrings.Contains(builtInputString);
	}

	private void youMessedUp()
	{
		Debug.Log("You dun goofed");
	}
}
