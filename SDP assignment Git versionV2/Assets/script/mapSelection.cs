using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mapSelection : MonoBehaviour
{
    // Start is called before the first frame update
    public void Map1()
    {
        SceneManager.LoadScene("ingame");
    }
    public void Map2()
    {
        SceneManager.LoadScene("map2");
    }

    public void Back()
    {
        SceneManager.LoadScene("Main menu");
    }

}
