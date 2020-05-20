using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class identity_number: MonoBehaviour
{
    public static int playernumber = 0;
    // Start is called before the first frame update
    public int addNewPlayer()
    {
        return playernumber++;
    }
}
