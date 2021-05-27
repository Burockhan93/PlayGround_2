EventTrigger

Implements interfaces:IBeginDragHandler**, ICancelHandler, IDeselectHandler, IDragHandler***, IDropHandler, IEndDragHandler***, IEventSystemHandler, IInitializePotentialDragHandler, IMoveHandler, IPointerClickHandler***, IPointerDownHandler**, IPointerEnterHandler***, IPointerExitHandler***, IPointerUpHandler**, IScrollHandler, ISelectHandler, ISubmitHandler, IUpdateSelectedHandler




Hadi baslayalim baslik zaten Self explanatory.

1-UIEventler de Interfaceler cok önemli. Ayrica adi üstünde Eventlerle haberlesilio.

2- En basiti ile baslayacam. IPointerClickHandler. Bu EventSystems de basit bir Interface. Dokümantasyona göre kameraya PhysicsRaycaster koymak gerekizyordu onu da koydum. Dokumanstasyondaki scripte sphere koyduk ve oyuna basladik. Oluo evet call back alioz. ama neden.

3- Biz oyun sirasinda mpusela tiklayinca  IPointerClickHandler interface inin bir metodu calisio. Bu metod tiklari yakaliyor.

https://docs.unity3d.com/2019.1/Documentation/ScriptReference/UI.Button.OnPointerClick.html

metod da dbu.

 PonterEventData türünden bir eventdata gelio. Eventdata aslinda bir payload. Event hakkinda bilgi verio.. Bu isin tamaminini UnityEvent kendisi halledio biz sadece bilgiyi yakaliyoz. isi kisaca özetlemek gerekirse kameradan bir ray cikio. bu ray carptigi yer hakkinda bilgi verio zaten istesen de istememsen de. Bu click olayi oluyo yani. üzerinde click edilen nesneyi yönetmek icin iste veya bilgi almak icin bu interfaceler serisini kullanioz 

**TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = transform.GetChild(0).gameObject.GetComponent<TMP_Text>();

***  TMP de Text e böyle ulasioz.

4- Sahnede sunu basrdik. Sphere lar var bunlara script atadik. 3. tikta yok oluolar. Her tik baska bir event uyandirio oda text tarafinda dinlenio ve kacimci tik oldugunu söylüo. bi ilk basamakti. Bence oldu. Simdi hareket ettirlem bkalim ne olacak. Hareket de ediyorlar.

5- Diger interfacelere gecelim.

6- Ama önce su Pointeventerdata classi önemli ona bakalim. Ne oluyor burda.
OnPointerClick eventi click oldu onu söyluor degil mi? Diger Interfaceler diger eventleri uyandiriyor ama yine de bize PointeventerData dönüyorlar burasi cok önemli cünkü bu amq classi her datayi tasiyor. Click mi oldi. Ne kadar click oldu, hangi tusla oldu? bunlari söylüyor bize.

https://docs.unity3d.com/2018.3/Documentation/ScriptReference/EventSystems.PointerEventData.html

burda hangi propertyler var görüoz ama kisaca: button sol sag orta. Time oyun basladiktan sonra gecen süre. Clickcount kac kere bastgn bir seferde arka arkaya. Bu tarz bilgileri kullanadabilirsin ayrica. Meslea

if (pointerEventData.button == PointerEventData.InputButton.Left) bu event sol tusla mi uyandirildi diye soruo. Iste click Count integer deger, ClickTime float deger.

7- Simdi Drag olayina bakalim nasil yapiliyor.Biraz karisik gibi. Aslinda degilmis olayin iskeleti su;

public class Cube : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
   public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
       
    }

    public void OnDrag(PointerEventData data)
    {
        Debug.Log("OnnDrag");
        float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Ended");
    }

burda ne oluyor. Su cok önemli aslinda bu drag olayini UI'de mi yapiorz yoksa dünyada mi yapiorz. Cunku Pointeventerdata bize Canvas üstündeki pozisyonu veriyor. Dolayisiyla biz nesneleri canvas üzerinde hareket ettirorz bu bilgiyle. Biz dedik ki Drag olayini 3D yapalm. Bunu da yapabilirz elbet ama farkli bilgi kullanacagz. O bilgde iste;

float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

bu sayede kamera ve aramizdaki mesafeyi ölcuorz. bunu daha sonra ScreentoWorldden objeyi kontrol ederken kullancaz.

Bu OnDrag eventi bir nesneyi secip mouse u hareket ettirince calisio. Update gibi. Ama hareket olamyinca duruo tabiki. Bu IDragHandler in bir metodu. Diger metodlar da diger Interfaclerin. Biz su an 3D nsnelerle calisiorz diye bu yöntemi kullaniorm sonra inventory yaparken baska kullancaz.


https://answers.unity.com/questions/12322/drag-gameobject-with-mouse.html


AAma burdaki sikinti su 

transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));

bunu kullaninca nesne y de absürt hareket edio.y yi kitlemek icin;

Vector3 v = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));
        v.y = transform.position.y;
        transform.position = v;

söyle bisey yapblrz. Ne oldu simdi? Yaptgmz Vector3 te y degeri hep sabit objenin degeri. böylece nesneyi drag edebiliorz 3 d düzlemde. Begin ve Enddraglar var bir de onlara bakalm. 

8- Simdi onlara da baktik. Yeni bir event tanimladim. DateTime i kullanarak kac saniye drag edildigini ekrana yaziorz. Bu dragTime i hesaplamak yine kullanisli düsününce. Cube lara da bir id verdik falan. Bence bayagi iyi oldu.

9- IPointerDownHandler, IPointerUpHandler

bunlar da basildi/cekildi algiliyor. click ikisinin toplami oluyor. burda da mantik ayni aslinda nesneye ray atiyor. O nesne bu interface i implement etmisse OnPointerUp/Down u dinlio oluyor ve event invoke olunca yanit verior. Bu event invoke oluo her türlü onu dinlemek mesle. bunu da materyalleri degisio kapsulle uyguladik.

10- IPointerEnter, IPointerExit

bunlarin metodlar void OnPointerEnter, ve void OnPointerExit.  Mouse üzerine geldi mi gelmedi ona bakiolar. Bir sikinti burda su olablr. Acaba önüne bir nesne gecse ne olacak. Bakalim test edelm. Burda enteresan bisey deniorz ve rendering modla oynuorz.
Fade denen bir rendering mod var. Bu gölge olayini da yok ediyor ve transparant obje yaratma isini bayagi koaylasitirio.


    Material m;
    Color m1;
    Color m2;


    void Start()
    {
        m = GetComponent<MeshRenderer>().material;
        m1 = m.color;
        m2 = m.color;
        Debug.Log("Enter");
        
        m2.a = 0.3f;
    }
    //Detect if the Cursor starts to pass over the GameObject
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        
        m.color = m2;
        //Output to console the GameObject's name and the following message
        Debug.Log("Cursor Entering " + name + " GameObject");
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        m.color = m1;
        //Output the following message with the GameObject's name
        Debug.Log("Cursor Exiting " + name + " GameObject");
    }

uygulama bu. Rengi ayrica tanimlamamiz gerekiyor cünkü renk class gbi degil anladgm materyalin rengini bu renklere referan ederek degstrcez. O zaman hizli ve kolay oluo.
Kisa bir not. Rendering Modu 4 tane genelde Opaque kullanirz biz ama Fade e gecmek gerek bu özelligi kullanmak icin. Scriptin icinde kisaca Rendering Fade olsun deyince olmuo maalesef. Onun icin ayri uzun bir kod yazimak gerek. Ihtiyac olursa bakarsin.

11- bunu disinda scroll drop falan var bunlara gerek yok gbi ama. 

12- Eventsystem bitti simdil de monobehaviourun icindeki su fonksiyonlara bakalm neymis. Bu objelerde collider olmasi sart. O yüzden GUI de kullanilamaz gibi anladim Yani oyun icinde bu metodlar daha mantikli gibi ama görecez.

OnMouseDown	OnMouseDown is called when the user has pressed the mouse button while over the Collider.
OnMouseDrag	OnMouseDrag is called when the user has clicked on a Collider and is still holding down the mouse.
OnMouseEnter	Called when the mouse enters the Collider.
OnMouseExit	Called when the mouse is not any longer over the Collider.
OnMouseOver	Called every frame while the mouse is over the Collider.
OnMouseUp	OnMouseUp is called when the user has released the mouse button.

Böylelikle bu EEventSystemi kapatiorz ne oldugunu gercekten anladgimi düsünüurm aq.