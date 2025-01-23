using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommentMoving : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(Vector3.down * 80f * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
