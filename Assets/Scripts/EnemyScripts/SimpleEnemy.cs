using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{
    private StateManager currenstate;
    public int health { get; set; }
    private bool isChase;
    
    Vector3[] arr = new Vector3[2];
    public Transform enemy;
    bool is2;
    public float distance;
    
    void Start()
    {
        currenstate = GetComponent<StateManager>();
        health = 100;

        arr[0] = new Vector3(5, 0, -28);
        arr[1] = new Vector3(5, 0, -38);
        Debug.Log("aa: " + arr[0]);
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(this.gameObject.transform.position, enemy.transform.position);
        Debug.Log(distance);

        if (health <= 0)
        {
            gameObject.SetActive(false);
        }

        //Move();
    }
    public void Damage()
    {
        health--;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 1);
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        enemy = other.gameObject.GetComponent<Transform>();
    //        isChase = true;
            
    //    }
    //}
    public void Move() {

        //if (!isChase)
        //{
            if (Vector3.Distance(transform.position, arr[1]) >= 1 && !is2)
            {
                transform.position = Vector3.MoveTowards(transform.position, arr[1], 10 * Time.deltaTime);
                transform.LookAt(arr[1]);
                if (Vector3.Distance(transform.position, arr[1]) <= 1)
                {
                    is2 = true;
                    
                }
            }
            else if (Vector3.Distance(transform.position, arr[0]) >= 1 && is2)
            {
                transform.LookAt(arr[0]);
                transform.position = Vector3.MoveTowards(transform.position, arr[0], 10 * Time.deltaTime);
                if (Vector3.Distance(transform.position, arr[0]) <= 1)
                {
                    is2 = false;
                }
            }



    }
        //else
        //{
        //    transform.LookAt(enemy);
        //    transform.position = Vector3.MoveTowards(transform.position, enemy.position, 1 * Time.deltaTime);
        //}
       


    //}
    
}
