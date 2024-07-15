using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class twopReverse : MonoBehaviour
{
    public RectTransform tworeverse;

    int twopreverse;
    int twopreversepoint;

    // Start is called before the first frame update
    void Start()
    {
        twopreverse = 0;
        twopreversepoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (twopUIActive.twopturn == 2)
            {
                if (twopreverse == 0)
                {
                    twopreverse = 1;
                    tworeverse.position += new Vector3(0, 200f, 0);
                }
            }
        }
        
        if(twopreverse == 1)
        {
            if(twopUIActive.twopturn == 3)
            {
                if(twopreversepoint == 1)
                {
                    twopreverse = 0;
                    twopreversepoint = 0;
                    tworeverse.position += new Vector3(0, -200f, 0);
                }
            }

            if(twopUIActive.twopturn == 0)
            {
                twopreversepoint = 1;
            }
        }
    }
}
