using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

	public string Level { get; set; }
	public string BackgroundColor { get; set; }
	public string Counter { get; set; }

	public Level()
	{
		this.Level = "";
		this.BackgroundColor = "";
		this.Counter = "";
	}
	
	public Level(string level, string backgroundColor, string counter)
	{
		this.Level = level;
		this.BackgroundColor = backgroundColor;
		this.Counter = counter;
	}
}
