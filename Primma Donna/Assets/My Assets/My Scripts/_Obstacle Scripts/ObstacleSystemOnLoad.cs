using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class ObstacleSystemOnLoad : MonoBehaviour
{
	StateSaver savedState;

	void Awake()
	{
		savedState = (GameObject.FindWithTag("StateSaver")).GetComponent(typeof(StateSaver)) as StateSaver;
		GameObject playerStartPoint = GameObject.FindWithTag("PlayerStart");
		savedState.player.transform.SetPositionAndRotation(playerStartPoint.transform.position, playerStartPoint.transform.rotation);
	}
}
