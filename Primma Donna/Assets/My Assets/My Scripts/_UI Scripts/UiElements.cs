using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UiElements : MonoBehaviour
{
	public Text optionsText;
	public Text titleText;
	public Text scoreText;
	public BigKeyInput counterInput;

	void Awake ()
	{
		this.toGameDisplay();
	}

	public void toMainMenuDisplay()
	{
		optionsText.enabled = true;
		titleText.enabled = true;
		scoreText.enabled = false;
	}

	public void toGameDisplay()
	{
		optionsText.enabled = false;
		titleText.enabled = false;
		scoreText.enabled = true;
	}

	public void dontDestroyOnLoad()
	{
		DontDestroyOnLoad(this);
	}
}
