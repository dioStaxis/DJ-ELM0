using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public TextMeshProUGUI TimeText;
    public float GameLengthSec = 180f;
    private float currentTime = 0f;
    private void Start()
    {
        currentTime = GameLengthSec;
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        TimeText.text = ((currentTime-30)/ 60).ToString("0") + ":" + (currentTime % 60).ToString("0");
        if (currentTime < 0)
            timeUp();
    }

    void timeUp()
    {
        Debug.Log("Time Up");
    }
}
