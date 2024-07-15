using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fourpUIReverse : MonoBehaviour
{
    public RectTransform fourreverse;

        int fourpreverse;
    int fourpreversepoint;

    // Start is called before the first frame update
    void Start()
    {
        fourpreverse = 0;
        fourpreversepoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (fourpUIActive.fourpturn == 4)
            {
                if (fourpreverse == 0)
                {
                    fourpreverse = 1;
                    fourreverse.position += new Vector3(0, 200f, 0);
                }
            }
        }
        if(fourpreverse == 1)
        {
            if(fourpUIActive.fourpturn == 1)
            {
                if(fourpreversepoint == 1)
                {
                    fourpreverse = 0;
                    fourpreversepoint = 0;
                    fourreverse.position += new Vector3(0, -200f, 0);
                }
            }
            if(fourpUIActive.fourpturn == 2)
            {
                fourpreversepoint = 1;
            }
        }
        
    }
}
