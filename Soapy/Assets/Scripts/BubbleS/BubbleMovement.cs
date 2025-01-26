using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMovement : MonoBehaviour
{
    private Vector3 startPoint;
//private Vector3 newStartPoint;
    private Vector3 endPoint;
    private float desiredDuration = 2f;
    private float elapsedTime;
    private float xInterval = 50f;
    //audio

    AudioManager audioManager;
    // Start is called before the first frame update

    private void Awake() {
    
}
    void Start()
    {
       audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>(); 
        
       StartCoroutine(FirstLerp());
       StartCoroutine(DeleteBubble());
     
    }

    // Update is called once per frame
    void Update()
    {
        // transform.Translate(Vector3.up * 40f * Time.deltaTime);
       
    }


    private IEnumerator DeleteBubble()
    {
        yield return new WaitForSeconds(7f);
        float deleteInterval = Random.Range(0, 4f);
        yield return new WaitForSeconds(deleteInterval);
        audioManager.PlaySFX(audioManager.bubblePopping);
        Destroy(gameObject);
    }









    IEnumerator FirstLerp()
    {
        startPoint = transform.position;
        endPoint = startPoint + new Vector3(xInterval, 0f, 0f);
        elapsedTime = 0;
        while (elapsedTime < desiredDuration)
        {
            float percentageComplete = elapsedTime / desiredDuration;
            Vector3 lerpedPosition = Vector3.Lerp(startPoint, endPoint, percentageComplete);
            transform.position = new Vector3(lerpedPosition.x, transform.position.y + (40f * Time.deltaTime * Screen.height * 0.002f), lerpedPosition.z);
            elapsedTime += Time.deltaTime;
            yield return null;
        }


        StartCoroutine(SecondLerp());
    }

    IEnumerator SecondLerp()
    {

        Vector3 newStartPoint = transform.position + new Vector3(-xInterval, 0f, 0f);
        endPoint = transform.position;
        elapsedTime = 0;
        while (elapsedTime < desiredDuration)
        { 

            float percentageComplete = elapsedTime / desiredDuration;
            Vector3 lerpedPosition = Vector3.Lerp(endPoint, newStartPoint, percentageComplete);
            transform.position = new Vector3(lerpedPosition.x, transform.position.y + (40f * Time.deltaTime * Screen.height * 0.002f), lerpedPosition.z);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        //transform.Rotate(0f, 90f, 0f);
        StartCoroutine(FirstLerp());
    }
    
}
