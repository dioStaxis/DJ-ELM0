using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class charSelect : MonoBehaviour
{
    public void char1Map1()
    {
        SceneManager.LoadScene("map1");
    }
    public void char1Map2()
    {
        SceneManager.LoadScene("map2");
    }
    public void char2Map1()
    {
        SceneManager.LoadScene("map1Owl");
    }

    public void char2Map2()
    {
        SceneManager.LoadScene("map2Owl");
    }

    public void Back()
    {
        SceneManager.LoadScene("mapSelect");
    }
}
