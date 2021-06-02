using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPool : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> Guns = new List<GameObject>();
    private GameObject[] gunsInGame;
    private GameObject currentGun;
    SnakeInventory inv;
    SnakeMove move;
    Transform pos;

    // Start is called before the first frame update
    void Start()
    {
        inv = FindObjectOfType<SnakeInventory>();
        move = FindObjectOfType<SnakeMove>();
        pos = move.GetComponentInParent<Transform>().GetChild(7);
        

        move.onEquipEvent += Equip;

        gunsInGame = new GameObject[Guns.Count];

        for (int i=0;i< Guns.Count;i++) 
       {
            gunsInGame[i] = Instantiate(Guns[i], new Vector3(0, 0, 0), Quaternion.identity);

            gunsInGame[i].GetComponentInChildren<Animator>().enabled = false;

            gunsInGame[i].SetActive(false);
       }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Equip(bool isEquip, Item it)
    {
   
        foreach (GameObject g in gunsInGame)
        {
          if (g.GetComponentInChildren<InterActableObject>().item.name == it.name) currentGun = g;
        }
        

        if (isEquip)
        {
            currentGun.transform.position = pos.position;
            currentGun.transform.rotation = pos.rotation;
            currentGun.transform.parent = pos;
            
            Debug.Log(pos.position);
            currentGun.SetActive(true);

        }else if (!isEquip)
        {
            currentGun.SetActive(false);
        }

    }
    void UnEquip()
    {
        Debug.Log("yoo");
        currentGun.transform.parent = null;
        currentGun.transform.position = new Vector3(0, 0, 0);
    }
}
