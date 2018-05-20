using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GenericReader : MonoBehaviour
{

      private const string COLORS_FILE_NAME = "background-colors.txt";
      private const string DICTIONARY_FILE_NAME = "dictionary.txt";
      private const string OBSTACLES_FILE_NAME = "obstacles.txt";
      private const string SENTENCES_FILE_NAME = "sentences.txt";


      public static Dictionary<String, String[]> GetDictionary()
      {
          return GetDictionaryByFilename(DICTIONARY_FILE_NAME);
      }

      public static Dictionary<String, String[]> GetSentences()
      {
          return GetDictionaryByFilename(SENTENCES_FILE_NAME);
      }

      public static Dictionary<String, String[]> GetObstacles()
      {
          return GetDictionaryByFilename(OBSTACLES_FILE_NAME);
      }

      public static bool isValidFileName(string fileName)
      {
          // Check for valid file name.
          if(fileName == null)
          {
              Debug.LogError("\"fileName\" is null. No dictionary returned.");
              return false;
          }
          else if(fileName == String.Empty)
          {
              Debug.LogError("\"fileName\" is empty. No dictionary returned.");
              return false;
          }
          else
          {
              return true;
          }
      }

      public static Dictionary<String, Color> GetBackgroundColorDictionary()
      {
          String fileLine;
          String[] tempKeyValuePair = new String[2];
          Dictionary<String, Color> dictionary = new Dictionary<String, Color>();

          if(!isValidFileName(COLORS_FILE_NAME))
          {
              Debug.LogWarning("Invalid file name.");
              return null;
          }

          // Declare file.
          string fileLocation = Application.dataPath + @"/Data/" + COLORS_FILE_NAME;
          StreamReader file = new StreamReader(fileLocation);

          // Read file contents line-by-line.
          try
          {
              while ((fileLine = file.ReadLine()) != null)
              {
                  // Split the line at the colon.
                  try
                  {
                      tempKeyValuePair = fileLine.Split(':');
                      // Add key and value to the dictionary.
                      dictionary.Add(tempKeyValuePair[0], ColorStringConversionScript.stringToColor(tempKeyValuePair[1]));
                      // Debug.Log("Color Dictionary Updated (" + tempKeyValuePair[0] + "," + tempKeyValuePair[1] + ").");
                  }
                  catch (ArgumentNullException ex)
                  {
                      Debug.LogError("Dictionary key is null. No dictionary returned.");
                      Debug.LogError(ex.ToString());
                      return null;
                  }
                  catch (ArgumentException ex)
                  {
                      Debug.LogError("Element with the key already exists in the dictionary.");
                      Debug.LogError(ex.ToString());
                  }
              }
              file.Close();
              if(dictionary == null)
              {
                  Debug.LogWarning("Returned null dictionary.");
              }
              return dictionary;
          }
          catch (OutOfMemoryException ex)
          {
              Debug.LogError("Insufficient memory: Unable to load \"" + COLORS_FILE_NAME + "\".");
              Debug.LogError(ex.ToString());
              return null;
          }
          catch (IOException ex)
          {
              Debug.LogError("I/O Error: Unable to load \"" + COLORS_FILE_NAME + "\".");
              Debug.LogError(ex.ToString());
              return null;
          }
      }

      // Internal file parser method.
      protected static Dictionary<String, String[]> GetDictionaryByFilename(String fileName)
	{
          String fileLine;
          String[] tempKeyValuePair = new String[2];
          Dictionary<String, String[]> dictionary = new Dictionary<String, String[]>();

          if(!isValidFileName(fileName))
          {
              Debug.LogWarning("Invalid file name.");
              return null;
          }

          // Declare file.
          string fileLocation = Application.dataPath + @"/Data/" + fileName;
          StreamReader file = new StreamReader(fileLocation);

          // Read file contents line-by-line.
          try
          {
              while ((fileLine = file.ReadLine()) != null)
              {
                  // Split the line at the colon.
                  // Example #1: river:vessel
                  // Example #2: river:vessel|boat
                  try
                  {
                      // Split the entry into key-value pairs
                      tempKeyValuePair = fileLine.Split(':');

                      // Add string key and array of values to the dictionary.
                      dictionary.Add(tempKeyValuePair[0], tempKeyValuePair[1].Split('|'));
                  }
                  catch (ArgumentNullException ex)
                  {
                      Debug.LogError("Dictionary key is null. No dictionary returned.");
                      Debug.LogError(ex.ToString());
                      return null;
                  }
                  catch (ArgumentException ex)
                  {
                      Debug.LogError("Element with the key already exists in the dictionary.");
                      Debug.LogError(ex.ToString());
                  }
              }

              file.Close();
              if(dictionary == null)
              {
                  Debug.LogWarning("Returned null dictionary.");
              }

              return dictionary;
          }
          catch (OutOfMemoryException ex)
          {
              Debug.LogError("Insufficient memory: Unable to load \"" + fileName + "\".");
              Debug.LogError(ex.ToString());
              return null;
          }
          catch (IOException ex)
          {
              Debug.LogError("I/O Error: Unable to load \"" + fileName + "\".");
              Debug.LogError(ex.ToString());
              return null;
          }
	}
}
