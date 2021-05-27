using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Sphere : MonoBehaviour, IPointerClickHandler
{
    public static event Action<int,int> OnclickAction;
    int click;
    bool isClicked;

    bool isThree = true;
    bool isZero;


    public int id;

    //Detect if a click occurs
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        //Debug.Log("Pos: "+pointerEventData.position);
        //Debug.Log("Button : "+pointerEventData.button);
        //Debug.Log("Time. " + pointerEventData.clickTime);
        
        //Debug.Log(pointerEventData.clickCount);
        isClicked = true;
        click++;
        OnclickAction?.Invoke(click,id);

        //if (pointerEventData.button == PointerEventData.InputButton.Left)
        //    Debug.Log("Hhs");

        if (click > 2)
            //Output to console the clicked GameObject's name and the following message. You can replace this with your own actions for when clicking the GameObject.
            Destroy(gameObject);
    }

    void Update()
    {
        
        if (!isClicked) return;

        if (transform.position.y <= 3.1f && isThree && !isZero)
        {
            transform.position += Vector3.up*Time.deltaTime;
            if (transform.position.y >= 3)
            {
                isThree = false;
                isZero = true;
            }   

        }
       if(transform.position.y >=0  && isZero && !isThree)
        {
            transform.position += Vector3.down * Time.deltaTime;
            if (transform.position.y <= 0)
            {
                isThree = true;
                isZero = false;
            }

        }

    }
}
