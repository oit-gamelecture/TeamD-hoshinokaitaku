using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class twopUISleep : MonoBehaviour
{
    public RectTransform twosleep;
    public RectTransform two2;

    int twopsleep;
    int twopsleeppoint;

    // Start is called before the first frame update
    void Start()
    {
        twopsleep = 0;
        twopsleeppoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
     if(twopsleep < 0)
        {
            twopsleep = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (twopUIActive.twopturn == 2)
            {
                ++twopsleep;
                if (twopsleep == 1)
                {
                    twosleep.position += new Vector3(0, 200f, 0);
                }
                else if (twopsleep == 2)
                {
                    two2.position += new Vector3(0, 200f, 0);
                }
                else if (twopsleep >= 3)
                {
                    twopsleep = 2;
                }
            }
        }
        if(twopsleep >= 1)
        {
            if(twopUIActive.twopturn == 3)
            {
                if(twopsleeppoint == 1)
                {
                    twopsleeppoint = 0;
                    --twopsleep;
                    if(twopsleep == 0)
                    {
                        twosleep.position += new Vector3(0, -200f, 0);
                    }
                    else if(twopsleep == 1)
                    {
                        two2.position += new Vector3(0, -200f, 0);
                    }
                }
            }
            if(twopUIActive.twopturn == 0)
            {
                twopsleeppoint = 1;
            }
        }
    }   
}
