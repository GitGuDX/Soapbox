using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    bool transitioning = false;
    bool transitioning2 = false;
    public Transform Character;
    public float targetTime = 2.0f;

    void Start()
    {
        
    }

    void Update()
    {

        if (transitioning == true && transitioning2 == false){
            Character.Translate(Vector3.down*130*Time.deltaTime);
            targetTime -= 1*Time.deltaTime; 
        }
        if (transitioning == true && transitioning2 == true){
            Character.Translate(Vector3.up*130*Time.deltaTime);
            targetTime -= 1*Time.deltaTime;
        }
        if ( targetTime <= 0.0f)
        {
            if( transitioning2 == false)
            {
            transitioning2 = true;
            targetTime = 2.0f;
            
            }
            else if( transitioning2 == true)
            {
            transitioning2 = false;
            transitioning = false;
            targetTime = 2.0f;
            }
        }             
    }

    public void like(){
        transitioning = true;
	}

    public void dislike(){
        transitioning = true;
	}
}
