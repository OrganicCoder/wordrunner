using System;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryReader : MonoBehaviour
{
	// key is the obstacle (a string). The value(s) can be an array of strings
	public Dictionary<String, String> definitionDictionary;

	public Dictionary<String, String> getDictionary()
	{
          string line;
          String[] tempKeyValuePair;
          definitionDictionary = new Dictionary<String, String>();

          // the location of the "dictionary.txt" file
          string fileLocation = Application.dataPath + @"/Data/dictionary.txt";

          // Read the file line-by-line
          System.IO.StreamReader file = new System.IO.StreamReader(fileLocation);
          while ((line = file.ReadLine()) != null)
          {
              tempKeyValuePair = line.Split(':');
              // add key (solution) and value (definition) to the dictionary.
              // (WARNING: Will override value if duplicate key is used to add to dictionary)
              definitionDictionary.Add(tempKeyValuePair[0], tempKeyValuePair[1]);
              //Debug.Log("key: " + tempKeyValuePair [0] + ", value: " + tempKeyValuePair [1] + " added to the dictionary.");
          }

          file.Close();

		if(definitionDictionary == null)
		{
			Debug.LogWarning("Returned null dictionary");
		}

		return definitionDictionary;
	}
}
