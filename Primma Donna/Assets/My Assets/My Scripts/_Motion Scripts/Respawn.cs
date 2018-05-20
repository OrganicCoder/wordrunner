using UnityEngine;

public class Respawn : MonoBehaviour
{
	public GameObject moveObject;
	public GameObject targetPoint;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			moveObject.transform.SetPositionAndRotation(targetPoint.transform.position, targetPoint.transform.rotation);
		}
	}
}
