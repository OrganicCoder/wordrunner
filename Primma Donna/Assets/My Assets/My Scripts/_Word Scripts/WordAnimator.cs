using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets._2D;

public class WordAnimator : MonoBehaviour
{
    //accept dictionary of words with their associated definition & example sentence
    public UnityEngine.UI.Text wordText;
    public UnityEngine.UI.Text definition;
    public UnityEngine.UI.Text exampleSentence;
    public float speed = 30f;
    Dictionary<string, List<string>> wordBundle;

    Vector3 wordSlide = new Vector3(-8.5f, 6.7f, 0);
    Vector3 defSlide = new Vector3(-8.5f, 4.7f, 0);
    Vector3 sentSlide = new Vector3(-8.5f, 1.7f, 0);

    Vector3 startWordPosition = new Vector3(0, 0, 0);
    Vector3 startDefPosition = new Vector3(0, 0, 0);
    Vector3 startSentencePosition = new Vector3(0, 0, 0);

    Quaternion startWordRotation = new Quaternion(0, 0, 0, 0);
    Quaternion startDefRotation = new Quaternion(0, 0, 0, 0);
    Quaternion startSentenceRotation = new Quaternion(0, 0, 0, 0);

    WordLevelLoader wordLevelLoader; 

    float speedSlide;
    bool isDone, isWordDone, isDefDone, isExampleDone;

    void Start()
    {
        GameObject obj = new GameObject("word level loader");
        wordLevelLoader = obj.AddComponent<WordLevelLoader>();
        wordBundle = wordLevelLoader.GetCompletePackage();

        speedSlide = speed * Time.fixedDeltaTime;
        startWordPosition = wordText.transform.position;
        startDefPosition = definition.transform.position;
        startSentencePosition = exampleSentence.transform.position;

        startWordRotation = wordText.transform.rotation;
        startDefRotation = definition.transform.rotation;
        startSentenceRotation = exampleSentence.transform.rotation;

        StartCoroutine(SlideInWords(wordBundle));
    }

    void Update()
    {
        if(isDone)
        {
            SlideIt();
        }
        if(isWordDone)
        {
            DefineIt();
        }
        if(isDefDone)
        {
            SentenceIt();
        }
        if (isExampleDone)
        {
            ResetIt();
        }
    }


    //========================================Slide In Words==============================================
    IEnumerator SlideInWords(Dictionary<string, List<string>> wordList)
    {
        int index = 0;
        int wordListCount = wordList.Count;

        foreach (var word in wordList.Keys)
        {
            index++;

            wordText.text = word.Substring(0, 1).ToUpper() + word.Substring(1) + " :";

            definition.text = wordBundle[word][1].Substring(0, 1).ToUpper() + wordBundle[word][1].Substring(1);

            exampleSentence.text = "Eg. " + wordBundle[word][0].Substring(0, 1).ToUpper() + wordBundle[word][0].Substring(1);

            //slide in word
            StartCoroutine(SlideInWord());
            yield return new WaitForSeconds(3.25f);

            StartCoroutine(SlideInDefinition());
            yield return new WaitForSeconds(3.25f);

            StartCoroutine(SlideInSentence());
            yield return new WaitForSeconds(7.25f);

            Debug.Log(index + "/" + wordListCount + ": " + wordText.text);

            ResetIt();
        }
        SceneManager.LoadScene("Start Scene", LoadSceneMode.Single);
    }

    //============================================================================================================
    //============================================WORD============================================================
    IEnumerator SlideInWord()
    {
        isDone = true;
        yield return new WaitForSeconds(3.25f);
        isDone = false;
    }

    void SlideIt()
    {
        wordText.transform.position = Vector3.MoveTowards(wordText.transform.position, wordSlide, speedSlide);
    }
    //=============================================================================================================
    //=========================================DEFINITION==========================================================
    IEnumerator SlideInDefinition()
    {
        isWordDone = true;
        yield return new WaitForSeconds(3.25f);
        isWordDone = false;
    }

    void DefineIt()
    {
        definition.transform.position = Vector3.MoveTowards(definition.transform.position, defSlide, speedSlide);
    }
    //=============================================================================================================
    //===========================================SENTENCE==========================================================
    IEnumerator SlideInSentence()
    {
        isDefDone = true;
        yield return new WaitForSeconds(7.25f);
        isDefDone = false;
    }

    void SentenceIt()
    {
        exampleSentence.transform.position = Vector3.MoveTowards(exampleSentence.transform.position, sentSlide, speedSlide);
    }
    //=============================================================================================================
    //==========================================RESET POSITION=====================================================
    IEnumerator ResetPositions()
    {
        isExampleDone = true;
        yield return new WaitForSeconds(1f);
        isExampleDone = false;
    }

    void ResetIt()
    {
        wordText.transform.SetPositionAndRotation(startWordPosition, startWordRotation);
        definition.transform.SetPositionAndRotation(startDefPosition, startDefRotation);
        exampleSentence.transform.SetPositionAndRotation(startSentencePosition, startSentenceRotation);
    }
    //=============================================================================================================

}
