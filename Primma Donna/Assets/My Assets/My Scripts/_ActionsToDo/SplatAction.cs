using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class SplatAction : ActionToDo
{
	StateSaver savedState;
	
	void Awake()
	{
		StartCoroutine(LoadStateSaver());
	}

	// From interface ActionToDo
	public override void doThisOnTrue()
	{
		savedState.ui.counterInput.hangInputField();
	}

	private IEnumerator LoadStateSaver()
	{
		savedState = (GameObject.FindWithTag("StateSaver")).GetComponent(typeof(StateSaver)) as StateSaver;
		yield return new WaitUntil(() => savedState != null);
	}
}
