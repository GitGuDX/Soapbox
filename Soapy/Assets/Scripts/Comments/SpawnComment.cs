using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnComment : MonoBehaviour
{
   // public Transform comment;
    public GameObject panel;
    public Transform parentObject;
    GameObject newPanel;
    // Start is called before the first frame update
    void Start()
    {
        newPanel = Instantiate(panel,new Vector3(13f,-180f,0f), Quaternion.identity);
        RectTransform panelPosition = newPanel.GetComponent<RectTransform>();
        if (panelPosition == null) {
            Debug.Log("XD");
        }
        newPanel.transform.SetParent(parentObject, false);


    }

    // Update is called once per frame
    void Update()
    {

      //  comment.Translate(Vector3.up * 80f * Time.deltaTime);
    }
}
