using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommentMove : MonoBehaviour
{
    public Transform Comment;
	
	[SerializeField] Main main;

    public IEnumerator Transition() {

        Debug.Log("AAAA");

        for (int i = 0; i < 120; i++){

            Comment.Translate(Vector3.up*1.5f*Screen.height*0.005f);
            yield return new WaitForSeconds(0.01f);

        }


        for (int i = 0; i < 120; i++){

            Comment.Translate(Vector3.down*1.5f*Screen.height*0.005f);
            yield return new WaitForSeconds(0.01f);

        }
		
		main.SetScrollingText();
		
    }


}
