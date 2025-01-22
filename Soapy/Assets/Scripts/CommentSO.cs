using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Comment")]

public class CommentSO : ScriptableObject
{
	public enum Stats {money, popularity, quality, government}
	
	[TextArea(10, 14)] public string comment;
	public Sprite profile;
	[Space]
	public Stats[] affectedVariablesLike;
	public int[] affectedValuesLike;
	[Space]
	public Stats[] affectedVariablesDislike;
	public int[] affectedValuesDislike;
}
