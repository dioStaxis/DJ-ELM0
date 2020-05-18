using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public TextMeshProUGUI TimeText;
    private float startTime;
    private void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        float t = Time.time - startTime;
        TimeText.text = t.ToString("0");
    }
}
