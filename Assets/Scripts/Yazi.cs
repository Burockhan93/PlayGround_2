using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yazi : MonoBehaviour
{
    public Floor floor;
    // Start is called before the first frame update
    void Start()
    {       
        floor.OnSpacePressed += FlooerEvent_OnSpacePressed;
        floor.OnFloorDelegate1 += Floor_OnFloorDelegate1;
        floor.OnFloorAction += Floor_OnFloorAction;
    }

    private void Floor_OnFloorAction(int arg1, int arg2, bool arg3)
    {
        Debug.Log("Yazida ki action");
        Debug.Log(arg1);
        Debug.Log(arg2);
        Debug.Log(arg3);
    }

    private void Floor_OnFloorDelegate1(float f)
    {
        Debug.Log("Yazidaki float floor event "+f);
    }

    private void FlooerEvent_OnSpacePressed(object sender, Floor.OnSpaceEventFloor e)
    {
        gameObject.GetComponent<TextMesh>().text += "yo"; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
