using System;
using UnityEngine;

public class WordBoxGenerator : MonoBehaviour
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
            try
            {
                savedState.ui.counterInput.enableInputField();
            }
            catch (NullReferenceException e)
            {
                Debug.LogError("StateSaver's \"Placeholder\" property may not be set properly. The 'Placeholder' in 'Counter Attack Input' should be dragged into the StateSaver's \"Placeholder\" field.");
                Debug.LogError(e.ToString());
            }
          //  savedState.counterInput.ActivateInputField();
        }
    }
}
