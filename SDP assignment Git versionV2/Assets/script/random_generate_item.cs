using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class random_generate_item : MonoBehaviour
{
    public GameObject SwordPrefabIcon;
    public GameObject AxPrefabIcon;
    public GameObject Lv1Armor;
    public GameObject Lv2Armor;
    public GameObject Lv3Armor;
    public GameObject Lv1Potion;
    public GameObject Lv2Potion;
    public GameObject Lv3Potion;

    public LayerMask spownLayer;

    public float worldLengthMin = -30;
    public float worldLengthMix = 30;

    float spwoneTime = 0f;

    bool Switch = true;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= spwoneTime)
        {
            spwoneTime = Time.time+UnityEngine.Random.Range(0.0f, 10.0f);
            
            while (Switch)
        {
            float itemSpownPositionX = UnityEngine.Random.Range(worldLengthMin, worldLengthMix);
            float itemSpownPositionY = UnityEngine.Random.Range(worldLengthMin, worldLengthMix);

            Vector2 overlapPoint = new Vector2(itemSpownPositionX, itemSpownPositionY);

            Collider2D collider = Physics2D.OverlapPoint(overlapPoint, spownLayer);
            if(collider != null)
            {
                Vector3 overlapPointV3 = overlapPoint;
                overlapPointV3.y += 1.3f;
                Quaternion default_Quaternion = new Quaternion(0, 0, 0, 0);
                    float spownItemNumber = UnityEngine.Random.Range(1, 8);
                    switch (spownItemNumber)
                    {
                        case 1:
                            Instantiate(SwordPrefabIcon, overlapPointV3, default_Quaternion);
                            break;
                        case 2:
                            Instantiate(AxPrefabIcon, overlapPointV3, default_Quaternion);
                            break;
                        case 3:
                            Instantiate(Lv1Armor, overlapPointV3, default_Quaternion);
                            break;
                        case 4:
                            Instantiate(Lv2Armor, overlapPointV3, default_Quaternion);
                            break;
                        case 5:
                            Instantiate(Lv3Armor, overlapPointV3, default_Quaternion);
                            break;
                        case 6:
                            Instantiate(Lv1Potion, overlapPointV3, default_Quaternion);
                            break;
                        case 7:
                            Instantiate(Lv2Potion, overlapPointV3, default_Quaternion);
                            break;
                        case 8:
                            Instantiate(Lv3Potion, overlapPointV3, default_Quaternion);
                            break;
                    }
                //Debug.Log(itemSpownPositionX+" ,"+itemSpownPositionY);
                Switch = false;
            }
            
        }
        }
        Switch = true;
        
       
    }


}
