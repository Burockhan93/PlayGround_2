using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Capsule : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Material m1;
    public Material m2;
    //Detect current clicks on the GameObject (the one with the script attached)
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        gameObject.GetComponent<MeshRenderer>().material = m1;
        //Output the name of the GameObject that is being clicked
        Debug.Log(name + "Game Object Click in Progress");
    }

    //Detect if clicks are no longer registering
    public void OnPointerUp(PointerEventData pointerEventData)
    {
        gameObject.GetComponent<MeshRenderer>().material = m2;
        Debug.Log(name + "No longer being clicked");
    }

}
