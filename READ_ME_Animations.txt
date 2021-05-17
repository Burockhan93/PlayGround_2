ANIMATIONS IN UNITY

https://www.youtube.com/watch?v=-FhvQDqmgmU&list=PLwyUzJb_FNeTQwyGujWRLqnfKpV-cj-eO video serisi

1- Mixamoyla basladik. ne oldugunu anlatiyo. Animasyon isinin interpolasyon olmasindan falan bahsetti.

2- Mixamodan bir iki skin animasyon indircez deneme icin. Eleman cok iyi anlatiyor yalniz.

3- Modellerin icinden simdi animasyonlari cekiyoruz. o sayede Loop timelairi secebildik yoksa grayed out duruyorlardi.

4- Animatordeki Update Modlar , normal Time Scale a göre oynuo . Slow moton icin cok iyi.Animate Phsics fiziki temasta, öteki de UI icin. Culling Mode performasn icin.

5- has Exit time da dedigim gbiymis iste. Defaultta 0.97 si bitmesi lazim bizim animasyonun

6- transition ayarlarina bakiyoruz. Solo demek sadece kendi oynayacak demek animasyon. Mite tamamen kapatior. Transition offset cok iyi, animasyon nerden baslayacak onu söylüo . ben bir bakabilirim benim solid snake icin. Sonuncusu da Interruption. Burda da olay su baktin transtiion cok uzun sürüyor, burda next statei secersen direkt next animasyona geciyo beklemeyi kaldirioz yani.

7- Animatorde sadece set metdou yok get metodu da var.
	anim.GetBool("isRunning") gbi mesela

8- Simdi yurume kosma yerine bir blend tree ekledik.blend Tree basically sunu yapiyor. Iki animasyonu aldin. Yurume ve kosma. Unity fizik motoru sayesinde iyi bir interpolsayn yapabilio ve ikisi arasinda yeni animasyonlar üretebilio. Blend tree yi olstrunca parametrele blend diye bir float eklendi bu otomatik. Bunun adini velocity yaptik.

9- Blend Tree ye cift tiklayinca altinda bu velocity ayarlanabilir degisken olarak cikiyor zaten. Buraya sagdan parameter kismindan baska degisken de atayablrz. Float olacak ama.

10- BlendTree nin sag üstüne tiklayip add motion dedik 2 defa ve yürüme ve kosmayi ekledik. Daha sonra karakterin icindeki sxcripti bir iptal edeip deneme yaptik.

11- Simdi durum su. Idledan blendtree ye gecmek icin velocity artmasi lazim. blendtree nin de icinde iki animasyon var bu ikisini karistirsacak peki hangi ölcude. tabiki de velocity degeri kadaar. Su an icin oluyor.

12- Yeni script yazdik. AnimationBlend diye icerigi oldukca simple. Yalnizca;

	velocityHash = Animator.StringToHash("Velocity");
anim.SetFloat(VelocityHash,velocity) Updatein icinde de velocity ye bu degeri verdik.

su sekilde Controllerdaki Velocity degerini scriptteki bir degere atiyoruz, buraya akdar hersey normal oldu. w ye bastikca hizlaniyo bizim robot ve animasyon da cok smoot bir sekilde interpole oluo.Buralar önemli. Tek sikinti geri yerine gelmio. velocity += yazdgmiz icin. bir de deceelarion parameter ekledik. eliizi cekince azaltio degeri bir de 0 in altina inmesin diye sigorta ekledik.
buraya kadar sikinti yok.
blend Tree nin icinde threshold degerleri var bunlar ana parametre suraya gelene kadr sadece su deger olsun demek gbi birsey. Bu yaptgmiz 1d blend tree idi simdi ikiye geciorz.

13- Simdi 2d blend tree de olay biraz karisik maalesef. neden? https://www.youtube.com/watch?v=_J8RPIaO2Lc vudeoda cok güzel anlatio 2d de koordinat sistemi dusun simdi X,Y. X yönünde sadece 2 animasyon Y yönünde sadece 2 animasyon arasinda blend animasyonu yapilio. Aslinda bu 2d Simple Direction icin gecerli biz freeformu sececz bu sebeple.

14- 4 tane daha animasyon indirdik saga dohru kosma sola dogru kosma ve yürüme.

15- Blendtreeyi yaratip 2d freeformu sectik.Bunu Default yaptik. Otomatik bu sefer 2 parametre geldi bunlar dedgmiz gibi X,Y koordinatlari ama hareket düzlemi X,Z oldugu icin VelocityX ve Z diyecegz.

16- blendin icine tüm motionlari atadik / tan hepsi.

17- Cok enteresan bir grafik cikiyor yukarda onun manasi su, Bu animasyonlar aldigi degerler isiginda hangi yöne dogru etki yapiyor.

18- mesela hepsini sifira aldik. Walki Pos Y de 0.5 e aldik cunmku o yöne dogru ilerlemesi gerek. Run i da 2 ye aldik. grafige bkinca anlion hii dion. Bu su demek. 0.5 e kadar yürü ondan sonra 2 ye kadar kos. ama 0.5 ve 2 arasi bir transition avr onu unutma. bunu simdi her animasyon icin yapalim. 0.5 yürüme 2 run. Fakat left right strafe ve run da ileri dogru degil saga sola gidiorz. o yuzden Pos X e degerler vercez. bir de extradan ben geriye yürüme ve kosma ekledim zor olmamasi lazim. Güzel esit dagitilmis bir animasyon grafigi cikti karsimiza. Scriptsiz sadece graphdan ayarlayarak hallettik. 
* Her animasyon looptime ve loop pose secili olacak. önemli.

19- Simdi gelelim scripte. ELeman cok karisik yapio ama ona uyalim.

20- Suraya akdar olan kisim oldu ama iyilestirileblr nasil? Vectorler yardimiyla tabi. Bunun ustune calisiom zaten MetalGearda o yüzden cok girmeyim burda. Burda da oldu ama eksikler var 

forwardPressed = Input.GetKey(KeyCode.W);
        backPressed = Input.GetKey(KeyCode.S);
        leftPressed = Input.GetKey(KeyCode.A);
        rightPressed = Input.GetKey(KeyCode.D);
        runPressed = Input.GetKey(KeyCode.LeftShift);

        if (forwardPressed && velZ<0.5f && !runPressed)
        {
            velZ += Time.deltaTime * acceleration;
        }
        if (backPressed && velZ >-0.5f && !runPressed)
        {
            velZ -= Time.deltaTime * acceleration;
        }

        if (leftPressed && velX > -0.5f && !runPressed)
        {
            velX -= Time.deltaTime * acceleration;
        }
        if (rightPressed && velX < 0.5f && !runPressed)
        {
            velX += Time.deltaTime * acceleration;
        }

        if (!forwardPressed && velZ > 0.0f)
        {
            velZ -= Time.deltaTime * decelaration;
        }
        if (!backPressed && velZ < 0.0f)
        {
            velZ += Time.deltaTime * decelaration;
        }
        if (!leftPressed && velX < 0f)
        {
            velX += Time.deltaTime * decelaration;
        }
        if (!rightPressed && velX > 0f)
        {
            velX -= Time.deltaTime * decelaration;
        }
        if (!forwardPressed && !backPressed && velZ != 0 && (velZ > -0.05f && velZ < 0.05f))
        {
            velZ = 0;
        }
        if (!leftPressed && !rightPressed && velX != 0 && (velX > -0.05f && velX < 0.05f))
        {
            velX = 0;
        }

burayi gelistrcez iste.

21- public float maxWalkVel = 0.5f;
    public float maxRunVel = 2f;  su iki  degiskeni yazdik. degerlerin böyle olma sebebi blend tree de atadgmz degerler.
currentRunVel = runPressed ? maxRunVel : maxWalkVel;  burda da kullanioz iste

if (forwardPressed && velZ< currentRunVel)
        {
            velZ += Time.deltaTime * acceleration;
        }
daha sonra da condirionlari degstrdik runpressedi kaldirdik. yarine currentvelocityti koyduk.

22- Kodun sonlari iyice uzadi sikti aq. Ama optimize oldu bakip analrsin.

23- Isin özünde ama bayagi optime full hareket eden bir arkadas cikti ortaya . benim anladgm animayon hakkaten zor!

24-  Yine Mixamodan bir sey indirioz. Timmy, Jump, inmedi amk interneti

25- karakterlerin riglerine bakioz, Legacy- eski. Generic default olan. humanoid de humanoid kaarkterler arasinda iletisim . Humanoidis secince Avatar üretmemiz gerekecek yeni. bunu da bu modelden yai Create From this Model diyrek yapioz. Skin weights i s.et bu default dursun.4 bones yani sonra apply dicez.

26- Configure dersek rig menü gelecek avatarin yeni yarattgmiz. Simdi burasi önemli. Burda her kemik yerine oturmali. Kendi yarttgmiz karakterlerde bu olmayabilir. O yüzden buraya kendimiz koyacaz. Altta Mapping falan var buralarda görme isini yapioz.

27- Burda iste bayagi iyi oldu. Kisaca bir animasyonu alioz bir karakterden ama onun icindeki avatari da ciakrtmamiz lazim. Bu islemi yaptiktan sonra diger karakterlere bu avatari giydirioz. Dogal olarak giydirilen karakter reski avatar ve ona bagli animasyonlari artik kullanamaz. Su ana kadar snake e surekli mixamodsan indrdgmiz icin uyumlu oluyordu . Humanoid sextysek animasyonu her animasyon humanod olmali. Birkac ufak degisim de var. bakarsin sonra

28- Simdi akarkterleri anime etmeye geldi ki bu biraz zor iste.

Layer sistemindan bahsedio eleman. Burda da cok fazla sey var ama internet yzunden cok uygulayamioz. gerci uygulayack birsey de yok. Video sadece. Olay kisaca su
simdi bir layer olustualm. Bu layer da silah tutma olsun. Bu yeni layer yürümenin ustune ekleniyor. ve biz agirligini ne kadar artititsak önceki layerla karisio. Blendde bir transition vardi burda üst üste binme var karistirma. Peki bu cok sacma degil mi evet sacma. o yüzden layerlardaki animasyonlarin uygulandigi avatarlara gelip belli basli kemikleri deaktiviate edebiliosn. Yani ilk layer yürüme ikincisi hedef alma olsun. Hedef almada sadece kollar aktif olacak. Iki layeri birlesitirnce yürürken hedef alan insan ortaya cikiyor. 
Weigtin altinda da bir mask var. Burdan iste yapioz bu olayi. Projekt menüde bir create > mask dioz ordan avatari secip yarttgmz laye3rdaa bunu secioz. Override ve additive var buraya kadar olan override di. Additive biraz karisik ve güzel. Ileri seviyede bakarz. Sync de cok iyi. Sync de injured gbi durumalrda kullanilio

29- Animations,
Bir nesneye tiklayip animation sekmesine gelince aadd Property cikiyor orda objeye yüklü componentleri göreblrz.
previewe basarsak aniamsyon cubugunu rahatca oynatip animasyonu görürüz.
kirmiza basnca degisiklikler kaydedilio.
kaydete basip timleine saga getrlm. Keypointler oynamyacak dogal oalrak. SImdi nesnede birsey degstrelim. bu degisiklik neticesinde timeline in altinda yeni pointler belirecek. Bu keyleri oynayablrz iste ekle/cikar falan. Samples ordaki fps yi gösterio. SAmplesin sag altinda bir ok var o event. Onun sayesinde objeye takili scriptlerden public function cgrblrz. bayagi iyi. Mesela renk degstrme. Ayni oalyi bir animasyonun ustune tiklayip yaparsak bu sefer bu eventtin ara yüzü daha kapsalim oluyor. bakarsin. Asagida dopesheet ve curve var. Dopesheeti kullanioz normalde. curve da interpolation olayini gösterio. Curve le oynayarak animastioni degstirebilioz. bu aslinda cok yararli silah atisi yaptiktan sonra tepme efekti koyabilirz. Daha sonra bu animasyon araligini mesela 3 sn den 2.8e dusurerek silahtan sonra hizlanmis gbi tepme efekti vereblrz. Bu konuyu Idle da kullancam MetalGearda.

Vay anasini bununla birlikte animasyonlari bitti burdan sonra Inputlar var. Bayagi da iyi oldu .



