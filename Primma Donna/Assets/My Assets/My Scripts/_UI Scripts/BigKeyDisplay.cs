using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigKeyDisplay : MonoBehaviour
{
	public Sprite[] spriteArray;
	public Image[] letterArray;
	public GameObject[] letterBoxArray;

	public int LetterBoxLength
	{
		get
		{
			 return letterBoxArray.Length;
		}
	}

	void Awake()
	{
		foreach (GameObject g in letterBoxArray)
			g.SetActive(false);
	}

	public void prepareForInputAtPosition(int position)
	{
		if (position < LetterBoxLength - 1)
			letterBoxArray[position].SetActive(true);
	}

	public void placeLetterAtPosition(int letterKeyCode, int position)
	{
		letterArray[position].sprite = spriteArray[letterKeyCode];
		letterBoxArray[position].SetActive(true);
	}

	public void clearPosition(int position)
	{
		letterArray[position].sprite = spriteArray[0];
	}

	public void disablePosition(int position)
	{
		if (position < LetterBoxLength)
			letterBoxArray[position].SetActive(false);
	}

	public void clearLetterBox()
	{
		foreach (GameObject g in letterBoxArray)
			g.SetActive(false);
		foreach (Image i in letterArray)
			i.sprite = spriteArray[0];
	}

	public void setStringIntoLetterBox(string str)
	{
		int i = 0;
		foreach (char ch in str.ToLower())
		{
			this.placeLetterAtPosition((int)ch - 96, i++);
		}

		this.prepareForInputAtPosition(i);
	}
}
