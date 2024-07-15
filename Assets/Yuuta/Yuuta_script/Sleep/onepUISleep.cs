using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class onepUISleep : MonoBehaviour
{
    public RectTransform onesleep;
    public RectTransform one2;

    int onepsleep;
    int onepsleeppoint;

    // Start is called before the first frame update
    void Start()
    {
        onepsleep = 0;
        onepsleeppoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(onepsleep < 0)
        {
            onepsleep = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (onepUIActive.onepturn == 1)
            {
                ++onepsleep;
                if (onepsleep == 1)
                {
                    onesleep.position += new Vector3(0, 200f, 0);
                }
                else if (onepsleep == 2)
                {
                    one2.position += new Vector3(0, 200f,0);
                }
                else if(onepsleep >= 3)
                {
                    onepsleep = 2;
                }
            }
        }
        if (onepsleep >= 1)
        {
            if(onepUIActive.onepturn == 2)
            {
                if(onepsleeppoint == 1)
                {
                    onepsleeppoint = 0;
                    --onepsleep;
                    if(onepsleep == 0)
                    {
                        onesleep.position += new Vector3(0,-200f,0);
                    }
                    else if(onepsleep == 1)
                    {
                        one2.position += new Vector3(0,-200f,0);
                    }
                }
            }
            if(onepUIActive.onepturn == 3)
            {
                onepsleeppoint = 1;
            }
        }   
    }
}
