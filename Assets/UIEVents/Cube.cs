using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;


public class Cube : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static event Action<double,int> dragEvent;
    

    [SerializeField]
    int id;

    DateTime beginTime;
    DateTime endTime;
    public void OnBeginDrag(PointerEventData eventData)
    {
        beginTime = DateTime.Now;   
        Debug.Log("OnBeginDrag");
       
    }

    public void OnDrag(PointerEventData data)
    {
        Debug.Log("OnnDrag");
        float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        Vector3 v = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));
        v.y = transform.position.y;
        transform.position = v;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        endTime = DateTime.Now;

        dragEvent?.Invoke((endTime - beginTime).TotalSeconds,id);

        Debug.Log("Ended");
    }

   

}
