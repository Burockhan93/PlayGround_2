Kaynak kodu bu klasöre koyacagm, gitten elemanin teki bir event sistemi daha dogrusu manageri gelstrmis bakalim.

Burda ögrendiklerimiz;

ONEnable wawkaeden hemen sonra gelio.
Awake genelde initilization icin bu parametreleerin
Startta da referanslar icin kullanilio

Bu scriptte olay da basit.
---------------
SUbscribe
---------------------
EventManager var bu singleton. Icinde dictionary var bi tane burda UnityEventler var
Dictionary<string, UnityEvent> eventDictionary;
napio bu dic?
Startlistening diye bir komut var eventmanagerda. 
public static void StartListening(string eventName, UnityAction listener)
    {
        UnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            instance.eventDictionary.Add(eventName, thisEvent);
        }

isin cogu kismi burda zaten. Bu metod bir metod girisi aliyor baska class a ait. ve bunu ismi gecen evente subscribe ediyor.

burdaki trick su;

 UnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
         su komut su ise yariyor. önce null bir event create ettik. Sonra metoda argüman olarak paslanan eventi dictionaryden bulmaya calsitik. Bulabilirsek (TryGetValue) bu yeni yarattgmiz evente referans verdik.

Bulamazsak;

else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            instance.eventDictionary.Add(eventName, thisEvent);
        }

yeni event yaratip bu dictionary ye ekledik ve ayrica subscribe da ettik.

**....,UnityAction listener) argümani aslinda bir metod. evente subscribe edilen metod. event.Addlistener(listener) deyince bu metod bu evente subscribe edilio.
----------------------------
Simdi Unsubscribe
----------------------------
 public static void StopListening(string eventName, UnityAction listener)
    {
        if (eventManager == null) return;
        UnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

ayni mantik bu sefer unsubscribe yaptik. Her nasil Addlistener,UnityEventin bir metodu ise, RemoveListener da öyle. Invoke da öyle. simdi bir de Invoke yapacagz zaten
--------------------------
Invoke
--------------------------

public static void TriggerEvent(string eventName)
    {
        UnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke();
        }
    }

-----------------------------
Simdi dinleyicilere geldi sira 3 ünde de mantik ayni.

Ball "START" eventine sbscribe oluyor. dinleyen metod da HandleStrat. Bos metod da olsa olur aq. rb nin  velocity startta da verilebilirdi yani. AMa triggeri burda degil. triggeri yani Invoke eden metod Startda.  Starta basinca invoke oluyor START eventi ve dinleyenler basliyor muhabbete.
Digerleri arasinda da böyle bir iliski var zaten.

Lakin, burda da coupling cok. Benm metal gearda yapmak istedgime yakin birsey bu. ama sorunlari var. Eventler daha iyi yonetilmeli kanimca. Eventler de kendi arasinda gruplara ayrilabilir belki. Herneyse güzel caölisma.