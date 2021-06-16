using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class örnekscript : MonoBehaviour
{
    TextMeshProUGUI text;
    SimpleEnemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        enemy = GetComponent<SimpleEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text =enemy.health.ToString();
    }
}
