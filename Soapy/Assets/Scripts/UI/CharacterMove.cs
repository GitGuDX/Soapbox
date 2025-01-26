using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterMove : MonoBehaviour
{

    [SerializeField]
    Main main; 

    bool transitioning = false;
    public Transform Character;

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


    }


}
