using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    
	[SerializeField] Sprite[] endings;
	[SerializeField] string[] endingTexts;
	
	[SerializeField] Image img;
	[SerializeField] TextMeshProUGUI text;
	
    void Start()
    {
		
		int i = GameOver.endingType;
		
		if (i > 8 || i < 0) return;
		
        text.text = endingTexts[i];
		img.sprite = endings[i];
		
    }

}
