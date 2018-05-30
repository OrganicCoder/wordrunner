using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace UnityStandardAssets._2D
{
    public class SentencesReader : MonoBehaviour
	{
		// key is the obstacle (a string). The value(s) can be an array of strings
		public Dictionary<String, String[]> sentenceDictionary;

		public Dictionary<String, String[]> GetDictionary()
		{
            string line;
            String[] tempKeyValuePair = new String[5];
            sentenceDictionary = new Dictionary<String, String[]>();

            // the location of the "sentences.txt" file
            string fileLocation = Application.dataPath + @"/Data/sentences.txt";

            // Read the file line-by-line
            StreamReader file = new StreamReader(fileLocation);
            while ((line = file.ReadLine()) != null)
            {
                try
                {
                    tempKeyValuePair = line.Split(':');
                    // add key (obstacle) and value (sentence) to the dictionary.
                    // (WARNING: Will override value if duplicate key is used to add to dictionary)
                    sentenceDictionary.Add(tempKeyValuePair[0], new String[] { tempKeyValuePair[1] });
                }
                catch (KeyNotFoundException)
                {
                    Debug.Log("KeyNotFoundException: Failed to add the key to the dictionary. (SentenceReader)");
                    if (tempKeyValuePair.Length == 0)
                    {
                        Debug.Log("tempKeyValuePair is null. (SentenceReader)");
                    }
                }
            }

            file.Close();
			if(sentenceDictionary == null)
			{
				Debug.Log("Returned null dictionary");
			}

			return sentenceDictionary;
		}
	}
}
