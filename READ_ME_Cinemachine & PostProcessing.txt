Cinemachine 
---------------------
1- Burda bir ada sahnesi hazirladik biraz vakit alsa da mantiki oldugunu dusnuorm. Önce bir uitynin kendi demolarina bakacaz.
https://www.youtube.com/watch?v=x6Q5sKXjZOM&list=PLX2vGYjWbI0TQpl4JdfEDNO1xK_I34y8P

baslayalim.

2-Na kameraya cinemachine Brain component ekledik. Bu ana kameranin kontrolunu aliyor ve birden baska kameranin da yönetimine katki saglio.
TimeLine diye birsey var bir de scnede birsürü ye yapmani saglio. onu window dan dahile ttik projeye built in zaten 
https://www.youtube.com/watch?v=G_uBFM3YUF4 surdan bakarsin detayli

3- Unity tutorialda playerin animasyonuna göre yapilmis bir timeline var bu curscene gibi yapilmis bizim durum farkli biz kendimiz yönetiyoruz zaten. tieline simdi maincami atiorz ve bir cinemation track olusturourz. daha sonra timeline sag tiklayip cinemation shot dior. Oglum baayagi uzun lan. Bu shoti olsuturunca sagda Virtual camera sec cikiyor inspectorda ordan bu sefer yeni yarat diorz. hiyerarsiye simdi yeni kamera geldi. 

4-  Burda dikaktimi ceken olay su oldu. Simdi basit bir cutscene gibi ayarladik. playe basinca cutscene oynadi once. Ondan snra sahne kaldigi yerden scriptleri islemeye devame tti. burda bir sikinti var amq.

5- Uzun ugrasilar sonucu brackeya dönerek haletcez bunu. SImfi surda duralim. olay ikiye ayriliyor. Sen Cutscene mi yapacan oyunda mi kullancan. Cutscene de ise elemanin otomatik hareket etmesi ve animasyonlarin otomati olmasi gerek. Degilse farkli bir formül yapacaz. Biz simdi o farkli formulü yapioz. 

6- 4 tane camera olstrdm virtual cam. Bunlarin static olmasini istemiosan ki istemioz, Body seceneginde Don nothing var onu transposer yapman gerekio.o cok önemli. ondan sonra lock to target with world up diosn odan sonra da kameranin pozisyonunu ayarliosn.burda kritik sey su body yi ayarlaman icin bir transformu follow etmen gerek. Aimi ayarlayabilmen icin bir transforma look at demen gerek. Dead zone falan da burdan yapilio. Damping de mesela buranin bir parcasai.

7- ben 4 tane kamera yerlestrdm. her biri kendi icin de ayarli. 

8- Simdi timelina geri döndük. Adi üstünde amq timeline. Yani oyunun icinde olmasi münkün degil zaten. Cutscene yapmak icin kullanilio. Yukarda söylediklerim iptal. Oyunun icinde animasyonlarkonuluyor abi bublara bunlar da 

9- Valla naladim gibi yavstan. Yarin devamini halledecgmmm.

10- Simdi olayi kisaca özetliorm- Virtal camera aslinda ana kamera. Abstract ana kamera gibi düsünebilirz. bunu alip sahnede bir yere yerlestirioz. Follow ve Look at kismi yerini ve acisini ayarlamamizi saglio.Body ve Aimden kontrol edioz bunun detaylari da. Sabit bir kamera olur eger transform eklemezsek.Follow geldikten sonra Body den lokasyonu ayarlanio. bu önemli. 
neyse gecelim free looka. Bu kamera da virtual in aynisi ama bir farkla bu mouse hareketlerini algiliyor. yani saga sola bakabiliorz bu kamerayla. Ama merkezinde lookat dedigimiz nesne bulunuyor. Ve orbitinde de yine follow dedgmz.

Blend in camera da cok enteresan. Simdi bunun icinde yavru kameralar var. Child object seklinde bu kameralri istedgin yere yerlestir. bunlaar virtual camera ve ayarlari normal virtual olarak yapiliyor zaten. ana obje yani blend camera da durum su. child kameralara ne zaman gececigimizi görüyoruz. 1 saniye ilk camerada dursun. 3 saniye otekinde. gecis ease out olsun son kameradan sonra loop olsun vb. Cok güclü bir özellik cünkü icin e virtual degil herseyi koyabilirz. timleine a bunu atarsin sadecehangi kamera hangi anda ne yapmak istiosa yapar. bundan da aktive ederiz ou öyle güclü yani.

StateDriven Camera da ayni sekilde etkili bir arac. Bunun da altnda bir yavru kamera var . ama bu animatorlere göre degistirio. mesela karakterimiz yürürken yakin kaera kosarken uzak kamera. ziplayinca sinematik kamera falan. Yalniz bunlar child object olmak zorunda unutma.Buraya child kameralari yerlestirdek sonra tek tek ayarliosn ne yapmakistiosan bu kameralarla. Ben hespini virtual yaptim. Follow ve LookAt slotlarina tek tek de koyablrsn, ana blend kameraya bir tane transform da koyablrsn. Cocuklar override ediyor. kameralri istedgn gibi ayarladiktan sonra isin tatli kismi. StatDrivenCamera bir animator istio. Anitorun statelerine göre kameralari sirasiyla aktif edebiio. Tabiki bizim oyuncunun animatorunu verdik. asagida daha sonra statlere ekliorz. Statler aslinda animasyon statleri. Her animasyona bir kamera bir kamerayi atadm. hepsine degil pardon idle, yurume kosma. yürürken biri kosarkn biri falan aktif oluyor. Cameralarin yanindaki wait ve min fonksionu da aktif olmadan önce ne kadr beklio onu gösterio. yukardaki default blend iki kamera arasi geciste ne kadr beklion hangi sekil gecis oluo onu gösterio. iyi bayagi yani. Dövüs oyuu yaptin diyelm her bir animasyon da bir kamera girebilir ekrana.

ClearShot iste bu da nerdeyse ayni Ama tek farkla. Bunda amac su. playera herzaman clear bir line of sightimiz olsun. Yine kameralari dizdik ekrana. Her childa CineMachine collider eklenmesi gerekiyor burda en yakin mesafeyi tutabilme icin ama kendinden vardi bizim projede. Burda da hepsini yaptik aslinda cok zor bir kisim yok tzek sikinti 3. kamera aktif olmuyor hep 1 den sonra 2 ye geciyor. sonra tekrar bir anlamadm. Optimal target dstance dye birsey var colliderda onla oynayinca oluyor.

Simdi dolly Camera bunun bir decartli versiyonu var ki en cinmeatic kamera bu. Bunu olusuturunca otomatik bir path olusuyor burdan pathleri artirip yerlerini degstrebilirsin cok kullanisli. kamra bu pathlar arasinda gidip gelecek. pathlari nokta olarak kabul et ordan orya ordan raya kayiyor kamera. Bodysinde Dolly track scipti var oraya pek dokunmaya gerek yok. bu kamerayi harita boyunca kuracaksin. Gerekli Body ve Aim kurallarini yazacaksin. bu kamera ahrita boyunca oyuncuya bakacak iste. bayagi kullanisli. kameraya öyzgürlü veren biruygulama cok hosuma gitti.

Diger kamera türlerine calismadim ama Timelinedan bahsetmezsek olmaz

11- Normalde bu kameralar yine priority sayesinde ayni sahende ayni anda bulunabilir. Ama Cutscene yaparken de bayagi isimize yarayack bir component var. TimeLine. Sanki bu iksii ayni amac icin uretilmis. Timeline bir zaman etveli basit. Burda bir suru seyi anime edebiliosn melsea 10. saniyede eleman sunu yapmaya baslasin. 9. saniyede sunu yapmis olsun. isin daha güzeli iki zaman araliginda direkt bir animatorden animasyon da ekleyebiliosn. oyuncu burdaki zamana bakip ne söylenmisse ou yapio. Zaman cetvelinde bir komut yoksa scriptler gecerli oluo. Ayni sekilde bu timeline a cinemachine de koyabilioz. Naasil? Cok kolay cinemachine brain iceren Main Camerayi asagi ekliosn. SOnra yandaki cetvele bir cinemachine koyuyosn. Yukarda saydgmz kameralardan biri. Ordan zaman araligini ayarliosn kameraalarin. istersen transition da yapabrsn. bunlar hallounca timeline i oynat bir göreceksin kameralar sirasiyla aktif oluo. Ama player oynamasi icin play tusuna basilmali.

12- Simdi bu özellikleri kullanarak bir cutscene yapalm zaten cogu kismi halletmistim.
Cutscene yaparken de müzigi ekleyebilion timeline a o güzel bir özellik. Cutscene bitti sayilir bir de sey ekleyelim. Uncharted yazisi. onu da ekledik bir image keldik kendi zaten animator ekledi interpole edebilmek icin. Simdi postprocessing yapalim biraz.
-------------------------------
PosrProcessing
-------------------------------

13- uuu yee. Simdi bunun kurulusuna bakalm.

14- Projeden projeye farklilik gösteren bir havasi var. URP (Universal pipeline) kullanioz biz hep sikinti yok o yüzden.

15- önce bir bos gameobject yartiorz bu bizim Post Processing icin objemiz efektleri burdan yönetecez. onun icin buna bir PP Volume eklememiz gerekiaor. Volume ekleyince de bir profile eklememiz lazim. Onu da ekliorz. New diyeblrz. Ondan sonra abicim bir layer olsuutuorz bu performan acisinda önemli. Post Processing layerlari ayri tutulmali. PP diye layer olstrdm. Volume un oldugu bu gameObjectte bunu sectim. burda simdilik isimiz bu kadr.

16- Main cameraya gectim. Burda simdi post processingi isleyecek  bir layer componenti ekliorz. Iste bu layer componentinde layer oalrak PP yi seciorz. ASgida anti aliasing var burda FXAA iyi dior brackey reis.burda da simdi isimiz bitti.

17- Artik post processing yapablrz. bircok sey var. Bir onceki GameoBjecte dönüp add effect diyecegiz. ama önce bilmekte fayda var. kameranin girdigi bölgeye göre farkli effect imkanimiz var . bunu nasil yapiot. Volume da en ustteki component is Global burdaki tiki kaldirinca box collider ekliosn. Sonra mesela bu volume u abi git suyun altina koy. Box collider suyu kaplasin. Suyun altina girince kamera bu volumedaki efektler uygulanack cok iyi. simdi dönelim;

** Sonradan gelen not. Bu profillar önemli. Box colliderlara mesela her birine bu profile koycan Su profile i, magara profile i, catisma profile i. Bu bos gameobjectin icindeki volumdeki profile sürekli degiscek buna göre.

Colorlarla alakali bir sürü ayar var ama önce _____
Unity set color space
By default Unity use Gamma Color Space. To change it go to (Edit > Project Settings >Player), inside Other Settings tab you will find Color Space* — change it to Linear.
bunu cevriirnc tüm proje bastan yüklenio bunun önemi ama ne? Post Processing de Color Grading diye bir secenek var Add effect deyince. Burdan modelardan HDR seciorz bu sayede renklerle daha iyi iynaycaz. Ton mapping diye bir secenek var altinda ordan da ACES secilio standart en iyisi bu sibem sektöründe falan. WhiteBalance dan beyazlari beyaz yapablrsn sepya etkisi falan da var. Asagidaki Tone klasik renklerle oynama. Alttaki channel mixer da RGB ile oynama.  Trackballs var onlar sectigin renk yönüne dogru altta yazan seyleri sana saglio. Altta Grading Curves var bu güzel bence bayagi. ne yapiyo bu arkadas?

* 4 seneek var Hue - Hue, SAt, Lum-Sat. SAt-SAt.

Bu su demek mesela belli bir Hue da SAturation degistir. Bunu yapmak icin önce override sonra renk araligi secmek icin sag tiklayip add key on curve iki tane. Sonra bir de key ekliorz.Iki aralik belirledik mavide bir aralik. Sonra saturationi artirdim bayagi. ne oldu mavilerin sicajkligi artmis oldu. EFSANE. **burda exttra birsey de . Tum Hue yi asagi cekersek tüm resim siyah beyaz olacak sadece bizim sectgmiz aralik da renk olacak. Bu da güzel bir özellik. yaptik oldu vaaaay aq.
Colour look updiye birsey var o da otomatik yapio bu isleri Photoshop flan kullanion internette de vardir örnekleri kesin. Ihtiyacn olursa bakarsn. Colorlar bitti.
_________________________

Bloom. beyaz alanlar parliyor. HDR i aktif hale gtrdgimiz icin avantajimiz var ne o?
Bloomun altinda Color avr orda otomatik beyaz secili baska renk de olablr ama beyaz kalsin. Hangi rengi secersen sec hep beyaz parlio ama biz parlama rebgini degstiriorz. Kirmiziyla yaptgm cok güzel sonuc verdi mesela. Ona tiklayincaIntensity secenegi acildi. Intensity yi artirinca beyazlar parlio. Denizdeki yansima günes falan burdan yapilabilir. Günes de mesela burdan parlatilabilir. Diegr secenekler de iyilestirmeye yariyo. Asagida bir de Dirtines var bunun olay da su. Bir texture atiosn ve camur efekti fslan oluo bu bayagi yiiy.

Chromatic Abreklmflkd bisey var kirmizi mavi kenar verio.

Grai var bilioz bunu.

Vignetteyi sectm mesela. Kutucukalrin icine tikliorz greayedout konumdan aktif konuma geciriorz.Vignette- Burda  ektradan resim de ekleyebilioz modu map yapinca. iyi birsey.

________________

Depth of field önde bir nesne varken kullanisli. Call of Duty silah olayi mesela. bunu kullanmaya gerek yok bence.

Motion BLUr hahahaha amk siktirgit

Lnesditrotion da balikgözü özelligi olablr mesela burda cok ufak degisiklikler yapman lazim.
___________

Böylelikle de PostProcessing büyük oranda bitti cok da zor degilmis bunlari etkili kullanabilmek önemli tabi. Simdi bir cutscene yapalm.

