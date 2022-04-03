using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillCounter : MonoBehaviour
{
    private TextMeshProUGUI killCounter;

    void Start()
    {
        killCounter = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        killCounter.text = GameManager.numKills.ToString();
    }
}
