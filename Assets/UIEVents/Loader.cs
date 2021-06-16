using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public static class Loader { 

    private class LoadinMono: MonoBehaviour
    {

    }
    public enum Scene
    {
        UIEvents,Loading
    }

    private static Action onLoaderCallback;
    private static AsyncOperation loadingAsyncOperation;
    
    public static void Load(Scene scene)
    {
        // Yeni bir scene yüklemeden önce onLoaderCallback invoke edilio. Invoke edilince burdaki ananonim classa hedef scene atanio
        onLoaderCallback = () =>
        {
            //SceneManager.LoadScene(scene.ToString());
            //SceneManager.LoadSceneAsync(scene.ToString()); // Bu bize scenenin dolma bilgisini dönen bir fonksion.
            GameObject laoding = new GameObject("Loading GameObject Dummy");
            laoding.AddComponent<LoadinMono>().StartCoroutine(LoadSceneAsync(scene));
            LoadSceneAsync(scene);
        };

        SceneManager.LoadScene(Scene.Loading.ToString()); //Önce loading Screen gelsin
        
    }

    private static IEnumerator LoadSceneAsync(Scene scene)
    {
        yield return null;
        loadingAsyncOperation = SceneManager.LoadSceneAsync(scene.ToString());

        while (!loadingAsyncOperation.isDone)
        {
            yield return null;
        }


    }

    public static float GetLoadingFloat()
    {
        if (loadingAsyncOperation != null)
        {
            return loadingAsyncOperation.progress;
        }
        else
        {
            return 1f;
        }
    }

    public static void LoaderCallback()
    {
        onLoaderCallback?.Invoke();
        onLoaderCallback = null;
    }
}
