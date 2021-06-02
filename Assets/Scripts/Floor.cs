using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class Floor : MonoBehaviour
{
    [SerializeField] Material[] m;
    [Header("Kurdu buraya koy lan")] 
    [SerializeField] GameObject kurt;

    public event EventHandler<OnSpaceEventFloor> OnSpacePressed;

    public class OnSpaceEventFloor : Floor
    {
        public int i = 0;
    }
    public event FloorDelegate OnFloorDelegate1;
    public delegate void FloorDelegate(float f);

    public event Action<int, int, bool> OnFloorAction;

    public UnityEvent OnunityEvent;

    private MeshRenderer mesh;
    private int counter;

    // Start is called before the first frame update
    void Start()
    {

        mesh = gameObject.GetComponent<MeshRenderer>();
        mesh.sharedMaterial = m[0];
        OnSpacePressed += FloorChange;
        OnFloorDelegate1 += FloorDelegateEvent1;
        OnFloorAction += Floor_OnFloorAction;
    }

    private void Floor_OnFloorAction(int arg1, int arg2, bool arg3)
    {
        Debug.Log(arg1 );
        Debug.Log(arg2);
        Debug.Log(arg3);
    }

    public void spawnWolf()
    {
        Instantiate(kurt, new Vector3(0, 0, 100), Quaternion.identity);
    }

    private void FloorChange(object sender, Floor.OnSpaceEventFloor e)
    {
        Debug.Log("Heey" + e.i);
        if (mesh.sharedMaterial == m[0])
        {
            mesh.sharedMaterial = m[1];
        }
        else
        {
            mesh.sharedMaterial = m[0];
        }
    }

    private void FloorDelegateEvent1(float f){
        Debug.Log("value : "+f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            counter++;
            OnSpacePressed?.Invoke(this, new OnSpaceEventFloor { i = counter });

            OnFloorDelegate1?.Invoke(5.5f);

            OnFloorAction?.Invoke(1, 2, false);

            OnunityEvent?.Invoke();

        }
    }
}
