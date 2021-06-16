CodeMonkeyin bir videosu var o ibne de Unity den almis diertk ona bir bakalm. B8ir yandan da Documantation okuorz.

Bunu UI'li Scene e uygulayalim.

1- Loader classi kurduk static. enum larla caliscza string yerine UnityEngine.SceneManagement kullanmayi unutma.

2- Loading Scene yaptik ayri bir tane oraya görsel falan ekledik Image fill diyerek detayina sonr da bakarsin.

3-  public static void Load(Scene scene)
    {
        SceneManager.LoadScene(Scene.Loading.ToString()); //Önce loading Screen gelsin
        SceneManager.LoadScene(scene.ToString());
    }

Load metodu bu Loader classi icinde bir de ButtonScene metodu var o tusa atildi sadece önemli degil pek.

4- Bir sikinti yine var Iki scene arka rkaya load oldugu icin loading scene görünmüyor öteki scene e gecio direkt.Onu düzeltmek icin bir LoaderCallback yaratiorz.Bir event kullanarak bunu asabiliorz.

5- SceneManager.LoadSceneAsync(scene.ToString()); su fonksiyon bize bu degeri senkronize olarak verio. Ama bunu coroutuine icinde kullanin demis Unity. Dolaysyla Corotutinr yapip Loading Screnede bar yapacaz. ama onun icin de Monobehaviour a ihtiyac var. private bos bi class yaptik ve bu MonoBehaviouru inherit ediyor. Simdi bunu onCallBackte bos GameoBject yaratip icine atiorz. 

6- private static AsyncOperation loadingAsyncOperation;

ve 

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


bunlar da bize progresi verior. Loading Barda buna göre bir loading yapiyoruz. Loadingler arasina transition koysak loading daha guzel görünebilirdi ama bu isin de sirri bu. Bu da böyle.
--------------------------------------------
Simdi biraz da SceneManager takilalim.

Cok fazla bir metodu yok.

Description
Scene management at run-time.

----Static Properties----
sceneCount	The total number of currently loaded Scenes.
sceneCountInBuildSettings	Number of Scenes in Build Settings.

----Static Methods-------
CreateScene	Create an empty new Scene at runtime with the given name.
GetActiveScene	Gets the currently active Scene.
GetSceneAt	Get the Scene at index in the SceneManager's list of loaded Scenes.
GetSceneByBuildIndex	Get a Scene struct from a build index.
GetSceneByName	Searches through the Scenes loaded for a Scene with the given name.
GetSceneByPath	Searches all Scenes loaded for a Scene that has the given asset path.
LoadScene	Loads the Scene by its name or index in Build Settings.
LoadSceneAsync	Loads the Scene asynchronously in the background.  =========> bu sayed aktif scene de kalabaliyor veya Loading Scenede bar cikartabilioz
MergeScenes	This will merge the source Scene into the destinationScene. === >  Iki scenei birlestirme ve yeni bir scene olstrma iyi gibi.
MoveGameObjectToScene	Move a GameObject from its current Scene to a new Scene. ====> Bir scene a gameobject gönderme mesela önceki sceneden düsman buraya gelio
SetActiveScene	Set the Scene to be active.
UnloadSceneAsync	Destroys all GameObjects associated with the given Scene and removes the Scene from the SceneManager.

-------Events---------
activeSceneChanged	Subscribe to this event to get notified when the active Scene has changed.
sceneLoaded	Add a delegate to this to get notifications when a Scene has loaded.
sceneUnloaded	Add a delegate to this to get notifications when a Scene has unloaded.




