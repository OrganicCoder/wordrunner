using System.Collections;
using UnityEngine;

public class MorphObject : MonoBehaviour
{
    Vector3 endPosition = new Vector3(0, 0, 0);  //End Of Obstacle target point

    public GameObject counterObject;
    public GameObject endOfObstacle;
    float speed = 8f;

    bool isDone;
    float speedSlide;

    void Start()
    {
        speedSlide = speed * Time.fixedDeltaTime;
        Debug.Log(counterObject.name);
        endPosition = endOfObstacle.transform.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(SlideObstacle());
        }
    }

    void Update()
    {
        if (isDone)
        {
            SlideIt();
        }
    }

    IEnumerator SlideObstacle()
    {
        isDone = true;
        yield return new WaitForSeconds(4.5f);
        isDone = false;
    }

    void SlideIt()
    {
        counterObject.transform.position = Vector3.MoveTowards(counterObject.transform.position, endPosition, speedSlide);
    }
}
