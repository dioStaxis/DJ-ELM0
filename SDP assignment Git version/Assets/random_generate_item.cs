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
            Debug.Log("item spown");
            
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
                Instantiate(SwordPrefabIcon, overlapPointV3, default_Quaternion);
                Debug.Log(itemSpownPositionX+" ,"+itemSpownPositionY);
                Switch = false;
            }
            
        }
        }
        Switch = true;
        
       
    }


}
