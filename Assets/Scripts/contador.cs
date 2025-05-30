using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class contador : MonoBehaviour
{
    public int count = 0;
    public TextMeshProUGUI counterText;

    void Start()
    {
        UpdateCounterText();
    }

    public void SumarSemilla()
    {
        count++;
        UpdateCounterText();
    }

    void UpdateCounterText()
    {
        counterText.text = count.ToString();
    }
}
