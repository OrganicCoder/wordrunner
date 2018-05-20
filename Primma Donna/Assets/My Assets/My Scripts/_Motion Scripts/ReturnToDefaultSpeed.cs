using UnityEngine;
using UnityStandardAssets._2D;

public class ReturnToDefaultSpeed : MonoBehaviour
{
	StateSaver savedState;

	void Awake()
	{
		savedState = (GameObject.FindWithTag("StateSaver")).GetComponent(typeof(StateSaver)) as StateSaver;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		savedState.playerHandler.playerController.runSpeed = savedState.defaultRunningSpeed;
	}
}
