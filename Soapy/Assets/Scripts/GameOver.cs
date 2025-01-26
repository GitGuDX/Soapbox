using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameOver
{
	
	public static int endingType;
	
	public static void SetGameOver(int end){
		
		endingType = end;
		SceneManager.LoadScene("GameOver");
		
	}
}
