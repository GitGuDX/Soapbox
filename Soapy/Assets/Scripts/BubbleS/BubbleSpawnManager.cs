using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubbleSpawnManager : MonoBehaviour
{
    public GameObject bubble;
    GameObject newBubble;
    public Transform parentObject;
    private float[] bubbleXposition;
    float randomX;
    // Start is called before the first frame update
    void Start()
    {
        bubbleXposition = new float[] { -350f, -250f, -150f, 50f, 150f, 250f, 350f };
        InvokeRepeating("SpawningBubble", 0f, 3f);
        
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawningBubble()
    {
        randomX = bubbleXposition[Random.Range(0, bubbleXposition.Length)];
        newBubble = Instantiate(bubble, new Vector3(randomX, -180, 0), Quaternion.identity);

        newBubble.transform.SetParent(parentObject, false);
    }
}
