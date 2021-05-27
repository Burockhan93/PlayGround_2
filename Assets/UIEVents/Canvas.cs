using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Canvas : MonoBehaviour
{
    TMP_Text text;
    TMP_Text drag;
    // Start is called before the first frame update
    void Start()
    {
        text = transform.GetChild(0).gameObject.GetComponent<TMP_Text>();
        drag = transform.GetChild(1).gameObject.GetComponent<TMP_Text>();
        
        Sphere.OnclickAction += UpdateText;
        Cube.dragEvent += DragTime;
    }

    // Update is called once per frame
    void UpdateText(int click, int id)
    {
        text.text = id.ToString()+ " no: "+  click.ToString();
    }

    void DragTime(double d, int id)
    {
        drag.text = id.ToString() + " no: " + d.ToString();
    }
}
