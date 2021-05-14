using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class NPC : MonoBehaviour
{
    public event Action<NPC> OnInteract;
    public string[] dialogue;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            OnInteract?.Invoke(this);
        }
    }


}
