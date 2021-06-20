-------------------------------------------------
Version Control
-------------------------------------------------

1-directory folder demek.

2- clone, githubdan pc ye gecirmek icin
add, degisiklik yaptigini git e bildiriosn
commit, yapilan degisikligi ekliosn
push, upload
pull, download böylece update edecez.

3- Repository ye dosyayi github in icinden ekleyebilioz direkt. text olstrup yazi ysazdik commitledik.Ayni dosyayi degistirmek de mümkün

4-simdi bu dosyayi pc ye nasil aliorz?

-PC de bir dosya actik.
-Icine girip GitBsh dedik
-git clone repository linki
-Busayede giti kopyaadik. 
-Artik gitbashi .git dosyasinin oldugu yerde kullanmamiz gerek
-deneme.txt i burda degstrdik
-git status deyince bu degisiklik görlüo kirmizi ama
-ama git daha bunu takip edecek konumda degil
- git add . deyip butun degisiklikleri ekliorz. Ama git add dosyadi yazarak da bunu halledeblrz git add denemetext.text
-git status deyince bu degisiklik görlüo bu sefer yesil

- simdi commit edelim
git commit -m "deneme düzeltldi"          -m zoraki kesin bir yorum olmak zorunda . ikinci -m description

-su an locally yaptik degikligi
-git push dyerek online hale gtirioz
Öncesinde bir de resim ekledim remin adi BF 2042.png Bosluk oldugu icin bunu add derken 'BF 2042.png' diye yazmak gerek
sonra commitledim.

- simdi push
git push origin master   burdaki origin directory master da branchimiz. AMA  AMK   MASTER ISMI UNITYLE ACINCA DEGISMIS ARTIK MAIN OLMUS UNUTMA.

- Simdiii tam tersi LOCAL TO GITHUB

-deneme2 klasörü actik. buna bir text ekledim. 
- Bu bir local directory degil daha cunku icinde .git dosyasi yok. Onu eklemek icin
git init
yazdim. Gitignore da önemli onu da deneme1 den kopyalaylm.
- Simdi add, commit
-Push nasil yapacaz.
- En basidi bir bos repositiry yapcaz.
- Bu repositoryle bizim localdeki dosyalari birlestrmemiz lazim

-git remote add origin https://github.com/Burockhan93/deneme2.git (remote bu pc de degil , baska bir repositoryde)(add  ekelycez neyi?)(origin bu directory yi)

-bunu yaptiktan sonra git remote -v ile bu repository baska bir yerde nerelerle iliskilendirilmis onu görüorz

-simdi iste git push origin main veya git push yazablrz. AMA YINE DIKKAT SU ANKI REPOSITORY NIN BIR PUSH UPSTREAMI YOK YANI NEREYE PUSHLAYACAGIIZI BELIRTMEZSEK PUSHLAMAZ: 
git push kendi basina yeterli degil.
git push origin master
	veya
git push -u origin master

yazdiktan sonra direkt git push da artik yazilablr.

 git push --set-upstream origin master
Enumerating objects: 4, done.
Counting objects: 100% (4/4), done.
Delta compression using up to 8 threads
Compressing objects: 100% (3/3), done.
Writing objects: 100% (4/4), 796 bytes | 796.00 KiB/s, done.
Total 4 (delta 0), reused 0 (delta 0), pack-reused 0
To https://github.com/Burockhan93/deneme2.git
 * [new branch]      master -> master
Branch 'master' set up to track remote branch 'master' from 'origin'.


gitte de söyle görünüyor. BUNDA MAIN YERINE MASTER AVR

-------------------------------------------------------
SSH Keys
-------------------------------------------------------
bunu gitlab icin yapalm

Aslinda basit bir konu nasil oluyor kisaca aciklaym

- SSH Key genel bir sifreleem politikasi. Bir gitlab veya github repositoryye her pc girmesin diye böyle birsey cikarmislar. Sen kendin SSH key üretebiliosn. Ben de onu yaptim nasil? cok kolay
cmd yi ac
ssh-keygen yaz
istedgn klasörü sec(defaultu users/burak)
default olsun enterea bas
sifre yok bir daha entera bas
olusuo
burak/.ssh klasöünde simdi iki tane key var. Biri .pub yani piblic demek onu text olarak ac icerigi kopyala
Gitlab a git. Prefenrceda ssh keysler var oraya ssh keyi gir aciklama yaz, exprtn date optional
add key de
olur büyük ihtimalle.

Burda önemli bir bilgi Gitlab instanci. Gitlab da farjkli domain kullanioz biz. Yani ne demek bu?

Bunun cok yöntemi var ama Windows 2019 da cok basitlestrmis bu isi o yuzden bunu kullanmak mantikli.

Bu keyi githuba da yükledim bir uyari verdi yaptgn commitlere flagged olacak diye is akisini aksatmaz sanrm.

Her neyse key önemli aga

Bu sayede Unityi de clonelamis olduk devam edelim
-------------------------------------------
GIT BRANCH
------------------------------------------

Branch mantigini aciklio kari iyi bayagi.

-simdi gitbashe git branch yazinca branchler siralanio. Bizim denemede main deneme2'de master bu branchler. Basinda da bir yildiz var o da current burda oldugunu gösterio.

-git checkout -b feature/second/deneme2 
bunu yazinca ana branchten cikip bu branche gectik. 'feature/second/deneme2' böyle yazinca kabul etmedi. naming koncention var.

- git branch			artik böyle görünüo
* feauture/seconde/deneme2
  master
 gidip git checkout master yazarsam ötekine geri döner
 yani -b yenisini de yaratiyo

-bu branchdeyken denenene.txt dosyasi yaratip commitledik.

-git diff feauture/seconde/deneme2
commitlemesek surdan farklari göreblrdik.
git push burda calismaz neden cunku bu branch de bilmio nereye pushlayacagini buna da söylememiz lazim

- git push --set-upstream origin feauture/seconde/deneme2
 görülen üzere mastera degil ama kendi branchina her branch birbinden bagimsizdir unutma

- Simdi gidince githuba deneme2 de iki branch var ve masterda denenene dosyasi yok

- Simdi bu 2. branchden ana branche göndercez.

-PR: PUll Request

-Merge: yapilan degisiklik istenen branche PR ile akrtarilio.Bu islem 2.branchi de kapatio.

-Githuba gidiorz.

-Orda yukarda yeni branch görünüo. Pull Request Compare falan yazi tikla oraya. Arada cakisan birsey yoksa able to merge diyecek ve sen degisiklikleri aciklayarak yazablrsn artik. Baslikd a koyablrsn

- Pull request olustruldu simdi o sekmeye giidnce ustte reposotiry sekmesinin yaninda basligini koydugun pull request asagida görünüu. Buirden fazla da olablr. SOSnucta bir projede ayni anda bir sürü adam calisio. kendi PR ina tikla. Orda yapilan degisiklikler görülüo. yesille eklenen kitmizyla silinen. oraya coment de yapablrsn. genel olarak comment de yapablrsn bayagi komunikasyona acik.

-asagi indikce merge PR görecen tikla ona ve sonunda merge oldu. Yani 2. branch su an masterla esitlendi. 

- Ama bu degisim senin local repositrynde degil Github da oldu. onu bir görmemiz lazim localde.
-Git mastera gidiorz cunku degisim orda git checkout master
- upstreami kurdgmz icin önceden git pull yazsak yeterli yoksa git pull origin master veya 

- artik bu 2. branch uselees silelim

 git branch -d feauture/seconde/deneme2

warning: not deleting branch 'feauture/seconde/deneme2' that is not yet merged to
         'refs/remotes/origin/feauture/seconde/deneme2', even though it is merged to HEAD.
error: The branch 'feauture/seconde/deneme2' is not fully merged.
If you are sure you want to delete it, run 'git branch -D feauture/seconde/deneme2'.

söyle bir hata aldik demekki commitledgmz birseyler var yine de silmek icin

git branch -D feauture/seconde/deneme2

Merge Conflicts: concflictler cikablr bunlarin üstesinden gelelm.

yine branch olstrdk dosyaya degsklik yapalm.

git diff yapilan degskligi gösterio son committn bu yana. Bu branch ana branchten ayrldgi icin son commitleri ayni

- tek dosyayi degstrdiysek git commit -am "hem add hem commit yorumu". Bu modiified dosyalarda gecerli yeni dosylarda degil

- simdi mastera gectik txt dosyasi eski haline döndü amk. Onu aldik degstrdik.

- Simdi tekrar öteki branche dönemioz. Cünkü dönersem bozulacak.Stash yapmam gerekio veya commitleyecegz.

- simdi gecebldik.
- simdi mergeleyecz

-git merge master
 sunu yazinca sikinti cikti. Denene dosyasini acinca farklar görünüyor.

-=========== sonra gelen kisim merge edilmek istenen conflictli kisim
>>>>>>>>>>>>>>> söyle olan seyler de conflict bunlari da sil böylede Git conflict var diye düsünmesin artik

 git commit -am "merged in master"

yaparak artik mergeledik.

- git reset son add olayini iptal edio, 
git reset dosya adi tek tek dosylardaki degisikligi

-git reset HEAD bu da son commite döndür
git resed HEAD~1 bir önceki commite

her commite dönme imkani da var onu da söyle yapioz.
git log azinca her commitin kimligi cikio

git reset o kimlik

o commite dönüoz

git reset --hard da add yapilan doslayari da silio en makulu silmek istedgnde bu

----------------------------------------
Git LFS
----------------------------------------
Total 553 (delta 410), reused 0 (delta 0), pack-reused 0
remote: Resolving deltas: 100% (410/410), completed with 115 local objects.
remote: error: GH001: Large files detected. You may want to try Git Large File Storage - https://git-lfs.github.com.
remote: error: Trace: d6466ddd832f58bea511da2cea942f8d5e6c29ba5d5be91b3385290283872ad9
remote: error: See http://git.io/iEPt8g for more information.
remote: error: File Assets/Materials/MetalGear/Enemy/Ch15_nonPBR.fbx is 109.69 MB; this exceeds GitHub's file size limit of 100.00 MB
To https://github.com/Burockhan93/PlayGround_2.git
 ! [remote rejected] master -> master (pre-receive hook declined)
error: failed to push some refs to 'https://github.com/Burockhan93/PlayGround_2.git'


BU HATA!!!!!!!!!



SImdi 100 mb dan büyük dosyalari push layamion o yuzden Git LFS var.

1- Install direkt.

2- projednin oldugu yerde gitBash ve git lfs install

git lfs install
Updated git hooks.
Git LFS initialized.

3- simdi normalde söyle yaptik

 git add Assets/Materials/MetalGear/Enemy/Ch15_nonPBR.fbx

bu sayeede bu dosyayi tracke aldik

 git add .gitattributes
 su dosyada trackli dosyalar bunu da add demen gerekio ayrica.

SOnra git add/commit deyip gönderion LAKIIIIINN

4- Biz bu projeye bu büyük dosyayi ekleyince commitlemistik zaten. ama push olmamisti sonra bir daha commitledik sonra bir daha derken bu büüyk fbx dosyasi commit historysine karisti. Push dedigimiz zaman her ne kadr LFS bunu takip edio olsa da önceki commitlerde takipci olmaadigi icin atamiodur.

5- Bu sorunun cözümü 

https://github.blog/2017-06-27-git-lfs-2-2-0-released/

migrate diye birsey yapioz.

Önce git lfs migrate info

100 mb üstü dosyalar görünüyor. Ordan istersen hepsini dahil et ama biz fbx de sikinti oldugunu biliodk
Dosya yolu belirterek de yapilablr ama ona bakamadm.

 git lfs migrate import --include="*.fbx"


böyle yapinca override etmek istion mu dio evet de

sonra git push de bitir bu kadr.



