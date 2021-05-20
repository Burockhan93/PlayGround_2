using UnityEngine;
using UnityEngine.UI;

public class Start : MonoBehaviour {

    Button _button;

   

	void Awake()
    {
        _button = GetComponent<Button>();
    }
    public void HandleClick()
    {
        EventManager.TriggerEvent("START");
    }

    void OnEnable()
    {
        EventManager.StartListening("START", HandleStart);
    }

    void OnDisable()
    {
        EventManager.StopListening("START", HandleStart);
    }

    void HandleStart()
    {
        _button.interactable = false;
    }
}
