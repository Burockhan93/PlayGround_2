using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

public class NPCManager : MonoBehaviour
{
    public NPC[] npcs;
    int counter = 0;
    [SerializeField] TextMeshProUGUI textMesh;
    [SerializeField] UnityEvent OnCompleteEvent;
    private GameObject panel;
    public ParticleSystem p;
    private Image speaker;
    

    void Start()
    {
        panel = textMesh.transform.GetChild(0).gameObject;
        speaker = panel.GetComponent<Image>();
        
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
        speaker.sprite = npc.icon;
        speaker.color = new Color(255, 255, 255, 1);

        StartCoroutine(Type(npc));
    }

    IEnumerator Type(NPC npc)
    {
        foreach(string s in npc.dialogue)
        {
            textMesh.SetText(s);
            yield return new WaitForSeconds(0.5f);
        }
        speaker.sprite = null;
        speaker.color = new Color(255, 255, 255, 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
