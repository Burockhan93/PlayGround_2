Öncelikle inventory yapmanin bircok yolu olsa da temelde on/off olayi hep sikinti. Eventler bu konuda bize yardimci olacak onlari o yüzden calistik.

https://www.youtube.com/watch?v=S2mK6KFdv0I&list=PLPV2KyIb3jR4KLGCCAciWQ5qHudKtYeP7&index=2 

su seriden yardim aliorz.

1-Sahne kurulumu,nasvmesh interactable objeler falan filan

2- https://www.youtube.com/watch?v=HQNl3Ff2Lpo&list=PLPV2KyIb3jR4KLGCCAciWQ5qHudKtYeP7&index=5

su videodan itibaren item ve inventory odakli gidecez. baska videolar da var aslinda ama bunlara bakalim.

3- Bir itemi alabilmek icin scriptable tanimlayalim dedi eleman. Onun icin bir class yaptik bu Monobehaviourdan degil Scriptable dan inherit.

[CreateAssetMenu(fileName ="New Item", menuName ="Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon;
    public bool isDefaultItem = false;

}

Buraya kadr cok yeni birsey yok sonra objeeler koyduk ekrana onlara verdik bir iki ayar. Collidera girince nesne Snakein inventoryye grio falan.

4- Simdi basit bir UI yapalm. Ui yapim asamsinda toolarin icinde bir Sprite Editor bulduk ona bakiorm. uzun bir sürenin sonunda yaptigimizi düsünüorm.

5- Kisaca nasil calisior. InteractableObject,ItemSlot,SnakeInventory;InventoryUI,Item adinda 5 class yaptik.

6- Item bir scripatble Object her item icin isim ve sprte tutuyor.
   InteractableObjectler aslinda Item. Item referanslari var collidera girince Snake bunlari yerden topluyor
   SnakeInventory uzun biraz;

Burda item listesi var. Czrrent ve prev item referanslari var. Ve Scroll yapildiginda algilasin diye Snakeinput referasni var. Bu kisim SnkaeMove a benzeyen actiona dayali bir kod da icerio. Gecelim. Add,Remove ve Scroll fonksiyonlari var. Scroll event sonucu calisio. 3 tane de evetn var Add,Remove ve Scroll bu 3 eventi sirsiyla invoke edio.

   ItemSlot sadece bir Image tutuyor

   InventoryUi childobje olan ItemSlotlari alio startta. Ayrica SnakeInventorydeki eventleri de dinlio. Birsey eklenince,remove edilince ve degisince Ui i degstirio. Simdi biraz daha ekipman ekleyelim.

7- Onlari da ekledik ve bence güzel oldu inventory. 