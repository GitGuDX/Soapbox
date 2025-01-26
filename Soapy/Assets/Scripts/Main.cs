using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    
	private bool canPressButtons = true;
	
	private int minStory = 7;
	private int maxStory = 15;
	
	private float[] multiplier = new float[] {1,1,1,1};
	
	private bool moreFreaks = false;
	
	[SerializeField] List<CommentSO> choice = new List<CommentSO>();
	
	[Space]
	
	[SerializeField] CommentSO[] normal;
	[SerializeField] CommentSO[] lowMoney;
	[SerializeField] CommentSO[] lowGovernment;
	[SerializeField] CommentSO[] lowPopularity;
	[SerializeField] CommentSO[] lowQuality;
	[SerializeField] CommentSO[] highMoney;
	[SerializeField] CommentSO[] highGovernment;
	[SerializeField] CommentSO[] highPopularity;
	[SerializeField] CommentSO[] highQuality;
	[SerializeField] CommentSO[] freaks;
	
	[Space]
	
	[SerializeField] TextMeshProUGUI dialogueText;
	[SerializeField] TextMeshProUGUI stats;
	[SerializeField] TextMeshProUGUI username;
	[SerializeField] Image profile;
	
	[Space]
	
	private string targetText;
	private string currentText;
	
	[SerializeField] CommentSO defaultComment;
	[SerializeField] CommentSO currentComment;
	
	[Space]
	
	[SerializeField] CommentSO[] scientistUpgrades;
	
	[Space]
	
	[SerializeField] CommentSO[] freakStoryline;
	
	[Space]
	
	[SerializeField] public float money , popularity, quality, government;
	
	[Space]
	
	[SerializeField] int commentsUntilNextScientist = 15;
	[SerializeField] int scientistIndex = 0;
	
	[Space]
	
	[SerializeField] int commentsUntilNextFreak = 10;
	[SerializeField] int freakIndex = 0;

	[Space]

	[SerializeField] CharacterMove characterMove;
	[SerializeField] CommentMove commentMove;

	//Audio
	AudioManager audioManager;

	
	
	private void Start() {
		audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>(); 
		currentComment = defaultComment;
		updateUI();
		SetScrollingText();
		
	}
	
	public void like() {
		
		if(!canPressButtons) return;
		canPressButtons = false;
		
		if (currentComment.specialTrigger == CommentSO.SpecialTriggers.scientistUpgrade) upgradeSoap();
		if (currentComment.specialTrigger == CommentSO.SpecialTriggers.mainStoryline && freakIndex == 2)
			quality = Mathf.Clamp(quality, quality, 20);
		if (currentComment.specialTrigger == CommentSO.SpecialTriggers.trueEnding) Debug.Log("TRUE ENDING");
		
		affectStats(true);
		pickNextComment();
		characterMove.StartCoroutine("Transition");
		commentMove.StartCoroutine("Transition");
		audioManager.PlaySFX(audioManager.like);
		
	}
	
	public void dislike() {
		
		if(!canPressButtons) return;
		canPressButtons = false;
		
		if (currentComment.specialTrigger == CommentSO.SpecialTriggers.mainStoryline) commentsUntilNextFreak = -1;
		if (currentComment.specialTrigger == CommentSO.SpecialTriggers.trueEnding) Debug.Log("TRUE ENDING");
		
		affectStats(false);
		pickNextComment();
		characterMove.StartCoroutine("Transition");
		commentMove.StartCoroutine("Transition");
		audioManager.PlaySFX(audioManager.dislike);
		
	}
	
	private void upgradeSoap(){
		
		switch (scientistIndex){
			
			case 1:
				Debug.Log("1.2 times increase/decrease");
				multiplier = new float[] {1.2f,1.2f,1.2f,1.2f};
				break;
			case 2:
				Debug.Log("Lock popularity");
				multiplier = new float[] {1,1,0,1};
				break;
			case 3:
				Debug.Log("Lock government");
				multiplier = new float[] {1,0,1,1};
				break;
			case 4:
				Debug.Log("Swap money and popularity");
				multiplier = new float[] {1,1,1,1};
				float t = money;
				money = popularity;
				popularity = t;
				break;
			case 5:
				Debug.Log("Swap quality and popularity");
				multiplier = new float[] {1,1,1,1};
				float t2 = quality;
				quality = popularity;
				popularity = t2;
				break;
			case 6:
				Debug.Log("Reset all stats");
				multiplier = new float[] {1,1,1,1};
				money = 100;
				government = 100;
				popularity = 100;
				quality = 100;
				break;
			case 7:
				Debug.Log("More freaks");
				multiplier = new float[] {1,1,1,1};
				moreFreaks = true;
				break;
			default:
				Debug.LogError("None");
				break;
			
		}
		
	}
	
	private void pickNextComment() {
		
		if (commentsUntilNextScientist == 0){
			
			if (scientistIndex >= 7) {
				commentsUntilNextScientist = -1;
			}
			else {
				currentComment = scientistUpgrades[scientistIndex++];
				commentsUntilNextScientist = Random.Range(minStory, maxStory);
				return;
			}
			
		}
		
		if (commentsUntilNextFreak == 0) {
			
			if (freakIndex >= 7){
				commentsUntilNextFreak = -1;
			}
			else {
				currentComment = freakStoryline[freakIndex++];
				commentsUntilNextFreak = Random.Range(minStory, maxStory);
				return;
			}
			
		}
		
		
		choice.Clear();
		
		choice.AddRange(normal);
		
		if (money <= 50) choice.AddRange(lowMoney);
		if (government <= 50) choice.AddRange(lowGovernment);
		if (popularity <= 50) choice.AddRange(lowPopularity);
		if (quality <= 50) choice.AddRange(lowQuality);
		if (money >= 150) choice.AddRange(highMoney);
		if (government >= 150) choice.AddRange(highGovernment);
		if (popularity >= 150) choice.AddRange(highPopularity);
		if (quality >= 150) choice.AddRange(highQuality);
		
		if (moreFreaks) choice.AddRange(freaks);

		
		if (choice.Count == 0) Debug.LogError("NONONO bad");
		
		
		currentComment = choice[Random.Range(0, choice.Count)];
		
		
		if (commentsUntilNextScientist > 0) commentsUntilNextScientist--;
		if (moreFreaks && commentsUntilNextFreak > 0) commentsUntilNextFreak--;
		
	}
	
	public void updateUI() {
	
		profile.sprite = currentComment.profile;
		username.text = currentComment.userName;
		targetText = currentComment.comment;
		dialogueText.text = "";
	
	}
	
	public void SetScrollingText(){
		
		targetText = currentComment.comment;
		currentText = "";
		canPressButtons = true;
		StartCoroutine("GraduallyDisplayText");	
		
	}
	
	private IEnumerator GraduallyDisplayText(){
		int i = 0;
		while(currentText.Length < targetText.Length){
			
			if (i >= targetText.Length) break;
			
			currentText += targetText[i];
			dialogueText.text = currentText;
			i++;
			yield return new WaitForSeconds(.03f);
			
			if(!canPressButtons){
				currentText += "";
				dialogueText.text = currentText;
				break;
			}
			
		}
		
	}
	
	
	
	
	private void affectStats(bool like) {
		
		if (like){
			money += currentComment.moneyL * multiplier[0];
			government += currentComment.governmentL * multiplier[1];
			popularity += currentComment.popularityL * multiplier[2];
			quality += currentComment.qualityL * multiplier[3];
		}
		else {
			money += currentComment.moneyD * multiplier[0];
			government += currentComment.governmentD * multiplier[1];
			popularity += currentComment.popularityD * multiplier[2];
			quality += currentComment.qualityD * multiplier[3];
		}
		
		stats.text = stats.text = string.Format("Money: {0}\nPopularity: {1}\nQuality: {2}\nGovernment: {3}", money, popularity, quality, government);
		
		// Check for game over here
		
	}


	
	
}






