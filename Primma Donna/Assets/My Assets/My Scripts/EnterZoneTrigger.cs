using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterZoneTrigger : Trigger
{
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			thisAction.doThisAction();
		}
	}
}
