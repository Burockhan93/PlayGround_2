InPut System

Changing input system
https://answers.unity.com/questions/1689706/how-do-i-switch-back-from-the-new-input-system-to.html


https://www.youtube.com/watch?v=IurqiqduMVQ&list=PLwyUzJb_FNeTQwyGujWRLqnfKpV-cj-eO&index=9
Simdi herseyden önce sahneyi hazirladik.

1- 3 animasyonu skinlerle indirip bunlari rigi humanoid yaptik. Apply dedik. Animasyonlari burdan ayirdik. Idle i sahneye atince zaten animator otomatik geldi. ve avatari da humanoid di yarattgmz

2- Animasyon settingis kurduktan sonra bir hata cikio. Kostukca bu eleman saga sola kayiyor bunu sebebi. Animasyon ayarlarindaki bake into Pose da yatio. Kosu animasyonunda hata olduug icin buraya geldik. buna tiklayip sag üstten animation secenegine girdik. cözüm de basit root transformation dan original i secip bake into pose dedik. bunu hallettik

3- Package manager acilmadigi icin internet gelene kadr erteliorz


4- Character COntrollerla ilgili ufak bir viceo.
https://www.youtube.com/watch?v=e94KggaEAr4&list=PLwyUzJb_FNeTQwyGujWRLqnfKpV-cj-eO&index=10 (Buranin icerigi cok önemli tekrar tekraar bak)

Character Controller fizik motorundan yararlanilarak yapilmi bir class aslinda. Icinde collider da var movement ve colliderlari halledio. Merdiven egim falan cikabilio.

Rigidbody de var bunun yaninda fizigi iyi kullaniyor. Fizik dünyasina dahil etmek istedgmiz herseye rigidbody ekliorz. Kinematic gravoity den ve diger rigidbodylerden etkilenmio. Ama collisiolari taniyor. iste bu kisim önemli. O yüzden carpismalara ne etki verecek biz belirleyebilioz

https://www.youtube.com/watch?v=UUJMGQTT5ts

su videoda da chaarcter controller anlatiliyor bakalm.

5-
20.06.2021 de devam ediyoruz burdan. Yapilan degisiklikler sonucu, Universal Pipeline ve Guthub Large File olayi, eski modellerimiz yokolmus o yuzden videoda belirtilen linkten robotu ekledik asset store. Onla ortak caliscaz.

Bu robotu sonra Models kismindaki modeli InputTest klasörüne aldim. Ordan da rigi humanoid yaptim ki eldeki animasyonlarla calissin. Sonra u arkadasi sahenye attik.

Yalniz eldeki animasyonlar yerinde saymaya yönelik oldugu icin bunlari da kullanmicaz gibi. Robotla gelen arkadasi kullancaz. Onunkiler de yerinde sayiyor amq. Kodla hareket sart. apply Root Motion ise yaramadi. 

**********Bu akk character Controlleru Translati etkilio. Transform verilerini kendi yönetio o yuzden Transform.translate ise yaramiyor.*********** Bunun yerine Move metodu var.

6- Charcter Controllrü ekledik nesneye. Bos GameObject parent ona ekledik robot sadece bir nesne öyle. 

Min Move Distance: Bazen bir takim sebeplerden ötürü nesne durmuyor. Bu deger sayesinde cok ufak kaymalar in önüne gecilio cok cok ufak deger vermek gerek

Skin Width: bu arkadas enteresan. Charcter Controller bir colliderla calisio aslinda. Skin Width de ektra bir layyer bu colliderin üstüne. Herhangi bir collidera tam dik carpisinca colliderlar ic ice gecmesin diye bu devreye girio ve öteki colliderla araya mesafa koyuyor.

Step Offset: Merdiven cikma yüksekligi. bunu tek Characteer controller olmadan yapmaya calissan bayagi sürer. Yok carpismayi algila Collision , Collider vesaire. Elemanlar bunu implement etmis kendinden ve bayagi da iyi calisio. Burdaki deger mesela 0.3 söyle hesaplanio. height degerine bakiosn bu colliderin heighti. Bunun en altindan yukari bir ok cik. 0.3 e kadar olan yükseklikler gecilio iste.

Slope Limit: Yine bu merdivenin egimi.

ChaarctrController Propertyleri:

detectCollisions :	Determines whether other rigidbodies or character controllers collide with this character controller (by default this is always enabled). Bunun olayi su collsion yasansin mi yasanmasin mi. Deaktie edince collisionlar iptal oluyo. Herhangi bir collider yani Rigidbody bunun icinden gecio.

enableOverlapRecovery	Enables or disables overlap recovery. Enables or disables overlap recovery. Used to depenetrate character controllers from static objects when an overlap is detected. Static objeelrin icinden gecersen bir sekilde hemen disari atio.

collisionFlage, isGrounded da buna dahil. Üc bölme var collisionda alt (isGrounded),orta ve yukari

	isGrounded : Bu iste enteresan yere carpinca veya yere degince true döndürmesi lazim. 

Ama dönmüyor. Bunun sebebi o eksende bir hareket olmasi lazim o sirada onla akalali. Yani asagi dogru düsüosan o anda bir collision tespit edilince true olablr.

Velocity: Move ve SimpleMovedan gelen degerler sonucu ortaya cikan hiz.

SimpleMove kendinden TimedeltaTime uzguluyor ve default gravitysi var.

OnControllerColliderHit, Eger biz bir objeye carparsak onu ucuruoz mesela. Collider tespit edilince birseyler yap diyeblz.
 Bunu uyguladik.

private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rb = hit.rigidbody;
        rb.AddExplosionForce(10f, hit.transform.position,5f);
    }

Yerin rigidbodysi olmadigi icin tabi ki hata verio ama "ControllerColliderHit" classinin sahip oldugu paramaetresi olanlar 

//
    // Zusammenfassung:
    //     ControllerColliderHit is used by CharacterController.OnControllerColliderHit
    //     to give detailed information about the collision and how to deal with it.
    [RequiredByNativeCode]
    public class ControllerColliderHit
    {
        public ControllerColliderHit();

        //
        // Zusammenfassung:
        //     The controller that hit the collider.
        public CharacterController controller { get; }
        //
        // Zusammenfassung:
        //     The collider that was hit by the controller.
        public Collider collider { get; }
        //
        // Zusammenfassung:
        //     The rigidbody that was hit by the controller.
        public Rigidbody rigidbody { get; }
        //
        // Zusammenfassung:
        //     The game object that was hit by the controller.
        public GameObject gameObject { get; }
        //
        // Zusammenfassung:
        //     The transform that was hit by the controller.
        public Transform transform { get; }
        //
        // Zusammenfassung:
        //     The impact point in world space.
        public Vector3 point { get; }
        //
        // Zusammenfassung:
        //     The normal of the surface we collided with in world space.
        public Vector3 normal { get; }
        //
        // Zusammenfassung:
        //     The direction the CharacterController was moving in when the collision occured.
        public Vector3 moveDirection { get; }
        //
        // Zusammenfassung:
        //     How far the character has travelled until it hit the collider.
        public float moveLength { get; }

bunlarla iletisime gecebilio. Su an sahnedeki küreleri mesela firlatioz. Tam o esnada Collision yuzunden biz de havaya ucuoz su an onu iptal edelim.

private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.rigidbody != null)
        {
            CollisionOnOff();
            Rigidbody rb = hit.rigidbody;
            rb.AddExplosionForce(10f, hit.transform.position, 5f);
        }
        
    }

    void CollisionOnOff()
    {
        if (cc.detectCollisions == false) {

            cc.detectCollisions = true;
            return;
        }
        cc.detectCollisions = false;
        Invoke("CollisionOnOff", 1);
        
    }

söyle birsey yaptik ama cok ise yardi diyemem acikcasi. Neyse Simdi bu kadar Character Controller yeter. Simdi New Input Systeme gecelm.


-----------------------------------------------------------------------------------
inPut ve ANimaton    -     https://www.youtube.com/watch?v=bXNFxQpp2qk
-----------------------------------------------------------------------------------

1-gerekli animasyonlari indirip humanoid yaptiktan sonra animasyonu duplike edip gerisini sildik.

2- bizim robotu da humanoid yaptim. Bir de generic versiyonu var elimizde.

3-Önceki asamalri tekrar edip belli bir animasyon düzenegi kurduk.

4- Burda bir crash yasadik. Kisaca abi Create > Input Action

3 tane sey gelio ilki Map ona bir isim yaz gec 

ikincisi Bindingler tus bindinglerini burdan ayarlio

3. su de value deger falan. burda da tus nasil ayarlion ona bakion kafan karisirsa dön bak videoya- Asset i save edion Generate class dion.

NewControls controller;

    Vector2 movementInput;
    Vector3 movement;
    bool isJump;
    bool isRun;

    
    private void Awake()
    {
        controller = new NewControls();
        controller.CharacterContol.Move.started += context =>
        {
            movementInput = context.ReadValue<Vector2>();
            Debug.Log(movementInput);
        };
    }

su sayede dosyalari okuyabiliosn artik.

private void OnEnable()
    {
        controller.CharacterContol.Enable();
    }
    private void OnDisable()
    {
        controller.CharacterContol.Disable();
    }

bunu da ekle ki sürekli dinlesin (ne anlami var bilmiom)

Bu yukardaki started player basmaya basladi demek, birakti cancelled devam edio performed bu ücü de ayri ayri callbackler. hepsini uygulamak lazim. Tamolarak performed bu ise yariyor.
bu ücünü bir metod ucunde yazacaz.

bu metod icin kosul

using UnityEngine.InputSystem;

InputAction.CallbackContext argüman olacak bu sayede callback degerlerini burda islicez. context de argümani

controller.CharacterContol.Move.started += onMoveInput;
        controller.CharacterContol.Move.started += onMoveInput;
        controller.CharacterContol.Move.started += onMoveInput;

bunlar event oldugu icin iste awake de bunlari dinlemeye basliorz subscribe ediorz.

so far sogood ama sikinti var drifting issues. 

Edit ten Project Settingse geldik ordan Input managerdan deadzonu artirdik cözüldü diyeblrz. Su büük problem yine, Input Manager böyle oldugu sürece diger inputlar calismayack. bu manager evet bayagi kolay ama uygulamasi daha zor ve bilgi gerektirio. Bir projeye baslamadan önce ne istiorz onu sormamiz gerek cidden.

5- Simdi animasyonlar.

void handleAnim()
    {
        bool isWalk = anim.GetBool("isWalk");
        bool isRun = anim.GetBool("isRun");
        bool isJump = anim.GetBool("isJump");

        if (isMove && !isWalk)
        {
            anim.SetBool("isWalk", true);
        }else if (!isMove && isWalk)
        {
            anim.SetBool("isWalk", false);
        }

    }

6- Rotation ekleyelim. Bunu kendimiz ekledik kisaca,

tekrar actim controlleri abi, yeni bir binding, Mouse Delta ve controller right stick Degerler vVecor2

Actim bizim scripti yeni look degeri ekeldm vector2 olan. Ayni islemleri buna da uyguladm start,cancel,perform

buna yeni bir Metod yazdim OnLook

Update de de rotationu sürekli degistir yaparak burdan gelen veriyi pasladm sadece y ekseninde dönüyor.

Su andaki sikinti bu arkadas kendi ekseninde dönse de movement vectoru world e göre calisio yani baktgmz yere gidemioz.

Bunun problemi biaz derin Brackey videosuna bakiorm simdi : 

Braxkey detayli anlatmamis ama temelinde söyle bir sikinti var. movementin baktigi yönü bir sekilde LookPosa getrmemiz lazim bu da aslinda direkt LookPos u kullanmak demek.
Yani iki Inputtanbiriyle calisvblrz yA baktgn yöne gidecen ya gittigin yöne bakcan.

Tutoriala sagi geregi gittigin yöne bakma diyelm.

Burdan sonrasi biraz amelelik animaasyonlari falan ayarladik yine. Kosma ekledik ne bilym.

Quaterniondan baktgn yöne gidion iste.

7- Simdid e gravity eklioz.

 void handleGravity()
    {
        if (character.isGrounded)
        {
            float grv = -0.05f;
            movement.y = grv;
            Runmovement.y = grv;
        }
        else
        {
            float grv = -8f;
            movement.y += grv;
            Runmovement.y += grv;
        }
    }

su da gravity 


OOOOOOOHHHHHHh BEEEEEEEEEEEE amk.



