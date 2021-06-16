using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void onClick()
    {
        Loader.Load(Loader.Scene.UIEvents); //Bu Scenenin adi
    }
}
