using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Word : MonoBehaviour {

	public string Word { get; set; }
	public string Definition { get; set; }
	public string Sentence { get; set; }
	public int Rank { get; set; }
	public string GradeLevel { get; set; }

	public Word()
	{
		this.Word = "";
		this.Definition = "";
		this.Sentence = "";
		this.Rank = 0;
		this.GradeLevel = "";
	}
	
	public Word(string word, string definition, string sentence, int rank, string gradeLevel)
	{
		this.Word = word;
		this.Definition = definition;
		this.Sentence = sentence;
		this.Rank = rank;
		this.GradeLevel = gradeLevel;
	}
}
