using UnityEngine;
using UnityStandardAssets._2D;

[RequireComponent(typeof (PlatformerCharacter2D))]
public class AutoRunner: MonoBehaviour
{
  PlatformerCharacter2D character;
  StateSaver savedState;
  bool jump;
  public float runSpeed;

  void Awake()
  {
    character = GetComponent<PlatformerCharacter2D>();
    savedState = (GameObject.FindWithTag("StateSaver")).GetComponent(typeof(StateSaver)) as StateSaver;
    runSpeed = savedState.defaultRunningSpeed;
  }

  void FixedUpdate()
  {
    // Pass all parameters to the character control script.
    character.Move(runSpeed, false, jump);
    jump = false;
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "JumpZone")
    {
      runSpeed = .5f;
      jump = true;
    }
  }
}
