using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderCallBack : MonoBehaviour
{
    private bool isFirstUpdate = true;

    private void Update()
    {
        if (isFirstUpdate)
        {
            isFirstUpdate = false;
            Loader.LoaderCallback(); //Yani bu scriptin ilk Update metodu cagrilmissa artik Loader classindaki metodu cagriiroz.
                                     //Bu metod Loading Scene garanti nir kere buraya cikacak dior. 
        }
    }
}
