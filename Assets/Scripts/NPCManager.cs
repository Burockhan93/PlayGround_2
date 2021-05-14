using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class NPCManager : MonoBehaviour
{
    public NPC[] npcs;
    int counter = 0;
    [SerializeField] TextMeshProUGUI textMesh;
    [SerializeField] UnityEvent OnCompleteEvent;
    public ParticleSystem p;
    

    void Start()
    {
        
        //OnCompleteEvent.AddListener(PlayParticle);
        foreach (NPC npc in npcs)
        {
            if(npc!=null)npc.OnInteract += HandleDialogue;
        }
    }
    public void PlayParticle()
    {
        p.Play();
    }

    void HandleDialogue(NPC npc)
    {
        counter++;
        if (counter == 4) OnCompleteEvent.Invoke();

        StartCoroutine(Type(npc));
    }

    IEnumerator Type(NPC npc)
    {
        foreach(string s in npc.dialogue)
        {
            textMesh.SetText(s);
            yield return new WaitForSeconds(0.5f);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
