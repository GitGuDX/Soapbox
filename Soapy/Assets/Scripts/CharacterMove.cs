using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterMove : MonoBehaviour
{

    [SerializeField]
    Main main; 

    bool transitioning = false;
    bool transitioning2 = false;
    public Transform Character;
    public float targetTime = 2.0f;

    void Start()
    {
        
    }

    void Update()
    {

        /* if (transitioning == true && transitioning2 == false){
            Character.Translate(Vector3.down*130*Time.deltaTime);
            targetTime -= 1*Time.deltaTime; 
            Debug.Log("XD");
        }

        
        if (transitioning == true && transitioning2 == true){
            Character.Translate(Vector3.up*130*Time.deltaTime);
            targetTime -= 1*Time.deltaTime;
            Debug.Log("LMAO");
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
        }         */     
    }


    public IEnumerator Transition() {

        Debug.Log("AAAA");

        float targetTime = 0;

        for (int i = 0; i < 120; i++){

            Character.Translate(Vector3.down*1.3f*Screen.height*0.005f);
            yield return new WaitForSeconds(0.01f);

        }

        main.updateUI();

        for (int i = 0; i < 120; i++){

            Character.Translate(Vector3.up*1.3f*Screen.height*0.005f);
            yield return new WaitForSeconds(0.01f);

        }

        /* while(targetTime < 2){

            targetTime += Time.deltaTime;

            Character.Translate(Vector3.down*130*Time.deltaTime);
            Debug.Log("XD");

        }

        targetTime = 0;

        main.updateUI();

        while(targetTime < 2){

            targetTime += Time.deltaTime;

            Character.Translate(Vector3.up*130*Time.deltaTime);
            Debug.Log("XD");

        } */

    }

    public void like(){
        transitioning = true;
	}

    public void dislike(){
        transitioning = true;
	}
}
