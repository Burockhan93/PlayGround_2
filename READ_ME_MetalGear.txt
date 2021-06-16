08.06.2021 Notu
Events revisited
----------------------------------------------------------------------------------------
Delegate publisher ve subscriber arasi bir anlasma. Signature burda belirleniyor
Sonra delegate e bagli bir event yaratmamiz
ve bunu invoke etmemiz lazim

pek birsey eklemedik.

event keyword ne ? 

https://www.youtube.com/watch?v=gSwGta2cJ_Y

 
kisa bir örnek

class test{
 public event Action<int,bool> event1;    Bunlaar bizim iki actioimiz
 public Action<int,bool> action1; 


	void Start(){
	event1+= eventMethod1;	       normal subscribe
	action1+= actionMethod1;


	//istersek event1 = null veya action1=null yapablrz.  normal tüm subscribelari 								temizleme
	.....
	
	event1?.Invoke(1,true);          normal invoke
	action1?.Invoke(1,false);
	

	}

	eventMethod1(int a, bool b){}
	actionMethod1(int a ,bool b){}
}

class test1{                                  //simdi isin asil önemli kismi.


test test = new test();

test.event1 += Fonksion1;  // olur
test.action1 += Fonksion1; // olur

test.event1?.Invoke(1,true) // olmaz . fark bu iste. event keywordu biraz private gibi.
				baska bir classin icinden bunu invoke edemiorz. bu event 				yaratildigi ait oldugu classa özel. = null da diyemiorz.
				event keyword kullanmazsak diyeblrz. Aynisi delegat pattern de 				de gecerli.



----------------------------------------------------------------
14.05.2021
----------------------------------------------------------------
Eventlerle basladik. Unity Event degil normal event bu.

1- Önce using systemle baslayalim bu önemli unutma
2- Her eventi bir eventhandler yönetiyor. burda delegasyon gbi birsey var bakacam , bakinca aciklarm. ana olay su 
	
	public event EventHandler OnSpacePressed

bu kod sunu yapiyor. Space e basinca bir event invoke edecegiz.
	
	OnSpacepressed.Invoke(this, Eventargs.Empty) 

	bu da bu ise yariyor. Eventi invoke ettik. Bunu genelde update in icinde tusa basinca invoke etsek de aslinda farkli senaryolar düsünülebilir.Ama su an OnSpacepressed i hicbir alici dinlemiyor. Hata olmamasi icin OnSpacepressed?.Invoke(this, Eventargs.Empty) söyle yaziorz. Null degilse demek.

Son olarak bunu dibleyecek fonksyionlari ekleyelim. OnSpacepressed aslinda bir event arrayi diyeblrz. 

	Onsapcepressed += FloorChange

mesela su demek. Floorchange artik onspace pressedi dinlemeye basladi. Bunu baska classlardan da yapabiliorz o bayagu iyi. Ama Onspacepressedi tutan classa referans almamiz gerek. Biz bu örnekte yazi degistirme ve materyal degistirme yaptik. Isin artisi su, publisher yani invoke edeb class, bunu dinleyen event olmasa da calisiyor bu da modulerlik sagliyor.

Bu bizim dinleyici fonksyionlarin icine ama (object sender, System.EventArgs e) yaziorz

Bunun manasi da su aslinda ekstra information göndermemiz gerekiorsa bunu kullanirz. Nasil yapiyoruz biraz karisik acikcasi. Önce yeni bir class yaratalm bunu disarda da yaratablrz ama innerclass yaptik bu sefer.

    public event EventHandler<OnSpaceEventFloor> OnSpacePressed;

    public class OnSpaceEventFloor :Floor 
    {
        public int i = 0;
    }

Sonra Eventhandlerimizi generic yaptik. Ve bu yeni classi da tip ilan ettik.
Artik bizim bu Eventhandler, invoke ederken ekstra bilgi gönderebilir. Hatta göndermesi gerek. Eventargs.Empty artik yeterli degil daha fazlasi lazim. Onun yerine burda yeni bir anonim class aciort

	Invoke(this, new OnSpaceEventFloor { i = counter })) 

bu ne ise ariyor. kisaca burda biz yeni bir class gönderoioz eventle birlikte yani yei bilgi. Burda bir suru bilgi aktarilabilir ve bu oaly oldukca iyi amq keske daha önce de bilseydim ama biraz karisik. Benim aklima su an mesela save eventi geliyor. eski oyunda cok zorlama bir save sistemi yapmistik. Save eventi sayesinde güncel bilgileri gönderip saveleyeblrdik. Bence burda da ama bir sikinti var o da bunu dinleyen tüm fonksiyonlarin da parametrelerini degistirmesi gerek. Simdi biz invoke la yeni bir new OnSpaceEventFloor gönderiorz. Dinleyenler de parametre olarak bunu almali. 

yani mesela FloorChange fonksiyonu (object sender, Eventargs e) --> (object sender, Floor.OnSpaceEventFloor e) a dönüstü.

3. Simdi su ana kadar Eventhandler kullansak da buna aslinda gerek yok. Eventler aslinda delegatedirlar. Eventhandler da bunu gönderen bir standart. Kendi delegateimizi de yaratabilirz yani. Onu yapalim

    public event FloorDelegate OnFloorDelegate1;
    public delegate void FloorDelegate(float f);

    burda su cok önemli. delegate void FloorDelegate bizim eventin icerigini belirliyor sonra hic kullanmioz onu. OnDelegate1.Invoke edilince icine (5.5f) gbi bir float deger girmemizz gerekiyor o yüzden cunku float bir event u. Sonr olarak startta eventimizin icine bir de dinleyici atmamiz lazim. O da FloorDelegateEvent1
	
	private void FloorDelegateEvent1(float f){
        Debug.Log("value : "+f);
        }

Özetle ;
	
	a) public event FloorDelegate OnFloorDelegate1;     (delegasyon ve event)
           public delegate void FloorDelegate(float f);
	b) OnFloorDelegate1?.Invoke(5.5f); (publisher)
        c) OnFloorDelegate1 += FloorDelegateEvent1; (dinleyici)
	d) bu da yukardaki fonksiyon float argüman almak zotunda.

yazi classinda da  floor.OnFloorDelegate1 += Floor_OnFloorDelegate1;->
  private void Floor_OnFloorDelegate1(float f)
    {
        Debug.Log("Yazidaki float floor event " +f);
    }

4. Bu delegate bir void demistik ve bunu bir eventin temsil etmesi gerekiyordu. Turns out bunun default bir varyasyonu var ona da Action deniyor

	public event Action<int, int, bool> OnFloorAction; //bilgiyi yine generic gönderebilioz

	OnFloorAction?.Invoke(1, 2, false);

	OnFloorAction += Floor_OnFloorAction; (startta da eklioz bunu yine)

	private void Floor_OnFloorAction(int arg1, int arg2, bool arg3)
    {
        Debug.Log(arg1 );
        Debug.Log(arg2);
        Debug.Log(arg3);
    }

yazi clasinda da ayni durum gecerli.	

5- unity evente bir örnek var.
	using UnityEngine.Events yazdiktan sonra bir event tanimliorz public UnityEvent OnUnityEvent;
	OnUnityEvent?Invoke(); buna sonra editorden bir function falan kpyabilioz iyi yani bayagi;

6- Delegatelar https://www.youtube.com/watch?v=3ZfwqWl-YI0

7- https://www.youtube.com/watch?v=oc3sQamIh-Q&t=63s  burda da farjlar anlatiliyor kisaca su bunun örnegini yapacam ama yine de yazaym

	UnityEventi editörden modofoye edebldgmz icin, Birden fazla seyin birden fazla objede meydana gelmesi halinde isimizi kolaylastrr. Mesela öldük, OnDIeEvent basliyo. Bütün düsmanlar respawn olacak, Can Barimiz geri dolacak, Checkpointe respwan olacaz. 3 farkli obje iste.

	Ama diyelim ki, düsmanin birini öldürdük. O durumda sadece düsman ölecek. o kismi Actionla yapablrz iste yani normal eventsle. Tüm dusmanlar ölüne de unity eventi uyandirrrz. Easy hadi bakalm.


------------------------

1- Eventerle ilgili calismaya baslamadan önce snake i sahneye aldik. Materyalerrin shadeeri unlit>texture olamli yoksa olmuyor.

2- Charcter controller ve animator kurduk bunlar gelistirilecek tabi simdilik olmadi. Has exit Time i uncheck yapmak cok önemli yoksa animasyon bitmeyi bekliyor. Bizim animasyonlar digerlerini bölmeli (interrupt)

3- NPC leri kuralim.Zuuuuuuaaaa kurduk.
Anlatiyorum simdi;

4- NPC adli skript yazdik. Ayrica bir de NPC Manager yazdik. NPC Manager bos bir gameobject sahnede. Bunun icine NPC türünden bir public arry kurduk. Ayrica TextMeshproUGUI i de bu yönetiyor. Bu dinleyici konumunda. Bu kenarda dursun. NPC adinda da bir scriptimiz vardi bunu prefab yaptik sahneye prefab yerestirioruz. Sonra bunlari bir de NPC Managera ekliyoruz manuel. otomatik de yapilablr sonra bakariz.
NPC nin icinde bir Action var ve bir diyalog var. Bu string array. Icinde tek komut var o da, Player collidera girince ontrigger enter calisoyr ve bu action i invoke ediyor. Action<NPC> genric yaptik. this yaziyoruz icine. bu sayede bu NPC nin tüm bilgilerini Actionla birlikte gönderiorz. Simdilik mesela sadece diyalog ama ilerde kodeks icin resim falan da olablr. 

public event Action<NPC> OnInteract;
    public string[] dialogue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            OnInteract?.Invoke(this);    Bu soru isareti dinleyen varsa demek.
        }
    }

5. NPC Manager biraz daha kompleks buna göre ama sikinti yok. testi ve NPC fieldlarini anlatmistik. Simdi Startta bu NPC arryinin ciindeki actionlari dinliyoruz. Bunu nasil yapiyoruz peki. Kolay!
foreach (NPC npc in npcs)
        {
            if(npc!=null)npc.OnInteract += HandleDialogue;
        }

burda sunu yaptik. arrayde npc lerimiz var. 2 tane de null var. o iki null u s.et. npc lerin icinde OnInteract actionu vardi. o actiona iste handlediolgue metodunu uyguluyoruz. Burda birden fazla metod eklenebilir. burda en en en önemli husus, Action<NPC> bir jenerikti o yüzden bu fonksyion da bu NPC türünden bir argüman almali. Bu en önemlisi. Burda unutmamak gereken bir de su var. 

Diyelim ki bu Handler bize birsey dönmesi lazim. O durumda Action kullanamioz. Niye cunkü Action "void delegation" . kendi delegationimizi üretmemiz gerekir ki bu aslinda nadir bir durum.

6- Bir de UnityEvent ekledik. standart bir event bunu yaninda float gbi seylerle override edip bir daha denemek gerek. Denendi ayni sey oluyor.
----------------------------------------------------------------
15.05.2021

7- Su konu cok sikinti hala kisaca anlatiorm. OBJ file model. MTL file da bu modelle materyala gelcek resimler arasinda köprü. Unity salak oldugu icin bunu manuel yapmani istio. Blenderi aciosn z ye basinca preview cikio. Ordan görünüo aslinda mevzu. bir sikinti bazen mtl dosasinin adi obj nin ciinde iyi referans verilmemis olablr. herneyse. Blenderdan ayrica save as deyince oluyor. texture lari daha sonra tek tek ayarlamak gerekio. Ne demek bu. Obj nin üstüne geliosn unity de. tiklayinca sahda Model, Rig, animation ve Materials var. Ordan extract materilas diosn. Yeni klasöre orayi saveliosn. Ondan sonra o materyaleer üzerinde oynama yapablrsn ve hopefully bütün materyaller oturmus olur. 2 saat aradm baska birsey bulamadm. Bu kadr yani. Burd takildikca isin animasyon rig vb. alanlarina daha cok giriorz o olmasin diye burdan simdilik cikiyorum.

Simdi halletmemiz gerekn önce 3 Konu Animasyonlar, Inputlar,3. sahis kamera kontrolü.  Eventler i hallettik Rig konusunu da vakit bulunca incelerim.
------------------------------------------
3.Person Cam

8-https://www.youtube.com/watch?v=4HpC--2iowE  video bu buranin üzerine konuscz

9- Cienmaschine i indirdik package managerdan zaten bakacaktik iyi oldu. Üstte Cinemascine den frre looku ekledik. adini 3rd camera yaptm. Simdi olay su bunu ekleyince maincam e bir brain ekleniyor bu brain sayesinde oyunu 3rd camden görüorz artik main camden degil. Bu otomatik oluyr. 3rd camerada look at ve followa snake i ekledik. burda bir düzeltme snake in pozisyonu yerde oldugu icin iceriye bir gameobject ekledim lookat e onu koydum snake in beline falan geliyo. onu takip etmek istioz cünkü. Cinemaschine in ögrenecek cok yei var ama temelinde kamera kontrolünü anladim gbi tek eksik awake de bottom rinden dogmasi ona da bakacaz.

Buraya dönecez!!!!!!!!!!!!

10- SnkaeMove adinda yeni bir harekt scripti actik. Basit bayagi anlatimdan bakarsin.

public CharacterController controller;
    public Transform cam;

    public float speed;
    private float _smoothTime = 0.1f;
    public float turnSmoothVelocity;

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(horizontal, 0, vertical).normalized; // toplamlari biri gecmesin diye normalini aliyorz

        if (dir.magnitude > 0.01) // eger girdi varsa bu da büyüktür dogal olarak 0 dan
        {
            float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg+ cam.eulerAngles.y; // dönmek istedgmiz acinin derecesi = formul. sondaki carpi radyalden dereceye cevirdi. ona bir de kameranin y sini ekledik böylece kameranin baktigi yere bakiyor.
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref 	    turnSmoothVelocity, _smoothTime); // bu da kendi y derecemizden hedef y dereceye yumusak dönüs formulu. asagida rotationin icine bunu yazinca yumusak dönüorz.
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }
------------------------------------------
Input Handling,Animation Handling

11- https://www.youtube.com/watch?v=7Ns8nwYIxDU&t=45s bu videoya bakaak hallettcez bu isi bence cok mantikli. buna bir de state durumu ekleyelim enumaratorle animasyonlari rafine edelm. Cinemaschine i cilalayalm al sana mükemmel gameplay.

12- Mantik basit, Inputlari kaydeden bir sinif ve normal hareket siniflari ayri ayri olusturcaz.

[RequireComponent(typeof(SnakeInput))]  bu komutu snakemove un icine yaziorz ki hani snakeinput yoksa eklensin otomatik. aslinda cok gerekli degil. Neyse devam. Yine de buna bir referans yaziorz ve awakede yakliorz onu.

PlayerInputun icine de inputlari okyacak degiskenleri atiorz.

public float movementInput {get; private set;}  // get mümkün ama set private
public bool jumpInput {get; private set;}

private void Update()
    {
        movementInput = new Vector3 (Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        jumpInput = Input.GetKeyDown(KeyCode.Space);
    }

bunlarin manasi ne? cok kolay Input sonucu gelen vector3 u snakemove da degil snakeInputta tutuyoruz. Daha sona da snakemovea gönderiorz.

SnakeInputa iki tane daha eleman koyduk iste ziplama ve cömelme.
13- simdi gelelim SnakeMovea. Bu script cok kapsamli oldu belki hareketleri de tek tek bölmekte fayda var ama neyse.

enum SnakeState simdlik burda stateleri tutuyoruz ama kullanmiyoruz bunu degerlndrcez.
SnakeInput referansimiz var
CharacterController , Cinemashine cam transfomeri, belki bir rigidbody ayrica capsul colliderimiz var.
walkspeed ve runspeed walk ve run eventlerinde kullanilan hiz acikcasi. baska birse ydegil
smoottime ve turnsmoothvelocity dönüsleri yumusak yapmamizi saglayan kodun parcalari onlar önemli uutmamak lazim yukarda aciklanmisti.

public event Action<Vector3> onWalkEvent;
    public event Action<Vector3> onRunEvent;
    public event Action<bool> onCrouchEvent;
    public event Action<bool> onJumpEvent;
    public event Action onIdleEvent;

bunla bizim burdaki eventlerimiz. her event bir bilgi tasiyor. Actionlar saolsun. Idle hicbirsey tasimiyor dogal olarak.

startta;
	onIdleEvent += Idle;
        onWalkEvent += Walk;
        onRunEvent += Run;
        onCrouchEvent += Crouch;
        onJumpEvent += Jump;

her birine bir fonksion atadik.

private void Update()
    {
        Debug.Log(controller.isGrounded);

        doesIdle();
        doesMove();
        doesJump();
        doesCrouch();
        doesRun();

       
    }

update de tek tek kontrol ediyoruz kriterleri. bu fonksyionlar eger kriter saglaniyorsa, dinleyici methodlari cagiriolar.
örnegin; 

private void doesMove()
    {
        Vector3 dir = _snakeInput.movementInput;
        if (dir.magnitude < 0.1) return;
        if (_snakeInput.sprintInput)
        {
            snakestate = SnakeState.Run;
            onRunEvent?.Invoke(dir*2);
            return;
        }
        snakestate = SnakeState.Walk;
        onWalkEvent?.Invoke(dir);
        
    }

snkaInputtan hareket vectorunu aldik. eger 0.1 den kucukse idle, buyukse walk, eger ekstra bir de sprinte basiliosa run eventleri invoke edilio

burda onlari dinleyen metodlarda iste startta verdgmiz metodlar.

tabiki rafine edilecek cok sey var burda.

14- Simdi de bir Animationhandler yaptik bu da ayni sekilde SnakeMovedaki actionlari dinliyor ve biri invoke edilince animationu yönlendirio. Bu sebeple SnakeMove a ve Animatorune ihtiyaci var. onlara referan aliyor.

 private void Start()
    {
        _snakeMove.onIdleEvent += Idle;
        _snakeMove.onWalkEvent += Walk;
        _snakeMove.onRunEvent += Run;
        _snakeMove.onCrouchEvent += Crouch;
        _snakeMove.onJumpEvent += Jump;
    }
    void Walk(Vector3 dir)
    {
        _anim.SetFloat("Walk", dir.magnitude);
    }

surda da bir örnek var dedgim gbi oldukca straightforward.
idle da ekstra 0 yaptik ki garanti hareket dursun.

***Tabi olay bu kadar degil burda animationlar hakkinda bilgilendirme yapmasak olmaz.
Öncelikle animationlarin bulundugu fbx'te Loop time ve Loop Pose secili olmali ki, animasyon loop etsin ve animasyon sirasinda hareket olmasin öne arkaya bu sayede animasyonlar birbine güzel baglanir. Bunun bir baska yolu olarak da playeri bos bir gameObjectin altina atmak tavsiye edilio. bunu cok tavsiye ediolar aslinda. Bizim burda bir de olayimiz su;

**** Avatar sadece bir snakede var. onun avatari(rigli obj iste) kullanioz ama ondaki texturelar sikintili oldugu icin baska bir Snake yapi o isi orda halletmistim. yani su an elimizdeki Snake baska bir avatari kullanio kendine ait degil. Animasyonlar da maximodan tek tek indrdgmiz modellerin icindeki animasyonlar. bunlari controllr icine atiorz. Ortaya bayagi karisik oldu yani.

** Controller demisken, transitionlarda has exit time kapatmayi unutma. Settingsde bir de fixed duration var ama allah kerim.

------------------------------------
16.05.2020

*Simdi su exit time in olayi anladim. Exit time check atilmissa animasyon en az bir kere oynayacak demek. o yüzden ziplama animasyonunda check var. 
Kisca söyle; input Keydown ile aliniyor ve Update metodunun icicnde. yani tum saniye boyunca sadece bir FPS de true oluyor biz de onu yakalayip eventi calsitirioz. O esnada tekrar false oluyor bu input. Yani idle a geri dönüyor. Iste burayi optimize etmemiz gerek bugun sürekli false a dönmememli. Jump animasyonuna has exit time kpydugumuza animasyonun bitmesini bekliyor ondan sonra idle a geri dönüyor.

15- Bu Baglamda; 

void doesJump()
    {
       snakestate = SnakeState.Jump;
       onJumpEvent?.Invoke(_snakeInput.jumpInput);
       
    }
    void doesCrouch()
    {
       snakestate = SnakeState.Crouch;
       onCrouchEvent?.Invoke(_snakeInput.crouchInput);
    }

    void doesRun()
    {
        
        bool isRun = _snakeInput.sprintInput;
        snakestate = SnakeState.Run;
    }

bu metodlara if koymadim. Zaten false oldugu zaman da false ifadeler gönderilecek actionda. Animator de degerleri false atayacak. Animasyon da calismyacak. event her daim avr bilgi gönderio. Ama deger false olunca animasyon yok. Walk ve Run birbiryle baglantili oldugu icin,

private void doesMove()
    {
        Vector3 dir = _snakeInput.movementInput;
        if (dir.magnitude < 0.1) return;
        if (_snakeInput.sprintInput) {
            onRunEvent?.Invoke(dir);
            return;
        }
        onWalkEvent?.Invoke(dir);
        
        }

su metod bu isi yapior bunlar adina.
Simdi de animasoynlarda wlakdan jumpa, rundan jumpa ve geri dünüsleri ekleyelim.

16- Walkdan yeni bir transition koyduk jumpa burda tek kosul jump boolean degeri true olsun yeter. burda exit time koymuorz cunku walk animasyonuun her aninda burdan cikabilmemiz lazim interrupt olabilmeli. Ama geri transitionda has exit time var. neden cunkü en az bir kere jumpi görmeliyiz. yani has exit time demek animasyon süresi bitmeden transition gerceklesmeyecek demek. Orda ufak bir hata olsa da walk jump arasi da halloldu. Simdi bir animasyon derslerine bakalim. Rig falan ögrenelim sonra dönecegiz bu projeye. 

****Haftalar sonra buraya su notu düseyim animasyon isine baktim rig mig ögrendik örnek calismalar mevcut. Ama READ_ME dosyalarini dagittigim icin burdan göremiorz.

17- GunPool objemiz var bu arkadas ne yapio. Bizim hrita plane. Planelerin local koordinatlari hep ayni imis. sol uctaki kenar mesela 5,0,28 öteki 5,0-28 sol alt -5,0,28 ve -5,0,-28.map bizim PlaneGameObject olsun,

mapVertices = new List<Vector3>(map.GetComponent<MeshFilter>().sharedMesh.vertices);
        foreach (Vector3 point in mapVertices)
        {
            maptoLocal.Add(map.transform.TransformPoint(point));
        }
        mapCorner[0] = maptoLocal[0];
        mapCorner[1] = maptoLocal[10];
        mapCorner[2] = maptoLocal[110];
        mapCorner[3] = maptoLocal[120];

bu kodla dört kenardakinoktanin global koordinatiialiorz. cok islevsel. 0,10,110,120 kenarlara tekabül edio geriye kalan noktalari salla zaten.

Bu sayede oyun baslyinca hangi silahlari nereye instatiate edecez onu ayarlioz.

GunPoolun bir diger görevi snake in equip edecegi silahlar. Bunlar snake in ustunde doguo ama hepsi deaktive edilio.

for (int i=0;i< Guns.Count;i++) 
       {
            gunsonSnake[i] = Instantiate(Guns[i], new Vector3(0, 0, 0), Quaternion.identity);

            gunsonSnake[i].GetComponentInChildren<Animator>().enabled = false;

            gunsonSnake[i].SetActive(false);
       }
       
Bir diger görevi equip ve unequip. Bunlar eventlere karsilik.

Sonra Shoot var bu da eventle invoke oluo ve current silahla hedef alio

ShootBulelts da random bir spread vererek ates ettirio. ayrica ray ciziorz ates ettgmz yere. Ates alani da spherecast le taraniyor.