using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterActableObject : MonoBehaviour
{
    public Item item;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.GetComponent<SnakeInventory>().Add(item))
            {
                gameObject.SetActive(false);
            }
           
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, transform.localScale.x/5f);
    }
}
