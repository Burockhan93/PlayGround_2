Nullable : int? a =null. yazmamzi saglio normalde int null olmazd veya bool true/false disinda null da olabilio bu sayede.hasValue diye metodu var null degilse obje true verio
Nullable<int> a = 5 diyerek de deger verilebilir.

Tuple<T1,T2> myTuple bir dictionary ye benzer yyapi.

ref : Bir metoda parametre gönderdigimiz zaman aslinda metod bunun bir kopyasini alio. Mesela plus(int c,int d) metoduna| int a =5, int b=10 plus(a,b) gönderirsek a ve b yi degil bunlarin degerini gönderiorz. metod da c ve d ye bu degerleri atio. ama plus(ref int c, ref int d) dersek ve metodu da ref a ref b diye cagrrsak direk paramtereleri gönderiorz cok kullanisli amk. Liste göndermistik mesela onun kopyasi üzerinden is yapildigi icin sahende göremiodk degisim zumada. Static parametre kullanmitik o yüzden. bu yöntemle daha hili olur. 

out da su. int a ve int b dedik ama bunlara deger vermedik yani initialize demedk ya plus (out a, out b) diorz. metodu da (out int c,out int d) diye degtiorz. Simdi bu metod icinde c ve de yi degstrince a ve b o degeri alio. Yani bir nevi rückgabetype ama birden fazla degeri degstrien. 

String format: kisaca ---string s= String.Format"Naber lan {0} {1} nasilsin?,yarakkafali,musab" süslü parantez icinde sona ekledgmz variable lar gelio. Veya $ isareti--Console.WriteLine($"Hello, {name}! Today is {date.DayOfWeek}, it's {date:HH:mm} now.");--direk metod icindeki degiskene referan edio zaten.

?? : sometype =  someothertype ?? new Sometype();
kisaca someothertype nullsa yeni initilize et degilse someothertype olsun bizim sometype.
yani sometype = someothertype!=null ? someothertype : new Sometype()

----------------------------------------------------------------------------------------
Linq
----------------------------------------------------------------------------------------
1-  using System.Linq;

string names[] = {"Burak","ALi","Can","Dertli"}

var linqtest = from (herhangirbirisim)name in names
		where name.Contains('a') (name string oldugundan)
		select name (bunu dön)

dönen de yine array. Ama bu dönme olayi söyle. 
forach(name in linqtest) dedigin anda bu arama yapilio. yani dinamik bu linqtest. liste degistikce bu da degiseblr.

2-  var linqtest2 = names.Where(name => name.Contains('t'))  bu da c# version. Where bir extension Stringlere. name burda beliebig biz koyduk adini.

3-  List<Student> studentListe = new List<Student>(); icinde bir sürü var iste bunun.
Class Student{
enumartor var Studiengang, int semester, name, vorname}
 bu listenin icinden simdi sadece informatik calisanlari alacaz

where olayi bir filter aslinda bunu bilioz.

var infoStudent = from student(beliebig) in studentListe
		  where student.Studiengang == Studiengang.Informatik
		  select student;
		  (StudentListe.Where(student => student.STudiengang==Studiengang.Informatik))

sonra foreach le cagrcaz bu infoStudenti ö sayede sorgu yapilcak.

Devam edelim; ve , veya ekleyeblrz. Where in ici güclü

var infoStudent = from student(beliebig) in studentListe
		  where student.Studiengang == Studiengang.Informatik && (student.semester <4)
		  select student;

ofType:   bu sefer Tier liste kurduk. Tier ana sinif bir tane altinda Dog ve Cat var bunlar inherit edio.Bu listeden sadece köpekleri almak istiosak;

List<Tier> TierListe = new List<Tier>(); 

var hunde = from tier in TierListe.ofType<Dog>()
		select tier

4-  OrderBy  ThenBy

from student(beliebig) in studentListe
		  where student.Studiengang == Studiengang.Informatik && (student.semester <4)
                  orderby student.age descending, student.semester ascending 
		  select student;

önce azalan sirayla yasa göre sirlaancak sonra artan sirayla semester a göre

Buranin güclü bir yani da su:
C#
var studentListe = StudentList.OrderBy(stud => stud.Semester).ThenBy(stud=>stud.Age).ToList()
    
böylece bir listemiz oldu Studentten.

var studentListe = StudentList.OrderByDescending(stud => stud.Semester).ThenByDescending(stud=>stud.Age).ToList()  

5- GroupBy

var groupStudent = from stud in StudentListe
		   group stud by stud.Studiengang

Bu simdi bir Dictionary gibi birsey yapio anladgm kadryla. Her bir eleman aslinda KeyValuePair ama kisaca var de gec

foreach(var group in groupStudent){

Debug.Log(group.Key) -----> Burda Informatik, Machinebau falan cikacak. Sonra icine bir foreac daha

    foreach( Student stud in group ){
		stud.ToString();----- ToString javadaki gibi classin icinde override ettik.
C#

var studGroup = studentList.groupBy(stud=>stud.Studeingang) bu yine group dönüo

6- Aggreationlar (Min max falan)

int [] numbers = new int[] {1,2,4,5,6,7,8,6,5,3}

var result = numbers.Max() ; Extendion yine bu ya da Min()

var result = numbers.Where (number => number<10).Max();

var result = numbers.Average() veya Sum() veya Count()

var result = numbers.Aggregate((sum,val)=> sum+val)  fonksionel programlama bu da recursionla buluoz. lambda expression yaptik. sum+val dönecek olan fonksion iste . 

https://docs.microsoft.com/de-de/dotnet/api/system.linq.enumerable.firstordefault?view=net-5.0 
burda bütün metodlari bulunuo.FirstorDefaultta bunun mesela

----------------------------------------------------------------------------------------
Extensions
----------------------------------------------------------------------------------------

Elimizde bulunan classlara ekstra metod ekleyebilirz. mesela String classinin String.Format() gibi bir metodu var. Ne ise yario bu classin icinde public static bir mtod bu ve belli basli string fromatlama isini yapio. Biz de Stringe su an güzel bir metod ekleyelim hadi.

Bunun icin yeni bir static class acacaz genelde projelerde bir static classin icinde hersey konulur.

static class Extensions{

	public static int ToInt(this String str){
		
		return Convert.ToInt32(str); // (bu da yine static class ve metodu)
	}
}

Simdi bu metodla ne yaptik. String classina yeni bir metod ekledik. 

String s = "2018";
int s1 = s.ToInt()  // s1 de int degerli 2018 oldu. Bazen ise yariyor bu extensionlar

Isin garip kismi static class ne lan? ona da bakalim.

----------------------------------------------------------------------------------------
Static Classes
----------------------------------------------------------------------------------------
A static class is basically the same as a non-static class, but there is one difference: a static class cannot be instantiated. In other words, you cannot use the new operator to create a variable of the class type. Because there is no instance variable, you access the members of a static class by using the class name itself. For example, if you have a static class that is named UtilityClass that has a public static method named MethodA, you call the method by name
The following list provides the main features of a static class:

Contains only static members.

Cannot be instantiated.

Is sealed.

Cannot contain Instance Constructors.

*Sealed ne demek? 

sealed class Vehicle 
{
  ...
}

bu classi kimse inherit edemez demek.

---------------------------------------------------------------------
Polimorfism 

base class da virtual,

public virtual void animalSound() 
  {
    Console.WriteLine("The animal makes a sound");
  }

child classlarda override keywordu ile

public override void animalSound() 
  {
    Console.WriteLine("The dog says: bow wow");
  }

saglanior
-----------------------------------------------------------------------------
Abstract Class abstract meod uzgulamasi yok ve normal uzygulamali metod barindirablr
------------------------------------------------------------------------------
interface yine ayni uygulamasi olmayan metodlar
--------------------------------------------------------------------------------
Collections

https://docs.microsoft.com/de-de/dotnet/api/system.collections.generic?view=net-5.0

1- kevaluepair neymis onu ögrendik;

****KeyValuePair<TKey,TValue> is used in place of DictionaryEntry because it is generified. The advantage of using a KeyValuePair<TKey,TValue> is that we can give the compiler more information about what is in our dictionary. To expand on Chris' example (in which we have two dictionaries containing <string, int> pairs).

Dictionary<string, int> dict = new Dictionary<string, int>();
foreach (KeyValuePair<string, int> item in dict) {
  int i = item.Value;
}

Hashtable hashtable = new Hashtable();
foreach (DictionaryEntry item in hashtable) {
  // Cast required because compiler doesn't know it's a <string, int> pair.
  int i = (int) item.Value;
}

*****KeyValuePair < T,T > is for iterating through Dictionary < T,T >. This is the .Net 2 (and onwards) way of doing things.

DictionaryEntry is for iterating through HashTables. This is the .Net 1 way of doing things.

Here's an example:

Dictionary<string, int> MyDictionary = new Dictionary<string, int>();
foreach (KeyValuePair<string, int> item in MyDictionary)
{
  // ...
}

Hashtable MyHashtable = new Hashtable();
foreach (DictionaryEntry item in MyHashtable)
{
  // ...
}

 List<Keyvaluepair> yerine Dictionary kullanmanin avantaji da Hash degerini kendi icinde kontrol ettigi icin duplicatelara izin vermio Dictionry. Keyler uniqe yani Dictionryde

List<KeyValuePair<int, string>> pairs = new List<KeyValuePair<int, string>>();
pairs.Add(new KeyValuePair<int, string>(1, "Miroslav"));
pairs.Add(new KeyValuePair<int, string>(2, "Naomi"));
pairs.Add(new KeyValuePair<int, string>(2, "Ingrid"));

Dictionary<int, string> dict = new Dictionary<int, string>();
dict.Add(1, "Miroslav");
dict.Add(2, "Naomi");
dict.Add(2, "Ingrid"); // System.ArgumentException

2- 

HashSet<T>   https://www.geeksforgeeks.org/hashset-in-c-sharp-with-examples/


Bildigin Set iste listeden performansi daha iyi olsa da ayni eleman bulunamio.
Add,Remove,IntersectWith gibi metodlari var.
RemoveWhere(Predicate<T> match)  bu boolean dönen bir metod olmali.

3- Comparer<T>  bu classin tek amaci Compare metodunu override etmek. 

IComparer<T> interfaceini uyguluo kisaca:

 public int Compare(Box x, Box y)
    {
        if (x.Height.CompareTo(y.Height) != 0)
        {
            return x.Height.CompareTo(y.Height);
        }

Ama asil uygulama documantasyona göre Comparer<T> yi de inherit eden SampleComparer<T> ile olacak.

 public override int Compare(Box x, Box y)
    {
        if (x.Length.CompareTo(y.Length) != 0)
        {
            return x.Length.CompareTo(y.Length);


Burdan anlaycgmiz gibi Sampla classin length height gibi propertyleri var.

Bir liste yaptik diyelim Generic Examples.Sort(new SamplerComparer()) eyip siralama yapablrz. Lakin, Linq bunlari daha etkin bir sekilde yapio diye biliorm. Burda özellikle birsey karsilastrma istiosak belrtecez.

4- EqualatyComparer<T>  verilen nesne ayni mi ona bakio. Setlerde ayni nesne listeye alinmioodu ya onu burdan yönetebilioz iste.

https://docs.microsoft.com/de-de/dotnet/api/system.collections.generic.equalitycomparer-1?view=net-5.0

class BoxSameVolume : EqualityComparer<Box>
{
    public override bool Equals(Box b1, Box b2)
    {
        if (b1 == null && b2 == null)
            return true;
        else if (b1 == null || b2 == null)
            return false;

        return (b1.Height * b1.Width * b1.Length ==
                b2.Height * b2.Width * b2.Length);
    }

    public override int GetHashCode(Box bx)
    {
        int hCode = bx.Height * bx.Length * bx.Width;
        return hCode.GetHashCode();
    }
}

bu örnek Ayni hacme sahip kutulari ayni kabul eden bir kod icerio. Baska örnekler de konulabilir.
Bu equals metodu listeye birsey atarken otomatik calisio. biz calstrmioz. false dönerse ayni eleman olduguna karadr verio.Tabi default listelerde bu olay daha yumusak.

5- getValueOrDefault

Gibt zurück
TValue
Eine TValue-Instanz. Wenn die Methode erfolgreich ist, ist das zurückgegebene Objekt der Wert, der dem angegebenen key zugeordnet ist. Bei einem Fehler gibt diese Methode den default-Wert für TValue zurück.

key
TKey
Der Schlüssel des abzurufenden Werts.
defaultValue
TValue
Der Standardwert, der zurückgegeben werden soll, wenn das dictionary keinen Wert finden kann, der dem angegebenen key zugeordnet ist.

6- Stack<T>  Last in first Out tipi. Queuenin tam tersi. Push() ve Pop() metodlari var

7- Queue<T> First in First Out Enqueue Dequeue, Peek() sonraki sayiyi verio (yoksa -1 )verio

8- Bu classlarin interfaceleri var bir de metodlari tutan onlara da bak

9- Son olaral List ve LinkedList bir de LinkedList Node.

Burda adamlar herseyi cok prof hazirlamis

https://docs.microsoft.com/de-de/dotnet/api/system.collections.generic.linkedlist-1?view=net-5.0

Burda sadece LinkedList<T> degil LinkedListNode<T> da önemli. bu ikisine ihtiyac duydugunda bakarsin ama veri yapialri cok cok önemli. Bizim oyunda yine LinkedList yapmis olsak direkt sundan sonra sunu ekle dedigimizde liste bastan yazilirdi. aq

Nodelarin metodlari , Equals   GetHAshCode     GetType     ToString     MemberWiseClone(Shallow copy)
Propertyler        List(ait oldugu listeyi döndürüo) Next  Previous   Value(T degerini verio) ValueRef


SImdi LinkedList gel. 3 sekilde contruct edilebilio her liste gibi ya sonu boyle () ya (IENumaerable<T>)(bir liste burayi implement ettigiicin ehrhangi bir liste olablr) ya da 3. var ama sacma

Propertyler   Count     First      Last

Metodlar owww yeaaaa   bir sürü var hangisini sayalm aq. Acaip fazla ama kendi metodlari public olanlar  AddAfter   AddBefore   AddFirst     Addlast     Clear Contains  Equals Findds
RemoveFirst/last ..

bunlara argüman olarak ya bir T degeri verioz ya da direkt LinkedListNode<T> degerini
--------------------------------------------------------------------------------------