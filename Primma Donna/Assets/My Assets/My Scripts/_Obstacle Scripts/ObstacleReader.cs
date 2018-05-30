using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class ObstacleReader : MonoBehaviour
	{
		// key is the obstacle (a string). The value(s) can be an array of strings

		public static Dictionary<String, String[]> GetDictionary()
		{
            string line;
            String[] tempKeyValuePair = new String[5];
            Dictionary<String, String[]> wordsDictionary = new Dictionary<String, String[]>();

            // the location of the "obstacles.txt" file
            string fileLocation = Application.dataPath + @"/Data/obstacles.txt";

            // Read the file line-by-line
            StreamReader file = new StreamReader(fileLocation);
            while ((line = file.ReadLine()) != null)
            {
                try
                {
                    tempKeyValuePair = line.Split(':');
                    // add key (obstacle) and value (solution) to the dictionary.
                    // (WARNING: Will override value if duplicate key is used to add to dictionary)
                    wordsDictionary.Add(tempKeyValuePair[0], new String[] { tempKeyValuePair[1] });
                }
                catch (KeyNotFoundException)
                {
                    Debug.Log("KeyNotFoundException: Failed to add the key to the dictionary. (ObstacleReader)");
                    if (tempKeyValuePair.Length == 0)
                    {
                        Debug.Log("tempKeyValuePair is empty. (ObstacleReader)");
                    }
                }
            }

            file.Close();
			if(wordsDictionary == null)
			{
				Debug.Log("Returned null dictionary");
			}

			return wordsDictionary;
		}
	}
}
