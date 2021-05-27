using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinderr : MonoBehaviour
{
    public Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
    }
    private void OnMouseDown()
    {
        transform.localScale = new Vector3(2, 2, 2);
    }
    private void OnMouseDrag()
    {
        rend.material.color -= Color.white * Time.deltaTime;
    }
    private void OnMouseExit()
    {
        
    }

    private void OnMouseOver()
    {
        
    }

    private void OnMouseUp()
    {
        
    }
    private void OnMouseEnter()
    {
        
    }
}
