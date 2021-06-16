1- Youtube da bu konuyla cok ilgili bisi yok o yuzden Unity DOctan bakacaz.
1.a- https://docs.unity3d.com/Manual/editor-EditorWindows.html  cok daha detayli bir bilgi burda. unity personalization konusunda oldukca basarili. Ve icerisi derya deniz. baska bir zaman bakilablr.

2- Bu konunun gebel adi Attributes.
https://docs.unity3d.com/ScriptReference/AddComponentMenu.html

doc burda. Bugüne kadar gördügüm bütün editor yardimcilari var bakalim sirayla. Burda metodlar non static olmali unutma.

2.a. https://unity3d.college/2017/05/22/unity-attributes/ su eleman ise yarayanlari toplamis

3. Attribute yazisina gerek yok herseyin sonunda.


------------------------------------------
TipsandTricks classi olstrduk.

AddComponentmenu  :  [AddComponentMenu("Transform/Follow Transform")] classin basina yani scripte bunu yazinca AddComponent menusunden ulasilablr oluo script.

BeforeRenderOrderAttribute. anlamadm

AssemblyIsEditorAssembly: editor classi yapiyor. [assembly: AssemblyIsEditorAssembly]

ColorUsageAttribute: Color degiskeni tanimladin. basina bunu yazison.  [ColorUsageAttribute(false)] alfa degerini kapatiyor. ikinci true/false da hdr la alakali.

ContextMenu: Bu metodun basina gelio. Bu scripti bir objeye atadin diyelim. Sagda inspectordan bu scripti buluosn ve bu metodun adini orda görebiliosn. Orda tiklayinca fonksiyon calisiyor amq. Olaya bak.

ContexttMenuItem bir field in basina gelio. [ContextMenuItem("Do","DoSecond")] Do fielde inspectorda sag tikladgnda görecegin isim, DoSecondda scriptteki method.

CreateAssetMenuAttribute : Scriptable classindan inherit olan classlarin basina gelio bilioz zaten bunu

CustomGridBrushAttribute: uzun bit konu

Delayedatrribute denedim olmadi. 

DisallowMultipleComponent bunu yazinca ayni scrip objeye 2 defa eklenmio

ExcludeFromObjectFactoryAttribute  scriptin basina buu yazinca ObjectFactory() metodlari calismio bunlarda. AddComponent,CreateGameObjectCreateInstance,CreatePrimitive bunlar Monobehaviourun static metodlari sanrm

***Preset  https://www.youtube.com/watch?v=RXDS0mAhtKw

ExcludeFromPresetAttribute  presete eklemeyi engellio scripti

[ExecuteAlways]  bazi scriptler edit modda da calisio. Bunu basa yazinca hem runtime hem editorde calisan bir scriptimiz var demeke

ExecuteInEditMode  bu da editmode a özel

[GradientUsage(true)] Gradient fieldin basina gelincw onun renkler HDR oluo. güzel.

GUITargetAttribute Constructor  Gui ile alakali

Header: Desikkenlerin basina getirince bir baslik altina alio.

[HelpURL("http://example.com/docs/MyComponent.html")]  custom doc sayfasi sunuyir.

[HideinInspector] bilioz

[ImageEffectler] anlamadm.

[Multiline(10)] inspectorde stringe 10 satir veri<or.

PropertyAttribute anlamadm.

[Range(1,5)] bilioz

[RequireComponent(typeof(Rigidbody))] start edince rigidbody eklenio. en ise yarayanlardan iri

RPC decapricated

RuntimeInitializeOnLoadMethodAttribute: Awakeden hemen sonra calisacak fonksyionlar. Ama static olmaalri lazim

SelectionBaseAttribute : bu olunca efsane. Sahende mesela tikladin bir nesneye onun cocuguna geliodu hep. Sonra hiyerarsi bozuluo cocuk nesneyi saga sola oanaion falan. bu sayede sadece bu scriptin oldugu secili kalio.

[SerializeField] bilioz

[Serializable] bilioz.

SharedBetweenAnimatorsAttribute:

bunu özellikle uzun yazdim cünkü animasyonlarin state durumlariyla alakali bir gelisme var. 

class in UnityEngine/Implemented in:UnityEngine.AnimationModuleLeave feedback
Description
SharedBetweenAnimatorsAttribute is an attribute that specify that this StateMachineBehaviour should be instantiate only once and shared among all Animator instance. This attribute reduce the memory footprint for each controller instance.

It's up to the programmer to choose which StateMachineBehaviour could use this attribute. Be aware that if your StateMachineBehaviour change some member variable it will affect all other Animator instance using it. See Also: StateMachineBehaviour class.

using UnityEngine;

[SharedBetweenAnimators]
public class AttackBehaviour : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("OnStateEnter");
    }
}


[SpaceAttribute]  5 piksel ara birak fieldlar arasi inspectora
[TextAreAttribute] Stringe textarea ver
[TooltipAttribute]  fieldin üstüne hovering yapinca cikan deger



