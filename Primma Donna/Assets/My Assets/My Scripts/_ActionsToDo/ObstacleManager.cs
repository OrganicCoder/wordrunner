using System.Collections;
using UnityEngine;
using UnityStandardAssets._2D;

public class ObstacleManager : ActionToDo
{
  GameObject obstacle;
  GameObject counterObject;
  GameObject targetPoint;
  StateSaver savedState;

  private bool failedChallenge;

  void Awake()
  {
    StartCoroutine(LoadStateSaverAndDependants());
    obstacle = GameObject.FindWithTag("Obstacle");
    counterObject = GameObject.FindWithTag("Counter");
    targetPoint = GameObject.FindWithTag("RestartPoint");
    counterObject.SetActive(false);
    failedChallenge = true;
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "Player" && failedChallenge)
    {
      savedState.ui.counterInput.incrementAttempts();
      savedState.player.transform.SetPositionAndRotation(targetPoint.transform.position, targetPoint.transform.rotation);
      savedState.ui.counterInput.disableInputField();
      savedState.score.failedChallenge();
    }
    if (other.tag == "Player" && !failedChallenge)
    {
      savedState.score.passedChallenge();
      savedState.ui.scoreText.text = "Score: " + savedState.score.score;
      clearObstacle();
    }
  }


  public override void doThisAction()
  {
    savedState.ui.counterInput.hangInputField();
    failedChallenge = false;
  }

  public void clearObstacle()
  {
    StartCoroutine(WaitFor());
    savedState.ui.counterInput.disableInputField();
  }

  IEnumerator WaitFor()
  {
    counterObject.SetActive(true);
    yield return new WaitForSeconds(0.5f);
    counterObject.SetActive(false);
    obstacle.SetActive(false);
  }

  IEnumerator LoadStateSaverAndDependants()
  {
    yield return StartCoroutine(LoadStateSaver());

    ObstacleType thisObstacle = gameObject.transform.parent.GetComponent(typeof(ObstacleType)) as ObstacleType;
    yield return new WaitUntil(() => thisObstacle != null);

    // TODO: Improve scoring logic for multiple words. (https://trello.com/c/N5kTTiPQ/104-improve-scoring-logic-for-multiple-words)
    savedState.score.setScoreFromWord(savedState.obstacleDictionary[thisObstacle.ObstacleName][0]);
  }

  private IEnumerator LoadStateSaver()
  {
    savedState = (GameObject.FindWithTag("StateSaver")).GetComponent(typeof(StateSaver)) as StateSaver;
    yield return new WaitUntil(() => savedState != null);
  }
}
