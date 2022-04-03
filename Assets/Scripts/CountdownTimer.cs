using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;

    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        textMeshPro.text = string.Format("{0:D2}:{1:D2}", (int)GameManager.timeRemaining/60, (int)GameManager.timeRemaining%60);        
    }
}
