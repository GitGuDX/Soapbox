using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Comment")]

public class CommentSO : ScriptableObject
{
	public enum SpecialTriggers {none, scientistUpgrade, mainStoryline, trueEnding}
	
	public enum Stats {money, popularity, quality, government}
	
	public SpecialTriggers specialTrigger = SpecialTriggers.none;
	[Space]
	public string userName;
	[Space]
	[TextArea(10, 14)] public string comment;
	public Sprite profile;
	[Space]
	[Header("Affected stats when liking")]
	public float moneyL = 0;
	public float governmentL = 0;
	public float popularityL = 0;
	public float qualityL = 0;
	
	[Header("Affected stats when disliking")]
	public float moneyD = 0;
	public float governmentD = 0;
	public float popularityD = 0;
	public float qualityD = 0;
}
