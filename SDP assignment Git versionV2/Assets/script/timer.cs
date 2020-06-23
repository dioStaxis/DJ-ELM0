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
    public GameObject player1;
    public GameObject player2;
    public GameObject UI;

    private float currentTime = 0f;
    private void Start()
    {
        currentTime = GameLengthSec;
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        //TimeText.text = ((currentTime-30)/ 60).ToString("0") + ":" + (currentTime % 60).ToString("0");
        TimeText.text = " "+currentTime.ToString("0");
        if (currentTime < 0)
            timeUp();
    }

    void timeUp()
    {
        Debug.Log("Time Up");
        if (player1.GetComponent<Health>().getHealth()> player2.GetComponent<Health>().getHealth())
        {
            GameObject p1Win = UI.transform.GetChild(1).gameObject;
            p1Win.SetActive(true);
        }
        else if (player1.GetComponent<Health>().getHealth() == player2.GetComponent<Health>().getHealth())
        {
            GameObject draw = UI.transform.GetChild(3).gameObject;
            draw.SetActive(true);
        }
        else
        {
            GameObject p2Win = UI.transform.GetChild(2).gameObject;
            p2Win.SetActive(true);
        }
    }
}
