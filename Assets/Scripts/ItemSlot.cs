using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [HideInInspector]
    public Image icon;

    private void Start()
    {
        icon = this.transform.GetChild(0).GetComponent<Image>();
        
    }
}
