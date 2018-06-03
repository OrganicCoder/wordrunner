using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLookingForInput : ActionToDo
{
	private StateSaver savedState;

	void Awake()
	{
		StartCoroutine(LoadStateSaver());
	}

	public override void doThisAction()
	{
		
	}

	private IEnumerator LoadStateSaver()
	{
		savedState = (GameObject.FindWithTag("StateSaver")).GetComponent(typeof(StateSaver)) as StateSaver;
		yield return new WaitUntil(() => savedState != null);
	}
}
