using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPool : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> Guns = new List<GameObject>();
    private List<GameObject> gunsonMap = new List<GameObject>();

    [SerializeField] private GameObject map;
    private List<Vector3> mapVertices = new List<Vector3>();
    private List<Vector3> maptoLocal = new List<Vector3>();
    public Vector3[] mapCorner { get; private set; }

    private GameObject[] gunsonSnake;  
    private GameObject currentGun;
    SnakeInventory inv;
    SnakeMove move;
    Transform gunPos;
    Transform shootPos;
    Transform muzzlepos;

    Particles particalEffect;
    ParticleSystem gunEffect;
    GameObject gunEffectIngame;
    private float gunCounter = 0.1f;
    

    // Start is called before the first frame update
    void Start()
    {
        inv = FindObjectOfType<SnakeInventory>();
        move = FindObjectOfType<SnakeMove>();
        gunPos = move.GetComponentInParent<Transform>().GetChild(7);
        shootPos = move.GetComponentInParent<Transform>().GetChild(8);
        muzzlepos= move.GetComponentInParent<Transform>().GetChild(9);

        mapCorner = new Vector3[4];
        

        move.onEquipEvent += Equip;
        move.onShootEvent += Shoot;
        inv.onInventoryRemove += UnEquip;

        gunsonSnake = new GameObject[Guns.Count];
        


        for (int i=0;i< Guns.Count;i++) 
       {
            gunsonSnake[i] = Instantiate(Guns[i], new Vector3(0, 0, 0), Quaternion.identity);

            gunsonSnake[i].GetComponentInChildren<Animator>().enabled = false;

            gunsonSnake[i].SetActive(false);
       }
        for (int i = 0; i < 10; i++)
        {
            int r = Random.Range(0, Guns.Count);
            GameObject g = Guns[r];
            gunsonMap.Add(g);

        }

        GunDeploy();

        particalEffect = FindObjectOfType<Particles>();
        gunEffectIngame = Instantiate(particalEffect.particlesGameobjects[0]);
        //gunEffect = Instantiate(particalEffect.particles[0]);
        //gunEffect.transform.localScale = gunEffect.transform.localScale / 8;       
        //gunEffect.transform.position = shootPos.position;
        //gunEffect.transform.rotation = shootPos.GetComponentInParent<Transform>().rotation;       
        //gunEffect.transform.parent = shootPos.parent;
    }

    // Update is called once per frame
    void Update()
    {
        if (gunCounter <= 0) return;
        gunCounter -= Time.deltaTime;
    }

    void Equip(bool isEquip)
    {
   
        foreach (GameObject g in gunsonSnake)
        {
          if (g.GetComponentInChildren<InterActableObject>().item.name == inv.currentItem.name) currentGun = g;
        }
        

        if (isEquip)
        {
            currentGun.transform.position = gunPos.position;
            currentGun.transform.rotation = gunPos.rotation;
            currentGun.transform.parent = gunPos;
            
            
            currentGun.SetActive(true);

        }else if (!isEquip)
        {
            currentGun.SetActive(false);
        }

    }
    void UnEquip(Item item)
    {
        Debug.Log("yoo");
        currentGun.transform.parent = null;
        currentGun.transform.position = new Vector3(0, 0, 0);
    }
    void Shoot(bool doesShoot)
    {
        if (doesShoot)
        {
            currentGun.transform.parent = null;
            currentGun.transform.position = shootPos.position;
            currentGun.transform.rotation = shootPos.rotation;
            currentGun.transform.parent = shootPos;
            ShootBullets();
        }
        else
        {
            Equip(true);
        }
    }

    void ShootBullets()
    {
        float x = Random.Range(-5, +6);
        float z = Random.Range(-5, +6);
        Vector3 v = new Vector3(x/10,x/10+z/10,z/10);
        

        if (gunCounter <= 0)
        {
            GameObject g= Instantiate(gunEffectIngame);
            g.transform.position = muzzlepos.position;
            g.transform.rotation = muzzlepos.rotation;
            g.transform.parent = muzzlepos;
            g.GetComponent<ParticleSystem>().Play();
            gunCounter = 0.1f;
            Vector3 yön = move.GetComponentInParent<Transform>().forward * 10+v ;
            Debug.Log("Yön: "+yön);
            Ray ray = new Ray(g.transform.position, yön);
            Debug.DrawRay(g.transform.position, yön, Color.green);
            RaycastHit hit;
            if (Physics.SphereCast(ray, 0.05f,out hit, 100,1<<9))
            {
                hit.transform.GetComponent<SimpleEnemy>()?.Damage();
                Debug.Log("Vurduk");
                GameObject go = Instantiate(gunEffectIngame);
                go.transform.position = hit.point;
                go.GetComponent<ParticleSystem>().Play();
            }
            else
            {
                Debug.Log("!");
            }
            
        }

       



    }

    

    void GunDeploy()
    {
        mapVertices = new List<Vector3>(map.GetComponent<MeshFilter>().sharedMesh.vertices);
        foreach (Vector3 point in mapVertices)
        {
            maptoLocal.Add(map.transform.TransformPoint(point));
        }
        mapCorner[0] = maptoLocal[0];
        mapCorner[1] = maptoLocal[10];
        mapCorner[2] = maptoLocal[110];
        mapCorner[3] = maptoLocal[120];
        

        foreach (GameObject g in gunsonMap)
        {
            int x = Random.Range((int)mapCorner[0].x, (int)mapCorner[1].x);
            int z = Random.Range((int)mapCorner[0].z, (int)mapCorner[2].z);

            Instantiate(g, new Vector3(x, 0.25f, z),Quaternion.identity);
        }
        
    }
}
