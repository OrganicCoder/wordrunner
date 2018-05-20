using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreStorage : MonoBehaviour
{
	public int score { get; set;}
	int addScore = 10;
    int gradeLevelPoints = 1;
    int rarityPoints = 1;
    string gradeLevel = "";
    int rarity = 1;

	void Awake ()
	{
		score = 0;
	}

	public void setScoreFromWord(string str)
	{
		addScore = str.Length * 10;

        /* ======== wordGradeLevel =========
        *  wordGradeLevel is a dictionary of <string,string>  
        *  <"shear","Elementary">
        *  <"defenestrate", "Graduate">
        *  so wordGradeLevel("shear") returns "Elementary" --> gradeLevel = "Elementary"
        *  Dictionary<string, string> wordGradeLevel; <-- define this dictionary in another file and import
        */ 
        // gradeLevel = wordGradeLevel(str);
        // Is it a value of this key "Graduate"? Is it a value of that key "Elementary"?

        /* ====== wordRarity ===============
         * wordRarity is a dictionary of <string,int> <-- define this dictionary in another file and import
         * <"Shear", 8223>. 
         * // rarity = wordRarity(str);
         * In another method calculate ranges --> public int calculateRarity(rarity)
         * 1 < x < 100 then rarityOfWord = 20
         * 100 < x < 1000 then rarityofWord = 15
         * 1000 < x < 5000 then rarityofWord = 10
         * 5000 < x < 10000 then rarityofWord = 5
         * x > 10000 then rarityofWord = 1
        */

        addScore = addScore * getWordGradeLevel(gradeLevel) * getWordRarity(rarity);
	}

    //===============================================
    public int getWordGradeLevel(string gradeLevel)
    {
        switch (gradeLevel)
        {
            case "Elementary":
                gradeLevelPoints = 2;
                break;
            case "High School":
                gradeLevelPoints = 3;
                break;
            case "Collegiate":
                gradeLevelPoints = 4;
                break;
            case "Graduate":
                gradeLevelPoints = 5;
                break;
            default:
                gradeLevelPoints = 1;
                break;
        }
        return gradeLevelPoints;
    }

    public int getWordRarity(int rarity)
    {
        if (rarity > 1 && rarity < 100)
            rarityPoints = 20;
        else if (rarity > 100 && rarity < 1000)
            rarityPoints = 15;
        else if (rarity > 1000 && rarity < 5000)
            rarityPoints = 10;
        else if (rarity > 5000 && rarity < 10000)
            rarityPoints = 5;
        else
            rarityPoints = 1;

        return rarityPoints;
    }
    //===============================================

	public void failedChallenge()
	{
		if (addScore > 1)
			addScore = addScore == 10 ? 1 : addScore - 10;
	}

	public void passedChallenge()
	{
		score += addScore;
	}
}
