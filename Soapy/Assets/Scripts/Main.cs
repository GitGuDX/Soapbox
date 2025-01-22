using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    
	[SerializeField] TextMeshProUGUI dialogueText;
	[SerializeField] TextMeshProUGUI stats;
	[SerializeField] Image profile;
	
	[Space]
	
	[SerializeField] CommentSO currentComment;
	[SerializeField] CommentSO[] dialogueArray;
	
	[Space]
	
	[SerializeField] int money , popularity, quality, government;
	
	private void Start(){
		
		pickNextComment();
		updateUI();
		
	}
	
	public void like(){
		
		affectStats(currentComment.affectedVariablesLike, currentComment.affectedValuesLike);
		pickNextComment();
		updateUI();
		
	}
	
	public void dislike(){
		
		affectStats(currentComment.affectedVariablesDislike, currentComment.affectedValuesDislike);
		pickNextComment();
		updateUI();
		
	}
	
	
	private void pickNextComment(){
		
		currentComment = dialogueArray[Random.Range(0, dialogueArray.Length)];
		
	}
	
	private void updateUI(){
	
		profile.sprite = currentComment.profile;
		dialogueText.text = currentComment.comment;
		stats.text = stats.text = string.Format("Money: {0}\nPopularity: {1}\nQuality: {2}\nGovernment: {3}", money, popularity, quality, government);
	
	}
	
	
	private void affectStats(CommentSO.Stats[] names, int[] values) {
		for (int i = 0; i < names.Length; i++)
		{
			int value = values[i];
	
			switch (names[i])
			{
				case CommentSO.Stats.money:
					money += value;
					break;
	
				case CommentSO.Stats.popularity:
					popularity += value;
					break;
	
				case CommentSO.Stats.quality:
					quality += value;
					break;
	
				case CommentSO.Stats.government:
					government += value;
					break;
	
				default:
					continue;
			}
		}
	}


	
	
}






