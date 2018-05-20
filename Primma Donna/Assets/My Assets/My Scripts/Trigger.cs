using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trigger : MonoBehaviour
{
	public void setAction(ActionToDo action)
	{
		thisAction = action;
	}

	protected ActionToDo thisAction;
}
