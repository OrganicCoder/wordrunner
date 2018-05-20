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

	public Trigger onPassTrigger;
	public ActionToDo passChallengeAction;

	public Trigger onFailTrigger; // possibly superfluous at the moment?
	public ActionToDo failChallengeAction;

	void Start()
	{
		if (startChallengeTrigger != null)
		{
			startChallengeTrigger.setAction(startChallengeAction);
		}

		if (endChallengeTrigger != null)
		{
			endChallengeTrigger.setAction(endChallengeAction);
		}

		if (onPassTrigger != null)
		{
			onPassTrigger.setAction(passChallengeAction);
		}

		if (onFailTrigger != null)
		{
			onFailTrigger.setAction(failChallengeAction);
		}
	}
}
