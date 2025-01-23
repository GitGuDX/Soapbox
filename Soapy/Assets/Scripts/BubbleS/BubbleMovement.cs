using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMovement : MonoBehaviour
{
    private Vector3 startPoint;
    private Vector3 endPoint;
    private float desiredDuration = 3f;
    private float elapsedTime;
    // Start is called before the first frame update
    void Start()
    {
        startPoint = transform.position;
        endPoint = startPoint + new Vector3(25f, 0f, 0f);
       //StartCoroutine(FirstLerp());
       StartCoroutine(DeleteBubble());
     
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * 40f * Time.deltaTime);
       
    }


    private IEnumerator DeleteBubble()
    {
        yield return new WaitForSeconds(7f);
        float deleteInterval = Random.Range(0, 4f);
        yield return new WaitForSeconds(deleteInterval);
        Destroy(gameObject);
    }

    IEnumerator FirstLerp()
    {
        elapsedTime = 0;
        while (elapsedTime < desiredDuration)
        {
            float percentageComplete = elapsedTime / desiredDuration;
            Vector3 lerpedPosition = Vector3.Lerp(startPoint, endPoint, percentageComplete);
            transform.position = new Vector3(lerpedPosition.x, transform.position.y + (40f * Time.deltaTime), lerpedPosition.z);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = endPoint;


        StartCoroutine(SecondLerp());
    }

    IEnumerator SecondLerp()
    {

        elapsedTime = 0;
        while (elapsedTime < desiredDuration)
        {
            float percentageComplete = elapsedTime / desiredDuration;
            Vector3 lerpedPosition = Vector3.Lerp(endPoint, startPoint, percentageComplete);
            transform.position = new Vector3(lerpedPosition.x, transform.position.y + (40f * Time.deltaTime), lerpedPosition.z);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = endPoint;
        //transform.Rotate(0f, 90f, 0f);
        StartCoroutine(FirstLerp());
    }
}
