using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public Texture2D BubbleSoapCursor;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 cursorOffset = new Vector2(BubbleSoapCursor.width/2, BubbleSoapCursor.height/2);    //center

        Cursor.SetCursor(BubbleSoapCursor, cursorOffset, CursorMode.Auto);   //set cursor
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
