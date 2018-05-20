using UnityEngine;
using UnityStandardAssets._2D;

public class ReverseRunScript : MonoBehaviour
{
	StateSaver savedState;

	void Awake()
	{
		savedState = (GameObject.FindWithTag("StateSaver")).GetComponent(typeof(StateSaver)) as StateSaver;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			savedState.playerHandler.playerController.runSpeed = -savedState.playerHandler.playerController.runSpeed;
		}
	}
}
