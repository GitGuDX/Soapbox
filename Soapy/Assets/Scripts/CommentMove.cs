using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommentMove : MonoBehaviour
{
    bool transitioning = false;
    bool transitioning2 = false;
    public Transform Comment;
    public float targetTime = 2.0f;

    void Start()
    {
        
    }

    void Update()
    {

        /* if (transitioning == true && transitioning2 == false){
            Comment.Translate(Vector3.up*130*Time.deltaTime);
            targetTime -= 1*Time.deltaTime; 
           // print(targetTime);
        }
        if (transitioning == true && transitioning2 == true){
            Comment.Translate(Vector3.down*130*Time.deltaTime);
            targetTime -= 1*Time.deltaTime;
           // print(targetTime);
        }
        if ( targetTime <= 0.0f)
        {
            if( transitioning2 == false)
            {
            transitioning2 = true;
            targetTime = 2.0f;
         //   print(targetTime);
            
            }
            else if( transitioning2 == true)
            {
            transitioning2 = false;
            transitioning = false;
            targetTime = 2.0f;
            }
        }   */           
    }

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
    }

    public void like(){
        transitioning = true;
	}

    public void dislike(){
        transitioning = true;
	}
}
