using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Plane_my : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    Material m;
    Color m1;
    Color m2;


    void Start()
    {
        m = GetComponent<MeshRenderer>().material;
        m1 = m.color;
        m2 = m.color;
        Debug.Log("Enter");
        
        m2.a = 0.3f;
    }
    //Detect if the Cursor starts to pass over the GameObject
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        
        m.color = m2;
        //Output to console the GameObject's name and the following message
        Debug.Log("Cursor Entering " + name + " GameObject");
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        m.color = m1;
        //Output the following message with the GameObject's name
        Debug.Log("Cursor Exiting " + name + " GameObject");
    }
}
