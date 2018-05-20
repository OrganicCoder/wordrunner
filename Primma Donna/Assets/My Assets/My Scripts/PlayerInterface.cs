using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInterface : MonoBehaviour
{
	public AutoRunner playerController;
	public GameObject thisPlayer;

	public void dontDestroyOnLoad()
	{
		DontDestroyOnLoad(this);
	}
}
