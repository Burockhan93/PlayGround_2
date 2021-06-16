using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("NewScript/TipsandTricks")]
[DisallowMultipleComponent]
[ExecuteAlways]
[HelpURL("http://example.com/docs/MyComponent.html")]
[RequireComponent(typeof(Rigidbody))]
[SelectionBase]
public class TipsandTricks : MonoBehaviour
{

    [Header("Int ler")]
    [Range(1,5)]
    public int a1;
    public int a2;
    //[Delayed()]
    public int a3;

    private int b1;
    private int b2;
    private int b3;

    //[DelayedAttribute]
    [Header("Stringler")]
    public string s1 = "base";
    public string s2 = "aa";
    [Multiline(10)]
    public string özel = "ooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo";

    private string sp1;
    private string sp2;

    [Space(5)]
    [Tooltip("Öyle nir color sec")]
    [ColorUsageAttribute(false,false)]
    public Color c1 = Color.white;


    [GradientUsage(true)]
    public Gradient gradient;

    [Header("Gizmolar icin")]
    public Texture myTexture;

    public Transform myTransform;

    public Mesh myMesh;

    
    [ContextMenu("Do")]
    public void DoSth()
    {
        Debug.Log("Do");
    }

    [ContextMenuItem("DoSecond", "DoSecond")]
    public string playerBiography = "";
    public void DoSecond()
    {
        playerBiography = "seconf do";
        Debug.Log(playerBiography);
    }

    [RuntimeInitializeOnLoadMethodAttribute]
    static void AfterWake()
    {
        Debug.Log("Awake has passed");
    }

    //void OnDrawGizmosSelected()
    //{
    //    // Draw a semitransparent blue cube at the transforms position
    //    Gizmos.color = new Color(1, 0, 0, 0.5f);
    //    Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));
    //    Gizmos.DrawFrustum(Camera.main.transform.position, 1, 100, 1, 1);
    //    Gizmos.DrawGUITexture(new Rect(10, 10, 20, 20), myTexture);
    //    Gizmos.DrawIcon(transform.position, "Light Gizmo.tiff", true);
    //    if (myTransform != null)
    //    {
    //        // Draws a blue line from this transform to the target
    //        Gizmos.color = Color.blue;
    //        Gizmos.DrawLine(transform.position, myTransform.position);
    //    }
    //    Gizmos.DrawWireMesh(myMesh, transform.position, Quaternion.identity);
        
    //    Gizmos.DrawSphere(transform.position, 1);
    //}

    //void OnDrawGizmos()
    //{
    //    // Draw a semitransparent blue cube at the transforms position
    //    Gizmos.color = new Color(1, 0, 0, 0.5f);
    //    Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));
    //}
}
