using System;
using System.Collections.Generic;
using UnityEngine;

public class WordLevelLoader : MonoBehaviour
{
    Dictionary<String, String[]> definitionDict;
    Dictionary<String, String[]> sentenceDict;

    // key: obstacle solution
    // values: [solution definition, solution sentence]
    Dictionary<String, List<String>> completePackage;

    public Dictionary<String, List<String>> GetCompletePackage()
    {
        definitionDict = GenericReader.GetDictionary();
        sentenceDict = GenericReader.GetSentences();

        // initialize payload
        completePackage = new Dictionary<String, List<String>>();

        // TODO: Replace use of `starterWords` with the ability to retrieve keywords from the dictionary. (https://trello.com/c/QrFAEzsx/52-wordlevelloader-starterwords)
        // Load the five starter obstacle solution words.
        String[] starterWords = { "hew", "shear", "shelter", "vessel", "umbrella" };

        // Load the definitions
        List<String> definitions = new List<String>();
        for (int i = 0; i < starterWords.Length; i++)
        {
            try
            {
                definitions.Add(definitionDict[starterWords[i]][0]);
            }
            catch (KeyNotFoundException)
            {
                Debug.Log("KeyNotFoundException: Failed to retrieve key '" + starterWords[i] + "' from the 'definitionDict' dictionary. (WordLevelLoader)");
                Debug.Log("The size of 'definitionDict': " + definitionDict.Count);
            }
        }

        // Load the five starter example sentences
        List<String> sentences = new List<String>();
        for (int i = 0; i < starterWords.Length; i++)
        {
            try
            {
                sentences.Add(sentenceDict[starterWords[i]][0]);
                //Debug.Log("sentenceDict[" + starterWords[i] + "] = " + sentenceDict[starterWords[i]][0]);
            }
            catch (KeyNotFoundException)
            {
                Debug.Log("KeyNotFoundException: Failed to retrieve key '" + starterWords[i] + "' from the 'sentenceDict' dictionary. (WordLevelLoader)");
                Debug.Log("The size of 'sentenceDict': " + sentenceDict.Count);
            }
        }

        // Create completePackage payload
        List<String> tempDefinitionSentenceList;

        for (int i = 0; i < starterWords.Length; i++)
        {

            tempDefinitionSentenceList = new List<String>();
            // add definition, add sentence
            tempDefinitionSentenceList.Insert(0, sentences[i]);
            tempDefinitionSentenceList.Insert(1, definitions[i]);

            // key: obstacle solution, values: [solution definition, solution sentence]
            completePackage.Add(starterWords[i], tempDefinitionSentenceList);
        }

        return completePackage;
    }
}
