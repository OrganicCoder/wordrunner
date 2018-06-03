using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassFailZoneTrigger : Trigger
{
	ActionToDo thisAction;

	private bool pass = false;

	public void succeed()
	{
		pass = true;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			if (pass)
				thisAction.doThisAction();
		}
	}
}
