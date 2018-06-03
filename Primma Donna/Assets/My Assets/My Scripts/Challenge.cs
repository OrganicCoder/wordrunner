using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Possible TODO: Make this look better in the editor
public class Challenge : MonoBehaviour
{
	public Trigger startChallengeTrigger;
	public ActionToDo startChallengeAction;

	public Trigger endChallengeTrigger;
	public ActionToDo endChallengeAction;

//	public Trigger onPassTrigger;
//	public ActionToDo passChallengeAction;

//	public Trigger onFailTrigger; // possibly superfluous at the moment?
//	public ActionToDo failChallengeAction;

	void Start()
	{
		if (startChallengeTrigger != null && startChallengeAction != null)
		{
			startChallengeTrigger.setAction(startChallengeAction);
		}

		if (endChallengeTrigger != null && endChallengeAction != null)
		{
			endChallengeTrigger.setAction(endChallengeAction);
		}
/*
		if (onPassTrigger != null && passChallengeAction != null)
		{
			onPassTrigger.setAction(passChallengeAction);
		}

		if (onFailTrigger != null && failChallengeAction != null)
		{
			onFailTrigger.setAction(failChallengeAction);
		}*/ // Maybe don't need any of this, could possibly delete?  If you come accross this later
		// please delete it.  I just forgot to do it myself.
	}
}
