AI ya gecenlerde basladik simdilik pek bir halt yapmiyor.

Map verticenden aldigi iki noktayi kullanrak haritada git gel yapiyor sadece. Cevresinde collider var o alana girince snake e dogru takibe basliyor.

https://www.youtube.com/watch?v=cnpJtheBLLY&t
su videoya bakalm

1- Gereginden fazla ugrastim ama bitti simdi aciklayalim

2- herseyden önce burda switch yerine class kurduk. State diye abstract bir classimiz var. Burda statelerin yapmasi gerekn methodlar tanimli. Sadece Runstate tanimladik.

3- Bu Statei Idle,Move;Chase,Kill inherit edio.bunlarin kendi uygulamalari var. Bakarsan anlarsin detaini.

4- Statemanager classi snake e bakiyor burda. bir transform gerekiyor. Simdi burda bir State fieldi var. Startta bu Idle. update de bir metod calistriioz. Bu metodda da currentState in uyguladigi metodu cagirioz yani currentState.RunState;

RunState i her State calstrio ve ya kendilerini "return this" ya da bir sonraki statelerini dönüolar. Idle mesela Chase. Bu sayede bir stateden ötekine veya ötekilere gecebilioz. 

R´Statemanagerin bu metodunun icinde yani RunstateMachine de 
State nextState = currentState?.RunState() ile yeni nextStatei alioz. NextState bir degisiklik olmazsa yine currentState dönüo.

nextState i de  SwitchtoNextStage(nextState); diyerek currentState e atiorz. Stetmanager bu sayede iki State arasi gecis saglamis oldu. güzel!.

Statemanager bir de update calstrio. distance ölcüo bunu hepsi yapablrdi buna koydum.
Statei burda interface yapsak da mantikli olurdu gibi geldi. Neyse.

5- IdleState alio su an sürekli kontrolde disance ölcüo.4 ten kücükse chase yap dio.

 public override State RunState()		bu metodu
    {					nextState = currentState?.RunState() surda cgrdik.
        if (canSeeSnake)
        {
            return chaseState;
        }
        return this;
    }

6- Sonra Chaase gelio mesafe 3 ten de azalinca Kill gelio. oraya birsey koymadim daha amirim. Ama özünde olay bu. Bunu ilerde gelstrmek mümkün.

7- idle dayken eleman güzel güzel yine sagasola gidio. bence baasarili ama best Practice i bulmak lazim zaman daralio.

8- simdilik bu da bu kadar.

9 AL sana StateMachine aq.




 dogustan  Snakele aradaki mesafe kücükken, Idle da.