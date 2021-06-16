Önce package Managerdan indirion ShaderGraph toolunu.

Öncelikle bu olay materyallere hayat verio. Animasyon, glow effekt, akiskanlik aklina ne gelirse acaip güzel bir tool ve cok genis. Bunu oturup ögrenemezsin en basta bunu bayagi calismak gerek yine de burda bir iki bakacaz deneyecez.

Bunun yaninda Package Managerdan Universal Rendering Pipeline da indirmek gerekior.

Simdi isimize bakalim. Artik Create degimizde Shader secnegini görüorz. Nunun altinda bir sürü secenek var. Normalde PBR secilio ama bu kalkmis yenisinde. onun yerine blank diorz. Cift tikliorz ve ShaderHraph menusu gelio. SAgda secenekler var. Activa targets add deyip universal ekliorz. URP yüklemesek göremezdik.

Veeee preview pembe. Bu büyük problem. Bunu cözmek yrim saatimi aldi aq ama kisaca anlatym cözüldü.

HDR Pipeline ve Universal Pipelinelar var. Bunlar kendi yöntemleriyle materyallere kiyafet giydirio yani sahder edio. Ben projeye bunlari dahil etsem de hala proje URP yi kullanmiodu. O sebeple ShaderProah toolu icindeki preview pembe görünüyordu cunu URP shadei renderleyemio. Bunu cözmek icin 

https://docs.unity3d.com/Packages/com.unity.render-pipelines.universal@7.1/manual/InstallURPIntoAProject.html

buraya gittik. burda Upgrade olayi anlatio eleman iyi anlatmis. Kisaca

In the Editor, go to the Project window.
Right-click in the Project window, and select Create > Rendering : Universal Render Pipeline, Pipeline Asset. 

burdaki Rendering secenegi URP yi indridkten sonra gelio.

Bunu yaratinca 2 tane scriptable Obje geldi elimize. URP Asset önemli. SImdi bu objeyi aliorz ve

Navigate to Edit > Project Settings... > Graphics.
In the Scriptable Render Pipeline Settings field, 

buraya koyuyorz. Vola! Artik shader Graphdaki pembelik gitti elimzde materyalmz var. Sükür--- mü acaba?

AMK. böyle yapinca projenin geri kalan herseyi pembe oldu niye? Cunkü Standart shader render edilmitri bu materyaller URP bu sefer bunlari cözemio. Cözüm ne? Cok kolay adamlar herseyi bastan asagi düsünmüs aq.

2 secenek var

Edite gidiosan en asagida Render PipeLine secenegi var oraya gel, Universal Render Pipeline var oraya da gel sonra 2 secenek daha var . Bütün materyalleri URP upgrade veya secili nesneleri.

Bu aslinda su demek herhangi bir materyalin üstüne tikla. Inspectorda shader kisminda en üstte URP / Lit secmek demek. yani manuelde yapablrsn. Ama cok fazla nesne varsa tek tek elindle ugrasma diye koymuslar. Upgrade all deyince buyuk ihtimal hersey düzelir. veya URP scriptable asseti silince eski haline gelir. Burda Post Processing de etkileniomus. Mesela benim CinemAchine sahensi su an tamamen pembe ve PostProcessing efekti gitmis. Bunu düzeltmenin yolu yok. Post Processing olayini sifirdan yapman gerekio. veya URp yi silip yapacan. Biz burda farkli proje yerine farkli sahne kullanioz o yuzden bu sikintilari yasioz ama normalde yasanmaz. Projenin basinda dogru Pipeline secince o sikintilar gider.

Simdi dönelim kendi Shaderimizaaaa. Toola girince pembelik gitti. Burda oynamalar yapablrz nesnyele. Sonra save asst diorz. Veya Save as deyip farkli kaydediorz. Ardindan herhangi bir materyal yartip shader ini yine sag üstten bu sefer URP degil, ShaderGrap> yarattgmz  nesnenin adi yapiorz. Burda sikinti cok materyal varsa geleckte sikinti yaratablr onun disinda baska sorun yok. Veya bu asseti materyallerin icine sürükle birak yapiorz ikisi de olur.

BU URP yi ekelyince main camera da biraz degismis. Orda da ufak farklar olsa da özünde ayni isi yapio.


Setup kismi bittigine göre simdi isin icine dalalim. Brackeyin ufak bir videosu bize isik tutacaktir.

Glow effect nasil yapilir onu anlatmis brackey biz de bakalm bir nasil yapilior.

1- önce emission bir rol oynuo glow da mantiken. O yüzden emissiona bir node eklememiz lazim bu node fresnel effect. glowdan sorumlu

2- Ama fresnel Effect kendi basina sadece beyaz glowu verebilio o yüzden renk de uygulamak gerek. Multiply ve Color adinda iki node daha cikardik. Color ve Fresneli Multiply e sokuorz o da Emissiona a gidior.

3- Colori HDR yapip daha iyi emission saglamak mümkün

4- Bu haliyle saave asset dersek, materyali nesneye atarsak nesne gayet canli ve güzel duruo.

5- Ama bir sikinti var. Materyal rengini degstriemirz. Color Node una gelip, Convert to Parameter dersek solsa Properties kismina gidio bu. Artik ediorden renk ayarlamak mümkün. bunu bircok node icin yapablrsn ama hepsine olmuo.

6- Bir de Glow ekleelm dedik. Bu biraz performan düsrdü acikcasi. Sadece bir nesnein bu kadar kasmasini beklemiodm.

7- Multiply node umuzu emissiondan cekip baska bir multiplye koyduk.

8- Buraya önce Time sonra Remap diye iki arka arkaya nde ekledik. Time sunu yapio. -1 ,1 arasi ac kapa. biz bu 0,1 arasi olsun diye remapte bu islemi yapioz. sonra multipliera iletioz. en son bu Multiplier Targeta gönderio bunu. Ve güzel bir glow effek elde ediorz.

9- Dedigm gibi performan issue cok sikinti. bunu önüne gecmek lazim ama su an bilmiorm. ShaderGraph olayina peyderpey bakacam ve sirrini cözmeye calscam. Hani gamei start edince sikinti yok ama editorde refresh rate cok az. 

10- ShaderGrap pencersini kapatinca da az hata gelio. Sonra scene viewe tiklamazsan nesne hareket etmio ve fps sikintisi yasamioz. bununbir sebebi scenede yukarda skyboxu da acip kapadgmz yerde bir secenek var. Always refresh kapali olmasi lazim orda yoksa scene sürekli refresh edio kendini. Bir kahvalti edeym devam edecem aq.

11- Simdi su Javid denen elemanin 30 tane shaderi var onlara bakalm dedim

12- Direkt indirip kurabilion calisio iyi calismis. bugun bir iki tanesine bakip nedir nedegldr anlamaya calsym. videolar mevcut internette. Paternelri gösterio .

13- Ilk basta anlamasi oldukca zor zaten zamanla gelisecek bu.Elemanin yaptigi hersey direkt uygulanabilio bence guyuk adam. 











