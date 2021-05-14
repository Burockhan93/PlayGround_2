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
	
	a) public event FloorDelegate OnDelegate1;     (delegasyon ve event)
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

6- Bir de UnityEvent ekledik. standart bir event bunu yaninda float gbi seylerle override edip bir daha denemek gerek.

7-


