using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public GameObject player;

    Vector3 distance;

    private void Start()
    {
        distance = player.transform.position - transform.position;
    }

    private void LateUpdate()
    {
        transform.position = player.transform.position-distance; 
        transform.LookAt(player.transform);
    }
}
